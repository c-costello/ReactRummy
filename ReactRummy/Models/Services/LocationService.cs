using Microsoft.EntityFrameworkCore;
using ReactRummy.Data;
using ReactRummy.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactRummy.Models.Services
{
    public class LocationService : ILocation
    {
        private readonly GameDbContext _Context;

        public LocationService(GameDbContext context)
        {
            _Context = context;
        }

        public async Task CreateLocation(Location location)
        {
            _Context.Locations.Add(location);
            await _Context.SaveChangesAsync();
        }

        public async Task DeleteLocation(int id)
        {
            Location location = await _Context.Locations.FirstOrDefaultAsync(l => l.ID == id);
            _Context.Locations.Remove(location);
            await _Context.SaveChangesAsync();
        }

        public async Task<Location> GetLocation(int id)
        {
            Location location = await _Context.Locations.FirstOrDefaultAsync(l => l.ID == id);
            return location;
        }

        public async Task<IEnumerable<Location>> GetLocations()
        {
            IEnumerable<Location> locations = await _Context.Locations.ToListAsync();
            return locations;
        }

        public async Task UpdateLocation(Location location)
        {
            _Context.Locations.Update(location);
            await _Context.SaveChangesAsync();
        }
    }
}
