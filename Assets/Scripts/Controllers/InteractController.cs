using UnityEngine;

namespace OMONGoose
{
    public sealed class InteractController : IExecutable, ICleanable
    {
        #region Fields

        private IInputKeyPressable _interact;
        private readonly Transform _cameraTransform;
        private TaskObject _visibleTask;
        private bool _seesTask;

        #endregion

        
        public InteractController(Transform cameraTransform, IInputKeyPressable interact)
        {
            _cameraTransform = cameraTransform;
            _interact = interact;
            _interact.OnKeyPressed += TryInteract;
        }
        

        #region Methods

        public void Execute(float deltaTime)
        {
            var ray = new Ray(_cameraTransform.position, _cameraTransform.forward);
            if (Physics.Raycast(ray, out var hit, 3.0f))
            {
                if (hit.collider.TryGetComponent<TaskObject>(out var taskObject))
                {
                    _seesTask = true;
                    _visibleTask = taskObject;
                }
                else
                {
                    _seesTask = false;
                }
            }
            else
            {
                _seesTask = false;
            }
        }

        public void TryInteract(bool value)
        {
            if (_seesTask)
            {
                _visibleTask.Switch();
            }
        }
        
        public void Cleanup()
        {
            _interact.OnKeyPressed -= TryInteract;
        }

        #endregion
    }
}