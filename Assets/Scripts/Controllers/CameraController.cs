using UnityEngine;


namespace OMONGoose
{
    public class CameraController : IExecutable, ICleanable
    {
        private readonly Transform _cameraTransform;
        private readonly Transform _playerTransform;
        private readonly IInputAxisChangeable _mouseXInputAxisChangeable;
        private readonly IInputAxisChangeable _mouseYInputAxisChangeable;
        private readonly InteractionSwitch _interact;
        private readonly float _sensitivity;
        private readonly float _minXRotation;
        private readonly float _maxXRotation;
        private float _mouseX;
        private float _mouseY;
        private float _xRotation;
        private bool _isInteracting;

        public CameraController((IInputAxisChangeable mouseX, IInputAxisChangeable mouseY) input, InteractionSwitch interactionSwitch, Transform playerTransform, 
            PlayerData playerData, Transform cameraTransform)
        {
            _playerTransform = playerTransform;
            _cameraTransform = cameraTransform;

            _sensitivity = playerData.Sensitivity;
            _minXRotation = playerData.MinXRotation;
            _maxXRotation = playerData.MaxXRotation;
            
            _mouseXInputAxisChangeable = input.mouseX;
            _mouseYInputAxisChangeable = input.mouseY;
            _interact = interactionSwitch;
            _mouseXInputAxisChangeable.OnAxisChanged += OnMouseXAxisChanged;
            _mouseYInputAxisChangeable.OnAxisChanged += OnMouseYAxisChanged;
            _interact.OnInteraction += OnInteract;
        }

        public void Execute(float deltaTime)
        {
            Look(deltaTime);
        }

        private void Look(float deltaTime)
        {
            if (_isInteracting) return;
            _xRotation -= _mouseY * _sensitivity * deltaTime;
            _xRotation = Mathf.Clamp(_xRotation, _minXRotation, _maxXRotation);
            _cameraTransform.localRotation = Quaternion.Euler(_xRotation, 0.0f, 0.0f);
            _playerTransform.Rotate(Vector3.up * (_mouseX * _sensitivity * deltaTime));
        }
        
        private void OnMouseXAxisChanged(float value)
        {
            _mouseX = value;
        }
        
        private void OnMouseYAxisChanged(float value)
        {
            _mouseY = value;
        }

        private void OnInteract(bool b)
        {
            _isInteracting = !_isInteracting;
        }
        
        public void Cleanup()
        {
            _mouseXInputAxisChangeable.OnAxisChanged -= OnMouseXAxisChanged;
            _mouseYInputAxisChangeable.OnAxisChanged -= OnMouseYAxisChanged;
        }
    }
}