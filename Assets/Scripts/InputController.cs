using UnityEngine;


namespace OMONGoose
{
    public sealed class InputController : IUpdatable
    {

        #region Fields

        public float Horizontal;
        public float Vertical;
        public float MouseX;
        public float MouseY;

        private KeyCode _quit = KeyCode.Escape;

        #endregion


        #region Methods

        public void UpdateTick()
        {
            Horizontal = Input.GetAxisRaw("Horizontal");
            Vertical = Input.GetAxisRaw("Vertical");
            MouseX = Input.GetAxisRaw("Mouse X");
            MouseY = Input.GetAxisRaw("Mouse Y");

            CheckQuit();
        }

        private void CheckQuit()
        {
            if (Input.GetKeyDown(_quit)) Application.Quit();
        }

        #endregion
    }
}
