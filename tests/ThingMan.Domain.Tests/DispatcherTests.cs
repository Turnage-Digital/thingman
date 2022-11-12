using FluentAssertions;
using ThingMan.Core;
using ThingMan.Core.Events;
using Xunit;

namespace ThingMan.Domain.Tests;

public class DispatcherTests
{
    [Fact]
    public async Task AddedEventHandler_IsHandled()
    {
        // Arrange
        var eventHandler = new TestEventHandler();

        // Act
        Dispatcher.Register(eventHandler);
        await Dispatcher.RaiseAsync(new TestEvent1());

        // Assert
        eventHandler.IsHandled.Should().BeTrue();
    }

    [Fact]
    public async Task AddedEventHandler_IsNotHandled()
    {
        // Arrange
        var eventHandler = new TestEventHandler();

        // Act
        Dispatcher.Register(eventHandler);
        await Dispatcher.RaiseAsync(new TestEvent2());

        // Assert
        eventHandler.IsHandled.Should().BeFalse();
    }

    private class TestEvent1 : IEvent
    {
        public Guid TraceId { get; set; } = Guid.NewGuid();
    }

    private class TestEvent2 : IEvent
    {
        public Guid TraceId { get; set; } = Guid.NewGuid();
    }

    private class TestEventHandler : IHandleEvent<TestEvent1>
    {
        public bool IsHandled { get; private set; }

        public Task<CoreResponse> HandleAsync(TestEvent1 @event)
        {
            IsHandled = true;
            return Task.FromResult(CoreResponse.Success);
        }

        public string Name => "TestEventHandler";
    }
}