namespace _00_Repetition_EntityFramework.Models
{
    /*
         SELECT p.Id, p.Name, p.Description, p.Price, c.Name FROM Products p
         JOIN Categories c ON p.CategoryId = c.Id
     */
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
    }
}
