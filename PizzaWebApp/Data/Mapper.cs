using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    class Mapper
    {
        public static Data.Models.UserInfo Map(Domain.UserInfo dmUserInfo)
        {
            Data.Models.UserInfo deUserInfo = new Models.UserInfo();
            deUserInfo.UserId = dmUserInfo.userId;
            deUserInfo.FirstName = dmUserInfo.firstname;
            deUserInfo.LastName = dmUserInfo.lastname;
            deUserInfo.Password = dmUserInfo.password;
            deUserInfo.PhoneNumber = dmUserInfo.phonenumber;
            deUserInfo.UserName = dmUserInfo.username;


            return deUserInfo;
        }
        public static Domain.UserInfo Map(Data.Models.UserInfo deUserInfo) => new Domain.UserInfo
        {
            userId = deUserInfo.UserId,
            firstname = deUserInfo.FirstName,
            lastname = deUserInfo.LastName,
            password = deUserInfo.Password,
            phonenumber = deUserInfo.PhoneNumber,
            username = deUserInfo.UserName

        };
        public static Data.Models.ResLocation Map(Domain.ResLocation dmResLocation)
        {
            Data.Models.ResLocation deResLocation = new Models.ResLocation();
            deResLocation.City = dmResLocation.City;
            deResLocation.LocationId = dmResLocation.locationID;
            deResLocation.ResName = dmResLocation.ResName;
            deResLocation.State = dmResLocation.State;
            deResLocation.Zipcode = dmResLocation.Zipcode;

            return deResLocation;
        }
        public static Domain.ResLocation Map(Data.Models.ResLocation deResLocation) => new Domain.ResLocation
        {
            City = deResLocation.City,
            locationID = deResLocation.LocationId,
            ResName = deResLocation.ResName,
            State = deResLocation.State,
            Zipcode = deResLocation.Zipcode
        };
        public static Data.Models.Crust Map(Domain.Crust dmCrust)
        {
            Data.Models.Crust deCrust = new Models.Crust();
            deCrust.Crust1 = dmCrust.crust1;
            deCrust.CrustId = dmCrust.crustId;
            deCrust.Totalcost = dmCrust.totalcost_crust;

            return deCrust;
        }
        public static Domain.Crust Map(Data.Models.Crust deCrust) => new Domain.Crust
        {
            crustId = deCrust.CrustId,
            crust1 = deCrust.Crust1,
            totalcost_crust = deCrust.Totalcost
        };
        public static Data.Models.Size Map(Domain.Size dmSize)
        {
            Data.Models.Size deSize = new Models.Size();
            deSize.Size1 = dmSize.size1;
            deSize.SizeId= dmSize.sizeId;
            deSize.Totalcost = dmSize.totalcost_size;

            return deSize;
        }
        public static Domain.Size Map(Data.Models.Size deSize) => new Domain.Size
        {
            sizeId = deSize.SizeId,
            size1 = deSize.Size1,
            totalcost_size = deSize.Totalcost
        };
        public static Data.Models.Inventory Map(Domain.Inventory dmInv)
        {
            Data.Models.Inventory deInv = new Models.Inventory();
            deInv.Invid = dmInv.invId;
            deInv.FkIngredient = dmInv.FkIngredient;
            deInv.Resfid = dmInv.resfId;
            deInv.Cost = dmInv.cost_inv;
            deInv.Stock = dmInv.stock;

            return deInv;
        }
        public static Domain.Inventory Map(Data.Models.Inventory deInv) => new Domain.Inventory
        {
            invId = deInv.Invid,
            cost_inv = deInv.Cost,
            FkIngredient = deInv.FkIngredient,
            resfId = deInv.Resfid,
            stock = deInv.Stock
        };
        public static Data.Models.Ingredients Map(Domain.Ingredients dmIng)
        {
            Data.Models.Ingredients deIng = new Models.Ingredients();
            deIng.IngId = dmIng.ingId;
            deIng.Ingredient = dmIng.ingredient;
            deIng.Cost = dmIng.cost_ing;

            return deIng;
        }
        public static Domain.Ingredients Map(Data.Models.Ingredients deIng) => new Domain.Ingredients
        {
            ingId = deIng.IngId,
            ingredient = deIng.Ingredient,
            cost_ing = deIng.Cost
        };
        public static Data.Models.IndivPizza Map(Domain.Indiv_pizza dmIndP)
        {
            Data.Models.IndivPizza deIndP = new Models.IndivPizza();
            deIndP.PizzaId = dmIndP.pizzaId;
            deIndP.Ingredient0Fid = dmIndP.Ingredient0FID;
            deIndP.Ingredient1Fid = dmIndP.Ingredient1FID;
            deIndP.Ingredient2Fid = dmIndP.Ingredient2FID;
            deIndP.Ingredient3Fid = dmIndP.Ingredient3FID;
            deIndP.Ingredient4Fid = dmIndP.Ingredient4FID;
            deIndP.CrustFid = dmIndP.crustFID;
            deIndP.SizeFid = dmIndP.sizeFID;
            deIndP.Count = dmIndP.count;
            deIndP.OrderFid = dmIndP.orderFID;
            deIndP.Totalcost = dmIndP.totalcost;

            return deIndP;
        }
        public static Domain.Indiv_pizza Map(Data.Models.IndivPizza deIndP) => new Domain.Indiv_pizza
        {
            pizzaId = deIndP.PizzaId,
            Ingredient0FID = deIndP.Ingredient0Fid,
            Ingredient1FID = deIndP.Ingredient1Fid,
            Ingredient2FID = deIndP.Ingredient2Fid,
            Ingredient3FID = deIndP.Ingredient3Fid,
            Ingredient4FID = deIndP.Ingredient4Fid,
            crustFID = deIndP.CrustFid,
            sizeFID = deIndP.SizeFid,
            count = deIndP.Count,
            orderFID = deIndP.OrderFid,
            totalcost = deIndP.Totalcost
        };
        public static Data.Models.Orderpizza Map(Domain.Orderpizza dmOP){
            Data.Models.Orderpizza deOP = new Models.Orderpizza();
            deOP.OrderId = dmOP.orderid;
            deOP.LocationFid = dmOP.locationfid_op;
            deOP.UserFid = dmOP.userFID;
            deOP.Timecheck = dmOP.Timecheck;
            deOP.Timecheckdefault = dmOP.Timecheckdefault;

            return deOP;
        }
        public static Domain.Orderpizza Map(Data.Models.Orderpizza deOP) => new Domain.Orderpizza
        {
            orderid = deOP.OrderId,
            locationfid_op = deOP.LocationFid,
            userFID = deOP.UserFid,
            Timecheck = deOP.Timecheck,
            Timecheckdefault = deOP.Timecheckdefault
        };
        


    }
}
