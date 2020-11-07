using UnityEngine;


namespace OMONGoose
{
    public class MoveController : IExecutable, ICleanable
    {
        #region Fields

        private readonly CharacterController _characterController;
        private readonly IUnit _unitData;
        
        private readonly IInputAxisChangeable _horizontalInputAxisChangeable;
        private readonly IInputAxisChangeable _verticalInputAxisChangeable;
        private readonly Transform _playerTransform;
        
        private Vector3 _move;
        private Vector3 _gravity;
        private float _horizontal;
        private float _vertical;
        
        #endregion


        public MoveController((IInputAxisChangeable inputHorizontal, IInputAxisChangeable inputVertical) input, CharacterController characterController, 
            Transform playerTransform, IUnit unitData)
        {
            _characterController = characterController;
            _playerTransform = playerTransform;
            _unitData = unitData;
            _horizontalInputAxisChangeable = input.inputHorizontal;
            _verticalInputAxisChangeable = input.inputVertical;
            _horizontalInputAxisChangeable.OnAxisChanged += OnHorizontalAxisChanged;
            _verticalInputAxisChangeable.OnAxisChanged += OnVerticalAxisChanged;
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
            Move(deltaTime);
            
        }

        private void Move(float deltaTime)
        {
            var speed = _unitData.Speed * deltaTime;
            _move = (_playerTransform.right * _horizontal + _playerTransform.forward * _vertical).normalized;
            _characterController.Move(_move * speed);

            if (!_characterController.isGrounded)
            {
                _gravity.y += Physics.gravity.y * deltaTime;
                _characterController.Move(_gravity * deltaTime);
            }
            else
            {
                _gravity.y = -2.0f;
                _characterController.Move(_gravity * deltaTime);
            }
        }

        public void Cleanup()
        {
            _horizontalInputAxisChangeable.OnAxisChanged -= OnHorizontalAxisChanged;
            _verticalInputAxisChangeable.OnAxisChanged -= OnVerticalAxisChanged;
        }
    }
}