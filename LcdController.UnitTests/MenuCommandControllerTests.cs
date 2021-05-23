using FluentAssertions;
using LcdController.Lib;
using NSubstitute;
using Xunit;

namespace LcdController.UnitTests
{
    public class MenuCommandControllerTests
    {
        [Theory]
        [InlineData(-1, MenuCommand.Down)]
        [InlineData(0, MenuCommand.Down)]
        [InlineData(49, MenuCommand.Down)]
        [InlineData(50, MenuCommand.Up)]
        [InlineData(194, MenuCommand.Up)]
        [InlineData(195, MenuCommand.None)]
        [InlineData(1000, MenuCommand.None)]
        public void Should_ReadCommand_ReturnsTheExpectedCommandFromTheMicroController(int signal, MenuCommand expected)
        {
            // Arrange
            var microController = Substitute.For<IMicroController>();
            microController.AnalogRead(Arg.Any<int>()).Returns(signal);

            var sut = new MenuCommandController(microController);

            // Act
            var actual = sut.ReadCommand();

            // Assert
            actual.Should().Be(expected);
        }
    }
}