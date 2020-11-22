using UnityEngine;

namespace OMONGoose
{
    public sealed class InteractController : IExecutable, ICleanable
    {
        #region Fields

        private readonly InteractionSwitch _interactionSwitch;
        private readonly IInputKeyPressable _interact;
        private readonly Transform _cameraTransform;
        private readonly CrosshairView _crosshairView;
        private TaskObjectStatic _visibleTask;
        private bool _seesTask;

        #endregion

        
        public InteractController(IInputKeyPressable interact, InteractionSwitch interactionSwitch, Transform cameraTransform, CrosshairView crosshairView)
        {
            _cameraTransform = cameraTransform;
            _interact = interact;
            _crosshairView = crosshairView;
            _interact.OnKeyPressed += TryInteract;
            _interactionSwitch = interactionSwitch;
        }

        #region Methods

        public void Execute(float deltaTime)
        {
            var ray = new Ray(_cameraTransform.position, _cameraTransform.forward);
            if (Physics.Raycast(ray, out var hit, 3.0f))
            {
                if (hit.collider.TryGetComponent<TaskObjectStatic>(out var taskObject))
                {
                    _seesTask = true;
                    _visibleTask = taskObject;
                    _crosshairView.TaskLocated();
                }
                else
                {
                    _seesTask = false;
                    _crosshairView.TaskUnlocated();
                }
            }
            else
            {
                _seesTask = false;
                _crosshairView.TaskUnlocated();
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