using System;
using System.Reflection;
using LcdController.Lib;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using Xunit;

namespace LcdController.UnitTests
{
    public class LiquidCrystalExtensionsTests
    {
        [Fact]
        public void Should_CreateUp_AddUpCommandToLiquidCrystal()
        {
            // Arrange
            var lcd = Substitute.For<ILiquidCrystal>();

            // Act
            lcd.CreateUp();

            // Assert
            lcd.Received(1).CreateChar(2, LiquidCrystalExtensions.UpArrow);
        }
        
        [Fact]
        public void Should_CreateDown_AddDownCommandToLiquidCrystal()
        {
            // Arrange
            var lcd = Substitute.For<ILiquidCrystal>();

            // Act
            lcd.CreateDown();

            // Assert
            lcd.Received(1).CreateChar(1, LiquidCrystalExtensions.DownArrow);
        }
    }
}