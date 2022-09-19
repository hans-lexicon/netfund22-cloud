using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _00_Repetition_EntityFramework.Models.Entities
{
  
        /*  
       CREATE TABLE Categories (
           Id int not null identity primary key,
           Name nvarchar(50) not null
       ) 
   */

        public class CategoryEntity
        {
            [Key]
            public int Id { get; set; }

            [Required, Column(TypeName = "nvarchar(50)")]
            public string? Name { get; set; }

            public ICollection<ProductEntity> Products { get; set; }
        }
    }

