using System;
using LcdController.Lib;

namespace LcdController.Cli
{
    class Program
    {
        private static readonly ILiquidCrystal lcd = new FakeLiquidCrystal(8, 9, 4, 5, 6, 7);
        private static readonly IMenuCommandController
            controller = new MenuCommandController(new FakeMicroController());
        
        private static readonly string[] menuItems = {"START CAPTURE", "START SHOWCASE" ,"PRESETS", "SET TRIGGER", "SETTINGS", "ABOUT"};
        private static readonly Menu menu = new(lcd, menuItems);
        
        static void Main(string[] args)
        {
            Setup();
            while (true)
            {
                Loop();
            }
        }

        private static void Setup()
        {
            lcd.Begin(16, 2);
            lcd.CreateUp();
            lcd.CreateDown();
        }

        private static void Loop()
        {
            menu.Draw();
            ProcessCommands();
        }

        private static void ProcessCommands()
        {
            while (true)
            {
                var command = controller.ReadCommand();
                switch (command)
                {
                    case MenuCommand.None:
                        break;
                    case MenuCommand.Down:
                        menu.PageDown();
                        return;
                    case MenuCommand.Up:
                        menu.PageUp();
                        return;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}