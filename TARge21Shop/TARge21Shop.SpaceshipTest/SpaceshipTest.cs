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

        [Fact]
        public async Task ShouldNot_GetByIdSpaceship_WhenReturnsNotEqual()
        {
            Assert.Null(await Svc<ISpaceshipsServices>().GetAsync(Guid.NewGuid()));
        }

        [Fact]
        public async Task Should_GetByIdSpaceship_WhenReturnsEqual()
        {
            SpaceshipDto spaceship = CreateSpaceshipDto();
            var createdSpaceship = await Svc<ISpaceshipsServices>().Create(spaceship);
            var recivedSpaceship = await Svc<ISpaceshipsServices>().GetAsync((Guid)createdSpaceship.Id);
            AssertSpaceships(spaceship, recivedSpaceship);
        }

        [Fact]
        public async Task Should_DeleteByIdSpaceship_WhenDeleteSpaceship()
        {
            SpaceshipDto spaceship = CreateSpaceshipDto();
            var createdSpaceship = await Svc<ISpaceshipsServices>().Create(spaceship);
            var recivedSpaceship = await Svc<ISpaceshipsServices>().GetAsync((Guid)createdSpaceship.Id);
            AssertSpaceships(spaceship, recivedSpaceship);

            var deletedSpaceship = await Svc<ISpaceshipsServices>().Delete((Guid)createdSpaceship.Id);
            AssertSpaceships(spaceship, deletedSpaceship);
            Assert.Null(await Svc<ISpaceshipsServices>().GetAsync((Guid)createdSpaceship.Id));
        }

        [Fact]
        public async Task Should_UpdateSpaceship_WhenDtoValid()
        {
            SpaceshipDto spaceship = CreateSpaceshipDto();
            var createdSpaceship = await Svc<ISpaceshipsServices>().Create(spaceship);
            var recivedSpaceship = await Svc<ISpaceshipsServices>().GetAsync((Guid)createdSpaceship.Id);
            AssertSpaceships(spaceship, recivedSpaceship);

            spaceship = UpdateDto(spaceship);
            var recivedUpdatedSpaceship = await Svc<ISpaceshipsServices>().Update(spaceship);
            AssertSpaceships(spaceship, recivedUpdatedSpaceship);
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

        public static SpaceshipDto UpdateDto(SpaceshipDto spaceship)
        {
            SpaceshipDto newSpaceship = spaceship;
            newSpaceship.Name = "dsa";
            newSpaceship.Type = "dsa";
            newSpaceship.Crew = 321;
            newSpaceship.Passengers = 321;
            newSpaceship.CargoWeight = 321;
            newSpaceship.FullTripsCount = 321;
            newSpaceship.MaintenanceCount = 321;
            newSpaceship.LastMaintenance = DateTime.Now.AddYears(1);
            newSpaceship.EnginePower = 321;
            newSpaceship.MaidenLaunch = DateTime.Now.AddYears(1);
            newSpaceship.BuiltDate = DateTime.Now.AddYears(1);

            return spaceship;
        }
    }
}
