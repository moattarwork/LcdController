namespace LcdController.Lib
{
    public sealed class FakeMicroController : IMicroController
    {
        public int AnalogRead(int pinNumber)
        {
            return -1;
        }
    }
}