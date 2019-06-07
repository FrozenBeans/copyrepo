using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IPizzaLogicRepo
    {
        IEnumerable<Domain.Crust> getCrusts();
        IEnumerable<Domain.Size> getSizes();
        IEnumerable<Domain.Inventory> getInventory();
        IEnumerable<Domain.Ingredients> getIngredients();
        IEnumerable<Domain.Orderpizza> getOrders();
        IEnumerable<Domain.Indiv_pizza> getPizzas();
        int? IngredientStringToId(string name);
        Ingredients getIngredientsById(int? ingId);
        Crust getCrustById(int? crustId);
        Size getSizeById(int? sizeId);
        int? SizeStringToID(string name);
        int? CrustStringToID(string name);
        int getNextOrderId();


        void AddPizza(Indiv_pizza inPizza);
        void RemovePizza(Indiv_pizza inPizza);

        void AddOrder(Orderpizza order);
        void RemoveOrder(Orderpizza order);
        void UpdateOrder(Orderpizza order);
        void UpdateStock(Inventory inv);
        void Save();

    }
}
