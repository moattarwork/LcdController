namespace LcdController.Lib
{
    public sealed class FakeLiquidCrystal : ILiquidCrystal
    {
        public FakeLiquidCrystal(int pinNumRS, int pinNumEnable, int pinNumD4, int pinNumD5,
            int pinNumD6, int pinNumD7)
        {
        }

        public void Clear()
        {
        }

        public void Begin(int cols, int rows)
        {
        }
        
        public void SetCursor(int col, int row)
        {
        }


        public void Print(string text)
        {
        }

        public void Write(byte character)
        {
        }

        public void CreateChar(byte number, byte[] data)
        {
        }
    }
}