using _00_Repetition_EntityFramework.Data;
using _00_Repetition_EntityFramework.Models;
using _00_Repetition_EntityFramework.Models.Entities;
using Microsoft.EntityFrameworkCore;



namespace _00_Repetition_EntityFramework.Repositories
{


        public interface IProductRepository
        {
            public Task<IEnumerable<Product>> GetAllProductsAsync();
            public Task<Product> CreateProductAsync(ProductCreate product);
        }

        public class ProductRepository : IProductRepository
        {
            private readonly DataContext _context;

            public ProductRepository(DataContext context)
            {
                _context = context;
            }

            public async Task<Product> CreateProductAsync(ProductCreate product)
            {
                /*  
                    IF NOT EXISTS (SELECT Id FROM Categories WHERE Name = @CategoryName)
                       @CategoryId = INSERT INTO OUTPUT INSERTED.Id Categories VALUES (@CategoryName)
                       @ProductId = INSERT INTO Products OUTPUT INSERTED.Id VALUES(@Name, @Description, @Price, @CategoryId)
                       RETURN 
                            SELECT p.Id, p.Description, p.Price, c.CategoryName FROM Products WHERE p.Id = @ProductId
                            JOIN Categories c ON p.CategoryId = c.Id
                    ELSE
                       @CategoryId = SELECT Id FROM Categories WHERE Name = @CategoryName
                       @ProductId = INSERT INTO Products OUTPUT INSERTED.Id VALUES(@Name, @Description, @Price, @CategoryId)
                       RETURN 
                            SELECT p.Id, p.Description, p.Price, c.CategoryName FROM Products WHERE p.Id = @ProductId
                            JOIN Categories c ON p.CategoryId = c.Id
                */


             var _category = await _context.Categories.FirstOrDefaultAsync(x => x.Name == product.CategoryName);
                if (_category == null)
                {
                    var item = new ProductEntity
                    {
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price,
                        Category = new CategoryEntity { Name = product.CategoryName }
                    };
                    _context.Products.Add(item);
                    await _context.SaveChangesAsync();

                    return new Product
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description,
                        Price = item.Price,
                        CategoryName = item.Category.Name
                    };
                }
                else
                {
                    var item = new ProductEntity
                    {
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price,
                        CategoryId = _category.Id
                    };
                    _context.Products.Add(item);
                    await _context.SaveChangesAsync();

                    return new Product
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description,
                        Price = item.Price,
                        CategoryName = item.Category.Name
                    };
                }

            }

            public async Task<IEnumerable<Product>> GetAllProductsAsync()
            {
                var products = new List<Product>();

                foreach (var item in await _context.Products.Include(x => x.Category).ToListAsync())
                    products.Add(new Product
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description,
                        Price = item.Price,
                        CategoryName = item.Category.Name
                    });

                return products;
            }
        }
    }



