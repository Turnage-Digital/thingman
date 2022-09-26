using Boogops.Core.MongoDB.Entities;
using Boogops.Core.MongoDB.Repositories;
using FluentAssertions;
using MongoDB.Driver;
using Moq;
using Xunit;

namespace Boogops.Core.MongoDB.Tests;

public class ThingDefRepositoryTests
{
    private readonly Mock<IMongoCollectionFacade<ThingDef>> _mongoCollectionMock;
    private readonly ThingDefsRepository<ThingDef> _thingDefsRepository;

    public ThingDefRepositoryTests()
    {
        _mongoCollectionMock = new Mock<IMongoCollectionFacade<ThingDef>>();

        var findFluentMock = new Mock<IFindFluentFacade<ThingDef>>();
        findFluentMock.Setup(x => x.SingleAsync())
            .ReturnsAsync(new ThingDef { Id = "1" });
        _mongoCollectionMock.Setup(x => x.Find(It.IsAny<FilterDefinition<ThingDef>>()))
            .Returns(findFluentMock.Object);
        _mongoCollectionMock.Setup(x => x.InsertOneAsync(It.IsAny<ThingDef>()))
            .Returns(Task.CompletedTask);
        
        var getThingDefsMongoCollectionMock = new Mock<IGetThingDefsMongoCollection<ThingDef>>();
        getThingDefsMongoCollectionMock.Setup(x => x.Get())
            .Returns(_mongoCollectionMock.Object);

        _thingDefsRepository = new ThingDefsRepository<ThingDef>(getThingDefsMongoCollectionMock.Object);
    }

    [Fact]
    public async Task Create_CreatesThingDef()
    {
        // Arrange
        var thingDef = new ThingDef { Id = "Bo Bandy" };

        // Act
        var documentResult = await _thingDefsRepository.CreateAsync(thingDef);

        // Assert
        _mongoCollectionMock.Verify(x => x.InsertOneAsync(thingDef), Times.Once);
        documentResult.Succeeded.Should().BeTrue();
    }

    [Fact]
    public async Task Find_FindsThingDef()
    {
        // Arrange
        const string id = "Bo Bandy";

        // Act
        var found = await _thingDefsRepository.ReadAsync(id);

        // Assert
        _mongoCollectionMock.Verify(
            x => x.Find(It.IsAny<FilterDefinition<ThingDef>>()), Times.Once);
        found.Should().NotBeNull();
    }
}