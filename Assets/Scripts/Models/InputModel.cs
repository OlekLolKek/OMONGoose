namespace OMONGoose
{
    internal sealed class InputModel
    {
        #region Fields

        private readonly IInputAxisChangeable _pcInputHorizontal;
        private readonly IInputAxisChangeable _pcInputVertical;
        private readonly IInputAxisChangeable _pcInputMouseX;
        private readonly IInputAxisChangeable _pcInputMouseY;
        private readonly IInputKeyPressable _pcInputInteract;
        private readonly IInputKeyPressable _pcInputSave;
        private readonly IInputKeyPressable _pcInputLoad;
        private readonly IInputKeyPressable _pcInputMap1;
        private readonly IInputKeyPressable _pcInputMap2;

        #endregion
        
        public InputModel()
        {
            _pcInputHorizontal = new PCInputHorizontal();
            _pcInputVertical = new PCInputVertical();
            _pcInputMouseX = new PCInputMouseX();
            _pcInputMouseY = new PCInputMouseY();
            _pcInputInteract = new PCInputKey(AxisManager.INTERACT);
            _pcInputSave = new PCInputKey(AxisManager.SAVE);
            _pcInputLoad = new PCInputKey(AxisManager.LOAD);
            _pcInputMap1 = new PCInputKey(AxisManager.MAP1);
            _pcInputMap2 = new PCInputKey(AxisManager.MAP2);
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

        public (IInputKeyPressable Map1, IInputKeyPressable Map2) GetInputMap()
        {
            (IInputKeyPressable Map1, IInputKeyPressable Map2) result = (_pcInputMap1, _pcInputMap2);
            return result;
        }
    }
}