using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public FoodItem ItemInCart { get; set; }
    }
}