using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactRummy.Models.Interfaces
{
    public interface ILocation 
    {
        Task<Location> GetLocation(int id);
        Task<IEnumerable<Location>> GetLocations();
        Task CreateLocation(Location location);
        Task DeleteLocation(int id);
        Task UpdateLocation(Location location);
    }
}
