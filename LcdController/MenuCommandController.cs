using System;
using LcdController.Lib;

namespace LcdController
{
    public sealed class MenuCommandController : IMenuCommandController
    {
        private readonly IMicroController _microController;

        public MenuCommandController(IMicroController microController)
        {
            _microController = microController ?? throw new ArgumentNullException(nameof(microController));
        }
        
        public MenuCommand ReadCommand()
        {
            var readKey = _microController.AnalogRead(0);
            return EvaluateCommand(readKey);
        }
        
        private MenuCommand EvaluateCommand(int x)
        {
            return x switch
            {
                < 50 => MenuCommand.Down,
                < 195 => MenuCommand.Up,
                _ => MenuCommand.None
            };
        }
    }
}