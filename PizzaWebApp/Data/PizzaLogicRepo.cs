using Data.Models;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class PizzaLogicRepo :IPizzaLogicRepo
    {
        private readonly pizzadb_gtContext _db;

        public PizzaLogicRepo(pizzadb_gtContext db)
        {
            _db = db;
        }
        public int? IngredientStringToId(string name)
        {
            return _db.Ingredients.Where(x => x.Ingredient == name).FirstOrDefault().IngId;
        }
        public int? SizeStringToID(string name)
        {
            return _db.Size.Where(x => x.Size1 == name).FirstOrDefault().SizeId;
        }
        public int? CrustStringToID(string name)
        {
            return _db.Crust.Where(x => x.Crust1 == name).FirstOrDefault().CrustId;
        }
        public IEnumerable<Domain.Crust> getCrusts()
        {
            return _db.Crust.Select(x => Mapper.Map(x));
        }
        public IEnumerable<Domain.Size> getSizes()
        {
            return _db.Size.Select(x => Mapper.Map(x));
        }
        public IEnumerable<Domain.Inventory> getInventory()
        {
            return _db.Inventory.Select(x => Mapper.Map(x));
        }

        public IEnumerable<Domain.Ingredients> getIngredients()
        {
            return _db.Ingredients.Select(x => Mapper.Map(x));
        }
            
        public Domain.Ingredients getIngredientsById(int? ingId)
        {
            return Mapper.Map(_db.Ingredients.Find(ingId));
        }
        public Domain.Crust getCrustById(int? crustId)
        {
            return Mapper.Map(_db.Crust.Find(crustId));
        }
        public Domain.Size getSizeById(int? sizeId)
        {
            return Mapper.Map(_db.Size.Find(sizeId));
        }
        public void AddPizza(Indiv_pizza inPizza)
        {
            _db.IndivPizza.Add(Mapper.Map(inPizza));
        }
        public void RemovePizza(Indiv_pizza inPizza)
        {
            _db.IndivPizza.Remove(Mapper.Map(inPizza));
        }

        public void AddOrder(Domain.Orderpizza order)
        {
            _db.Orderpizza.Add(Mapper.Map(order));
        }
        public void RemoveOrder(Domain.Orderpizza order)
        {
            _db.Orderpizza.Remove(Mapper.Map(order));
        }
        public void UpdateOrder(Domain.Orderpizza order)
        {
            _db.Orderpizza.Update(Mapper.Map(order));
        }

        public void UpdateStock(Domain.Inventory inv)
        {
            _db.Inventory.Update(Mapper.Map(inv));
        }
        public int getNextOrderId()
        {
            return Mapper.Map(_db.Orderpizza.Last()).orderid;
        }
        public IEnumerable<Domain.Orderpizza> getOrders()
        {
            return _db.Orderpizza.Select(x => Mapper.Map(x));
        }
        public IEnumerable<Domain.Indiv_pizza> getPizzas()
        {
            return _db.IndivPizza.Select(x => Mapper.Map(x));
        }

        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
