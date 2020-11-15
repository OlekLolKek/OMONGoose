using UnityEngine;


namespace OMONGoose
{
    public sealed class InputController : IExecutable, ILateExecutable
    {

        #region Fields

        private readonly IInputAxisChangeable _horizontal;
        private readonly IInputAxisChangeable _vertical;
        private readonly IInputAxisChangeable _mouseX;
        private readonly IInputAxisChangeable _mouseY;
        private readonly IInputKeyPressable _interact;
        private readonly IInputKeyPressable _save;
        private readonly IInputKeyPressable _load;

        #endregion


        #region ClassLifeCycles

        public InputController(
            (IInputAxisChangeable inputHorizontal, IInputAxisChangeable inputVertical) inputKeys, 
            (IInputAxisChangeable inputMouseX, IInputAxisChangeable inputMouseY) inputMouse,
            IInputKeyPressable inputInteract,
            IInputKeyPressable save,
            IInputKeyPressable load
            )
        {
            _horizontal = inputKeys.inputHorizontal;
            _vertical = inputKeys.inputVertical;
            _mouseX = inputMouse.inputMouseX;
            _mouseY = inputMouse.inputMouseY;
            _interact = inputInteract;
            _save = save;
            _load = load;
        }

        #endregion


        #region Methods

        public void Execute(float deltaTime)
        {
            _horizontal.GetAxis();
            _vertical.GetAxis();
            _mouseX.GetAxis();
            _mouseY.GetAxis();
            _interact.GetKey();
        }

        public void LateExecute(float deltaTime)
        {
            _load.GetKey();
            _save.GetKey();
        }

        #endregion
    }
}
