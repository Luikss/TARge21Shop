using TARge21Shop.Core.Domain;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;
using Xunit;

namespace TARge21Shop.SpaceshipTest
{
    public class SpaceshipTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptySpaceship_WhenReturnResult()
        {
            SpaceshipDto spaceship = createSpaceshipDto();
            var result = await Svc<ISpaceshipsServices>().Create(spaceship);
            assertSpaceships(spaceship, result);
        }

        internal void assertSpaceships(SpaceshipDto expected, Spaceship actual)
        {
            Assert.NotNull(actual.Id);
            Assert.NotNull(actual.CreatedAt);
            Assert.NotNull(actual.ModifiedAt);
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Type, actual.Type);
            Assert.Equal(expected.Crew, actual.Crew);
            Assert.Equal(expected.Passengers, actual.Passengers);
            Assert.Equal(expected.CargoWeight, actual.CargoWeight);
            Assert.Equal(expected.FullTripsCount, actual.FullTripsCount);
            Assert.Equal(expected.MaintenanceCount, actual.MaintenanceCount);
            Assert.Equal(expected.LastMaintenance, actual.LastMaintenance);
            Assert.Equal(expected.EnginePower, actual.EnginePower);
            Assert.Equal(expected.MaidenLaunch, actual.MaidenLaunch);
            Assert.Equal(expected.BuiltDate, actual.BuiltDate);
        }

        public static SpaceshipDto createSpaceshipDto()
        {
            SpaceshipDto spaceship = new SpaceshipDto();
            spaceship.Name = "asd";
            spaceship.Type = "asd";
            spaceship.Crew = 123;
            spaceship.Passengers = 123;
            spaceship.CargoWeight = 123;
            spaceship.FullTripsCount = 123;
            spaceship.MaintenanceCount = 123;
            spaceship.LastMaintenance = DateTime.Now;
            spaceship.EnginePower = 123;
            spaceship.MaidenLaunch = DateTime.Now;
            spaceship.BuiltDate = DateTime.Now;

            return spaceship;
        }
    }
}
