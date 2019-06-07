using Data.Models;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Data
{
    public class LocationRepository : ILocationRepository
    {
        private readonly pizzadb_gtContext _db;
        public LocationRepository(pizzadb_gtContext db)
        {
            _db = db;
        }
        public IEnumerable<Domain.ResLocation> GetRestaurants()
        {
            return _db.ResLocation.Select(x => Mapper.Map(x));

        }
        public Domain.ResLocation GetRestaurantById(int id)
        {
            return Mapper.Map(_db.ResLocation.Find(id));
        }
        public void AddLocation(Domain.ResLocation location)
        {
            _db.ResLocation.Add(Mapper.Map(location));
        }
        public void DeleteLocation(int locationId)
        {
            _db.ResLocation.Remove(_db.ResLocation.Find(locationId));
        }   
        public void UpdateLocation(Domain.ResLocation location)
        {
            _db.ResLocation.Update(Mapper.Map(location));
        }
        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
