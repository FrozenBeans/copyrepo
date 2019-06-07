using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface ILocationRepository
    {
        IEnumerable<Domain.ResLocation> GetRestaurants();

        /// <summary>
        /// Get a restaurant
        /// </summary>
        /// <param name="ResName">The restaurant</param>
        ResLocation GetRestaurantById(int id);

        /// <summary>
        /// Add a restaurant
        /// </summary>
        /// <param name="ResName">The restaurant</param>
        void AddLocation(ResLocation location);

        /// <summary>
        /// Delete a restaurant by ID
        /// </summary>
        /// <param name="locationId">The ID of the restaurant</param>
        void DeleteLocation(int locationId);

        /// <summary>
        /// Update a restaurant
        /// </summary>
        /// <param name="ResName">The restaurant with changed values</param>
        void UpdateLocation(ResLocation location);
        //-------------------------------------------------------------------------------------------------------------------

        void Save();
    }

}
