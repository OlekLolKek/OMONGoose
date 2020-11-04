using UnityEngine;


namespace OMONGoose
{
    public sealed class InputController : IExecutable
    {

        #region Fields

        private readonly IUserInputProxy _horizontal;
        private readonly IUserInputProxy _vertical;
        private readonly IUserInputProxy _mouseX;
        private readonly IUserInputProxy _mouseY;

        #endregion


        #region ClassLifeCycles

        public InputController((IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input)
        {
            _horizontal = input.inputHorizontal;
            _vertical = input.inputVertical;
        }

        #endregion


        #region Methods

        public void Execute(float deltaTime)
        {
            _horizontal.GetAxis();
            _vertical.GetAxis();
            
            //TODO: Добавить управление мышью
        }

        #endregion
    }
}
