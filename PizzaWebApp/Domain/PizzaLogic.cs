using System;
using System.Collections.Generic;
using System.Linq;


namespace Domain
{

    public class Crust
    {
        //crust
        public int crustId { get; set; }
        public string crust1 { get; set; }
        public decimal? totalcost_crust { get; set; }
    }
    public class Size
    {//size
        public int sizeId { get; set; }
        public string size1 { get; set; }
        public decimal? totalcost_size { get; set; }
    }
    public class Inventory
    {//inventory
        public int invId { get; set; }
        public int? resfId { get; set; }
        public int? FkIngredient { get; set; }
        public decimal? cost_inv { get; set; }
        public int? stock { get; set; }
    }
    public class Ingredients
    {
        //ingredients
        public int ingId { get; set; }
        public string ingredient { get; set; }
        public decimal? cost_ing { get; set; }
    }
    public class Indiv_pizza
    {
        //indiv pizza
        public int pizzaId { get; set; }
        public int? Ingredient0FID { get; set; }
        public int? Ingredient1FID { get; set; }
        public int? Ingredient2FID { get; set; }
        public int? Ingredient3FID { get; set; }
        public int? Ingredient4FID { get; set; }
        public int? crustFID { get; set; }
        public int? sizeFID { get; set; }
        public int? count { get; set; }
        public int? orderFID { get; set; }
        public decimal? totalcost { get; set; }


    }
    public class Orderpizza
    {
        //order pizza
        public int orderid { get; set; }
        public int? locationfid_op { get; set; }
        public int? userFID { get; set; }
        public DateTime? Timecheck { get; set; }
        public DateTime? Timecheckdefault { get; set; }
    }

}
