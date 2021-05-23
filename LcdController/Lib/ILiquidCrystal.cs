namespace LcdController.Lib
{
    public interface ILiquidCrystal
    {
        void Clear();
        /// <summary>
        /// Initializes the interface to the LCD screen, and specifies the dimensions
        /// (width and height) of the display.
        /// begin() needs to be called before any other LCD library commands.
        /// </summary>
        /// <param name="cols"></param>
        /// <param name="rows"></param>
        void Begin(int cols, int rows);
        /// <summary>
        /// Position the LCD cursor; that is, set the location at which subsequent
        /// text written to the LCD will be displayed.
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        void SetCursor(int col, int row);
        /// <summary>
        /// Prints text to the LCD.
        /// </summary>
        /// <param name="text"></param>
        void Print(string text);
        /// <summary>
        /// Write a character to the LCD.
        /// </summary>
        /// <param name="character"></param>
        void Write(byte character);
        /// <summary>
        /// Create a custom character (glyph) for use on the LCD.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="data"></param>
        void CreateChar(byte number, byte[] data);
    }
}