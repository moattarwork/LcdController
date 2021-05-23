using FluentAssertions;
using LcdController.Lib;
using NSubstitute;
using Xunit;

namespace LcdController.UnitTests
{
    public class MenuTests
    {
        [Fact]
        public void Should_InitialiseCorrectly()
        {
            // Arrange
            var lcd = Substitute.For<ILiquidCrystal>();
            var menuItems = new[] {"START CAPTURE", "START SHOWCASE" ,"PRESETS"};

            // Act
            var sut = new Menu(lcd, menuItems);

            // Assert
            sut.MenuPage.Should().Be(0);
            sut.MaxMenuPages.Should().Be(1);
        }
        
        [Fact]
        public void Should_Draw_DrawTheMenuItemsAndCommandsCorrectly()
        {
            // Arrange
            var lcd = Substitute.For<ILiquidCrystal>();
            var menuItems = new[] {"START CAPTURE", "START SHOWCASE" ,"PRESETS", "SET TRIGGER", "SETTINGS", "ABOUT"};

            var sut = new Menu(lcd, menuItems);

            // Act
            sut.Draw();

            // Assert
            lcd.Received(1).Clear();
            lcd.Received(1).Print(menuItems[0]);
            lcd.Received(1).Print(menuItems[1]);
            lcd.Received(1).Write((byte)MenuCommand.Up);
        }
        
        [Fact]
        public void Should_PageUp_DrawTheCommandsCorrectly_WhenMenuPageIsZero()
        {
            // Arrange
            var lcd = Substitute.For<ILiquidCrystal>();
            var menuItems = new[] {"START CAPTURE", "START SHOWCASE" ,"PRESETS", "SET TRIGGER", "SETTINGS", "ABOUT"};

            var sut = new Menu(lcd, menuItems);

            // Act
            sut.PageUp();

            // Assert
            sut.MenuPage.Should().Be(1);
            lcd.Received(1).Clear();
            lcd.Received(1).Print(menuItems[1]);
            lcd.Received(1).Print(menuItems[2]);
            lcd.Received(1).Write((byte)MenuCommand.Up);
            lcd.Received(1).Write((byte)MenuCommand.Down);
        }
        
        [Fact]
        public void Should_PageUp_DrawTheCommandsCorrectly_WhenMenuPageIsBiggerThanZeroButNotTheLastMenuItem()
        {
            // Arrange
            var lcd = Substitute.For<ILiquidCrystal>();
            var menuItems = new[] {"START CAPTURE", "START SHOWCASE" ,"PRESETS", "SET TRIGGER", "SETTINGS", "ABOUT"};

            var sut = new Menu(lcd, menuItems);

            // Act
            sut.PageUp();
            sut.PageUp();

            // Assert
            sut.MenuPage.Should().Be(2);
            lcd.Received(2).Clear();
            lcd.Received(1).Print(menuItems[1]);
            lcd.Received(2).Print(menuItems[2]);
            lcd.Received(1).Print(menuItems[3]);
            lcd.Received(2).Write((byte)MenuCommand.Up);
            lcd.Received(2).Write((byte)MenuCommand.Down);
        }
        
        [Fact]
        public void Should_PageDown_DrawTheCommandsCorrectly_WhenMenuPageIsTheLastMenuItem()
        {
            // Arrange
            var lcd = Substitute.For<ILiquidCrystal>();
            var menuItems = new[] {"START CAPTURE", "START SHOWCASE","PRESETS"};

            var sut = new Menu(lcd, menuItems);

            // Act
            sut.PageUp();
            sut.PageUp();

            // Assert
            sut.MenuPage.Should().Be(1);
            lcd.Received(2).Clear();
            lcd.Received(2).Print(menuItems[1]);
            lcd.Received(2).Print(menuItems[2]);
            lcd.Received(2).Write((byte)MenuCommand.Down);
        }
    }
}