using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Models
{
    public class FoodCategoryViewModel
    {
        public FoodItem FoodItem { get; set; }
        public List<Category> Categories { get; set; }
    }
}