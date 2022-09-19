using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _00_Repetition_EntityFramework.Models.Entities
{
   
    /*  
        CREATE TABLE Products (
            Id int not null identity primary key,
            Name nvarchar(50) not null,
            Description nvarchar(max) null,
            Price decimal not null,
            CategoryId int not null references Categories(Id)
        ) 
    */
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }


        [Required, Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string? Description { get; set; }

        [Required, Column(TypeName = "decimal")]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }

    }
}
