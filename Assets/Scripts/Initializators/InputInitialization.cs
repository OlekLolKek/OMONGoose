namespace OMONGoose
{
    internal sealed class InputInitialization : IInitializable
    {
        #region Fields

        private readonly IInputAxisChangeable _pcInputHorizontal;
        private readonly IInputAxisChangeable _pcInputVertical;
        private readonly IInputAxisChangeable _pcInputMouseX;
        private readonly IInputAxisChangeable _pcInputMouseY;
        private readonly IInputKeyPressable _pcInputInteract;
        private readonly IInputKeyPressable _pcInputSave;
        private readonly IInputKeyPressable _pcInputLoad;

        #endregion
        
        public InputInitialization()
        {
            _pcInputHorizontal = new PCInputHorizontal();
            _pcInputVertical = new PCInputVertical();
            _pcInputMouseX = new PCInputMouseX();
            _pcInputMouseY = new PCInputMouseY();
            _pcInputInteract = new PCInputKey(AxisManager.INTERACT);
            _pcInputSave = new PCInputKey(AxisManager.SAVE);
            _pcInputLoad = new PCInputKey(AxisManager.LOAD);
        }

        public void Initialization()
        {
        }
        
        public (IInputAxisChangeable inputHorizontal, IInputAxisChangeable inputVertical) GetInputKeyboard()
        {
            (IInputAxisChangeable inputHorizontal, IInputAxisChangeable inputVertical) result = (_pcInputHorizontal,
                _pcInputVertical);
            return result;
        }

        public (IInputAxisChangeable inputMouseX, IInputAxisChangeable inputMouseY) GetInputMouse()
        {
            (IInputAxisChangeable inputMouseX, IInputAxisChangeable inputMouseY) result = (_pcInputMouseX, 
                _pcInputMouseY);
            return result;
        }

        public IInputKeyPressable GetInputInteract()
        {
            return _pcInputInteract;
        }

        public IInputKeyPressable GetInputLoad()
        {
            return _pcInputLoad;
        }
        
        public IInputKeyPressable GetInputSave()
        {
            return _pcInputSave;
        }

        ~InputInitialization()
        {
            
        }
    }
}