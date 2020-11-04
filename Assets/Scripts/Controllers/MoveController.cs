using UnityEngine;

namespace OMONGoose
{
    public class MoveController : IExecutable, ICleanable
    {
        #region Fields

        private readonly CharacterController _characterController;
        private readonly IUnit _unitData;
        
        private IUserInputProxy _horizontalInputProxy;
        private IUserInputProxy _verticalInputProxy;
        private Vector3 _move;
        private float _horizontal;
        private float _vertical;
        
        #endregion


        public MoveController((IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input, CharacterController characterController, IUnit unitData)
        {
            _characterController = characterController;
            _unitData = unitData;
            _horizontalInputProxy = input.inputHorizontal;
            _verticalInputProxy = input.inputVertical;
            _horizontalInputProxy.OnAxisChanged += OnHorizontalAxisChanged;
            _verticalInputProxy.OnAxisChanged += OnVerticalAxisChanged;
        }

        private void OnVerticalAxisChanged(float value)
        {
            _vertical = value;
        }

        private void OnHorizontalAxisChanged(float value)
        {
            _horizontal = value;
        }

        public void Execute(float deltaTime)
        {
            var speed = deltaTime * _unitData.Speed;
            _move.Set(_horizontal * speed, 0.0f, _vertical * speed);
            _characterController.Move(_move);
        }

        public void Cleanup()
        {
            _horizontalInputProxy.OnAxisChanged -= OnHorizontalAxisChanged;
            _verticalInputProxy.OnAxisChanged -= OnVerticalAxisChanged;
        }
    }
}