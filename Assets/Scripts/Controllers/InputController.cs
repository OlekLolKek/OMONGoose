using UnityEngine;


namespace OMONGoose
{
    public sealed class InputController : IExecutable
    {

        #region Fields

        private readonly IInputAxisChangeable _horizontal;
        private readonly IInputAxisChangeable _vertical;
        private readonly IInputAxisChangeable _mouseX;
        private readonly IInputAxisChangeable _mouseY;
        private readonly IInputKeyPressable _interact;

        #endregion


        #region ClassLifeCycles

        public InputController((IInputAxisChangeable inputHorizontal, IInputAxisChangeable inputVertical) inputKeys, 
            (IInputAxisChangeable inputMouseX, IInputAxisChangeable inputMouseY) inputMouse,
            IInputKeyPressable inputInteract)
        {
            _horizontal = inputKeys.inputHorizontal;
            _vertical = inputKeys.inputVertical;
            _mouseX = inputMouse.inputMouseX;
            _mouseY = inputMouse.inputMouseY;
            _interact = inputInteract;
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

        #endregion
    }
}
