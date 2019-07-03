using System;
using Xunit;
using ReactRummy.Models;
using Microsoft.EntityFrameworkCore;
using ReactRummy.Data;
using ReactRummy.Models.Services;

namespace ReactRummyTests.CRUD
{
    public class LocationCRUD
    {
        [Fact]
        public async void CanCreateLocation()
        {
            DbContextOptions<GameDbContext> options = new DbContextOptionsBuilder<GameDbContext>().UseInMemoryDatabase("text").Options;
            using (GameDbContext context = new GameDbContext(options))
            {
                LocationService locationService = new LocationService(context);
                Location location = new Location();
                await locationService.CreateLocation(location);
                var actual = await context.Locations.FirstOrDefaultAsync(l => l.ID == location.ID);
                Assert.Equal(location, actual);
            }
        }

        [Fact]
        public async void CanUpdateLocation()
        {
            DbContextOptions<GameDbContext> options = new DbContextOptionsBuilder<GameDbContext>().UseInMemoryDatabase("text").Options;
            using (GameDbContext context = new GameDbContext(options))
            {
                LocationService locationService = new LocationService(context);
                Location location = new Location();
                location.GameID = 4;
                await locationService.CreateLocation(location);
                location.GameID = 5;
                await locationService.UpdateLocation(location);
                var actual = await context.Locations.FirstOrDefaultAsync(l => l.ID == location.ID);
                Assert.Equal(location, actual);
            }
        }

        [Fact]
        public async void CanDeleteLocation()
        {
            DbContextOptions<GameDbContext> options = new DbContextOptionsBuilder<GameDbContext>().UseInMemoryDatabase("text").Options;
            using (GameDbContext context = new GameDbContext(options))
            {
                LocationService locationService = new LocationService(context);
                Location location = new Location();
                await locationService.CreateLocation(location);
                await locationService.DeleteLocation(location.ID);
                var actual = await context.Locations.FirstOrDefaultAsync(l => l.ID == location.ID);
                Assert.Null(actual);
            }
        }
        [Fact]
        public async void CanGetLocation()
        {
            DbContextOptions<GameDbContext> options = new DbContextOptionsBuilder<GameDbContext>().UseInMemoryDatabase("text").Options;
            using (GameDbContext context = new GameDbContext(options))
            {
                LocationService locationService = new LocationService(context);
                Location location = new Location();
                await locationService.CreateLocation(location);
                var expected = await context.Locations.FirstOrDefaultAsync(l => l.ID == location.ID);
                var actual = await locationService.GetLocation(location.ID);
                Assert.Equal(expected, actual);
            }
        }
        [Fact]
        public async void CanGetLocations()
        {
            DbContextOptions<GameDbContext> options = new DbContextOptionsBuilder<GameDbContext>().UseInMemoryDatabase("text").Options;
            using (GameDbContext context = new GameDbContext(options))
            {
                LocationService locationService = new LocationService(context);
                Location location = new Location();
                await locationService.CreateLocation(location);
                var expected = await context.Locations.ToListAsync();
                var actual = await locationService.GetLocations();
                Assert.Equal(expected, actual);
            }
        }
    }

  
}
