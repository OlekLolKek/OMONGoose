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

        private PlayerController _playerController;
        private InputStruct _inputStruct;
        private UILinks _links;
        private KeyCode _interact;
        private KeyCode _quit;

        #endregion


        #region ClassLifeCycles

        public InputController(InputModel inputModel, UILinks links)
        {
            _links = links;
            _inputStruct = inputModel.InputStruct;
            _quit = _inputStruct.Quit;
            _interact = _inputStruct.Interact;
            _playerController = ServiceLocator.Resolve<PlayerController>();
        }

        #endregion


        #region Methods

        public void UpdateTick()
        {
            Horizontal = Input.GetAxisRaw("Horizontal");
            Vertical = Input.GetAxisRaw("Vertical");
            MouseX = Input.GetAxisRaw("Mouse X");
            MouseY = Input.GetAxisRaw("Mouse Y");

            _playerController.Move(Horizontal, Vertical);
            _playerController.Look(MouseX, MouseY);

            CheckQuit();
            CheckInteract();
        }

        private void CheckInteract()
        {
            if (Input.GetKeyDown(_interact))
            {
                _playerController.UseTask();
            }
        }

        private void CheckQuit()
        {
            if (Input.GetKeyDown(_quit)) Application.Quit();
        }

        #endregion
    }
}
