using UnityEngine;


namespace OMONGoose
{
    public class MoveController : IExecutable, ICleanable
    {
        #region Fields

        private readonly CharacterController _characterController;
        private readonly Transform _playerTransform;
        private readonly Animator _animator;
        private readonly IUnit _unitData;
        
        private readonly IInputAxisChangeable _horizontalInputAxisChangeable;
        private readonly IInputAxisChangeable _verticalInputAxisChangeable;
        private readonly IInputKeyPressable _interact;

        private Vector3 _move;
        private Vector3 _gravity;
        private float _horizontal;
        private float _vertical;
        private bool _isInteracting;
        private static readonly int Speed = Animator.StringToHash("Speed");

        #endregion


        public MoveController((IInputAxisChangeable inputHorizontal, IInputAxisChangeable inputVertical) input, IInputKeyPressable interact, CharacterController characterController, 
            Transform playerTransform, Animator animator, IUnit unitData)
        {
            _characterController = characterController;
            _playerTransform = playerTransform;
            _animator = animator;
            _unitData = unitData;
            _horizontalInputAxisChangeable = input.inputHorizontal;
            _verticalInputAxisChangeable = input.inputVertical;
            _interact = interact;
            _horizontalInputAxisChangeable.OnAxisChanged += OnHorizontalAxisChanged;
            _verticalInputAxisChangeable.OnAxisChanged += OnVerticalAxisChanged;
            _interact.OnKeyPressed += OnInteract;
        }

        private void OnVerticalAxisChanged(float value)
        {
            _vertical = value;
        }

        private void OnHorizontalAxisChanged(float value)
        {
            _horizontal = value;
        }

        private void OnInteract(bool b)
        {
            _isInteracting = !_isInteracting;
        }

        public void Execute(float deltaTime)
        {
            Move(deltaTime);
        }

        private void Move(float deltaTime)
        {
            if (_isInteracting)
            {
                _animator.SetFloat(Speed, 0);
                return;
            }
            var speed = _unitData.Speed * deltaTime;
            _move = (_playerTransform.right * _horizontal + _playerTransform.forward * _vertical).normalized;
            _characterController.Move(_move * speed);
            _animator.SetFloat(Speed, _move.magnitude);

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