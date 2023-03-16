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
            SpaceshipDto spaceship = CreateSpaceshipDto();
            var result = await Svc<ISpaceshipsServices>().Create(spaceship);
            AssertSpaceships(spaceship, result);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Assertions", "xUnit2002:Do not use null check on value type", Justification = "<Pending>")]
        internal static void AssertSpaceships(SpaceshipDto expected, Spaceship actual)
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

        public static SpaceshipDto CreateSpaceshipDto()
        {
            SpaceshipDto spaceship = new()
            {
                Name = "asd",
                Type = "asd",
                Crew = 123,
                Passengers = 123,
                CargoWeight = 123,
                FullTripsCount = 123,
                MaintenanceCount = 123,
                LastMaintenance = DateTime.Now,
                EnginePower = 123,
                MaidenLaunch = DateTime.Now,
                BuiltDate = DateTime.Now
            };

            return spaceship;
        }
    }
}
