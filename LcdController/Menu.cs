using System;
using System.Collections.Generic;
using System.Linq;
using LcdController.Lib;

namespace LcdController
{
    public class Menu
    {
        private readonly ILiquidCrystal _lcd;
        private readonly string[] _menuItems;

        private readonly IList<(Func<bool> Condition, Action Operation)> _menuCommands; 

        public Menu(ILiquidCrystal lcd, string[] menuItems)
        {
            _lcd = lcd ?? throw new ArgumentNullException(nameof(lcd));
            _menuItems = menuItems ?? throw new ArgumentNullException(nameof(menuItems));

            MaxMenuPages = ((double) menuItems.Length / 2).Round();
            _menuCommands = new List<(Func<bool> Condition, Action Operation)>
            {
                (() => MenuPage == 0, DrawUp),
                (() => MenuPage > 0 && MenuPage < MaxMenuPages, DrawUpDown),
                (() => MenuPage == MaxMenuPages, DrawDown)
            };
        }

        public int MenuPage { get; private set; } = 0;
        public int MaxMenuPages  { get; private set; } = 0;
        public void PageDown() => SetMenuPage(MenuPage - 1);
        public void PageUp() => SetMenuPage(MenuPage + 1);

        public void Draw()
        {
            DrawMenu();
        }

        private void DrawMenu()
        {
            DrawMenuItems();
            DrawCommands();
        }

        private void DrawMenuItems()
        {
            _lcd.Clear();
            _lcd.SetCursor(1, 0);
            _lcd.Print(_menuItems[MenuPage]);
            _lcd.SetCursor(1, 1);
            _lcd.Print(_menuItems[MenuPage + 1]);
        }

        private void SetMenuPage(int pageNumber)
        {
            MenuPage = pageNumber.Constrain(0, MaxMenuPages);
            DrawMenu();
        }

        private void DrawCommands()
        {
            var handler = _menuCommands.FirstOrDefault(c => c.Condition());
            if (handler != default)
                handler.Operation.Invoke();
        }

        private void DrawUpDown()
        {
            DrawUp();
            DrawDown();
        }

        private void DrawUp()
        {
            _lcd.SetCursor(15, 1);
            _lcd.Write((byte)MenuCommand.Up);
        }        
        
        private void DrawDown()
        {
            _lcd.SetCursor(15, 0);
            _lcd.Write((byte)MenuCommand.Down);
        }
    }
}