using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Models
{
    public class FoodItem
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Please Enter Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please Enter Price")]
        public double Price { get; set; }

        [Required(ErrorMessage ="Please select Category")]
        [ForeignKey("Category")]
        [Display(Name ="Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}