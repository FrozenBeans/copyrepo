using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace PizzaWebApp.Models
{
    public class Inventory
    {//inventory
        public int invId { get; set; }
        public int? resfId { get; set; }
        public int? FkIngredient { get; set; }
        [DisplayName("Price")]
        public decimal? cost_inv { get; set; }
        public int? stock { get; set; }
    }
    public class Ingredients
    {
        //ingredients
        public int ingId { get; set; }
        [DisplayName("Topping")]
        public string ingredient { get; set; }
        [DisplayName("Price")]
        public decimal? cost_ing { get; set; }

    }
    public class Indiv_pizza
    {
        //indiv pizza
        [DisplayName("PizzaId")]
        public int pizzaId { get; set; }
        [DisplayName("Topping 1")]
        public string Ingredient0FID { get; set; }
        [DisplayName("Topping 2")]
        public string Ingredient1FID { get; set; }
        [DisplayName("Topping 3")]
        public string Ingredient2FID { get; set; }
        [DisplayName("Topping 4")]
        public string Ingredient3FID { get; set; }
        [DisplayName("Topping 5")]
        public string Ingredient4FID { get; set; }
        [DisplayName("Crust")]
        public string crustFID { get; set; }
        [DisplayName("Size")]
        public string sizeFID { get; set; }
        [DisplayName("Number of pizzas:")]  
        [Required(ErrorMessage = "Value cannot be empty")]
        [Range(1,100)]
        public int? count { get; set; }
        [DisplayName("Order Number")]
        public int? orderFID { get; set; }
        [DisplayName("Total Cost")]
        public decimal? totalcost { get; set; }
        public List<SelectListItem> ingredientlist { get; } = new List<SelectListItem>
        {
        new SelectListItem { Value = "none", Text = "Empty" },
        new SelectListItem { Value = "chicken", Text = "Chicken +$1.25" },
        new SelectListItem { Value = "steak", Text = "Steak +$1.50"  },
        new SelectListItem { Value = "bacon", Text = "Bacon +$1.25"  },
        new SelectListItem { Value = "pepperoni", Text = "Pepperoni +$1.25"  },
        new SelectListItem { Value = "proscuitto", Text = "Proscuitto +$1.75"  },
        new SelectListItem { Value = "tomatoes", Text = "Tomatoes +$1.25"  },
        new SelectListItem { Value = "garlic", Text = "Garlic +$1.00"  },
        new SelectListItem { Value = "onions", Text = "Onions +$1.00"  },
        new SelectListItem { Value = "bell peppers", Text = "Bell Peppers +$1.00"  },
        new SelectListItem { Value = "ham", Text = "Ham +$1.25"  },
        };

        //crust
        public int crustId { get; set; }
        [DisplayName("Crust")]
        public string crust1 { get; set; }

        [DisplayName("Price")]
        public decimal? totalcost_crust { get; set; }
        public List<SelectListItem> crustlist { get; } = new List<SelectListItem>
    {
        new SelectListItem { Value = "regular", Text = "Regular +$0.00" },
        new SelectListItem { Value = "thin", Text = "Thin +$.75" },
        new SelectListItem { Value = "garlic", Text = "Garlic +$1.00"  },
        new SelectListItem { Value = "cheesy", Text = "Cheesy +$1.00"}
    };

        public int sizeId { get; set; }
        [DisplayName("Size")]
        public string size1 { get; set; }
        [DisplayName("Price")]
        public decimal? totalcost_size { get; set; }

        public List<SelectListItem> sizelist { get; } = new List<SelectListItem>
    {
        new SelectListItem { Value = "small", Text = "Small +$4.00" },
        new SelectListItem { Value = "medium", Text = "Medium +$5.00" },
        new SelectListItem { Value = "large", Text = "Large +$6.50"  },

    };

    }

    public class Orderpizza
    {
        //order pizza
        [DisplayName("Order Id")]
        public int orderid { get; set; }
        public int? locationfid_op { get; set; }
        public int? userFID { get; set; }
        public DateTime? Timecheck { get; set; }
        public DateTime? Timecheckdefault { get; set; }
    }
}
