using UnityEngine;

namespace OMONGoose
{
    public sealed class InteractController : IExecutable, ICleanable
    {
        #region Fields

        private readonly InteractionSwitch _interactionSwitch;
        private readonly IInputKeyPressable _interact;
        private readonly Transform _cameraTransform;
        private TaskObject _visibleTask;
        private bool _seesTask;

        #endregion

        
        public InteractController(Transform cameraTransform, IInputKeyPressable interact, InteractionSwitch interactionSwitch)
        {
            _cameraTransform = cameraTransform;
            _interact = interact;
            _interact.OnKeyPressed += TryInteract;
            _interactionSwitch = interactionSwitch;
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

        private void TryInteract(bool value)
        {
            if (!_seesTask) return;
            if (_visibleTask.IsDone) return;
            
            _visibleTask.Switch();
            _interactionSwitch.Interaction();
        }
        
        public void Cleanup()
        {
            _interact.OnKeyPressed -= TryInteract;
        }

        #endregion
    }
}