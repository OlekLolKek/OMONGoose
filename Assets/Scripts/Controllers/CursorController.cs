using UnityEngine;


namespace OMONGoose
{
    public class CursorController : IInitializable
    {
        #region Fields

        private readonly IInputKeyPressable _interact;
        private bool _isCursorLocked;

        #endregion
        
        public CursorController(IInputKeyPressable interact)
        {
            _interact = interact;
            _interact.OnKeyPressed += SwitchCursorLock;
        }

        public void Initialization()
        {
            Cursor.lockState = CursorLockMode.Locked;
            _isCursorLocked = true;
            Cursor.visible = false;
        }

        private void SwitchCursorLock(bool b)
        {
            if (_isCursorLocked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                _isCursorLocked = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                _isCursorLocked = true;
            }
        }
    }
}