using LcdController.Lib;

namespace LcdController
{
    public static class LiquidCrystalExtensions
    {
        public static byte[] DownArrow { get; } =
        {
            0b00100, 0b00100,
            0b00100, 0b00100,
            0b00100, 0b11111,
            0b01110, 0b00100
        };

        public static byte[] UpArrow { get; } =
        {
            0b00100, 0b01110,
            0b11111, 0b00100,
            0b00100, 0b00100,
            0b00100, 0b00100
        };
        
        public static void CreateUp(this ILiquidCrystal lcd) => 
            lcd.CreateChar((byte)MenuCommand.Up, UpArrow);        
        
        public static void CreateDown(this ILiquidCrystal lcd) => 
            lcd.CreateChar((byte)MenuCommand.Down, DownArrow);
    }
}