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

        private KeyCode _quit;

        #endregion


        #region Methods

        public void UpdateTick()
        {
            Horizontal = Input.GetAxis("Horizontal");
            Vertical = Input.GetAxis("Vertical");
            MouseX = Input.GetAxis("Mouse X");
            MouseY = Input.GetAxis("Mouse Y");

            CheckQuit();
        }

        private void CheckQuit()
        {
            if (Input.GetKeyDown(_quit)) Application.Quit();
        }

        #endregion
    }
}
