using UnityEngine;

namespace OMONGoose
{
    public class TaskObjectExecutable : TaskObject, IExecutable
    {
        [Tooltip("The type of the panel that is going to appear when players interacts with this TaskObject.")]
        [SerializeField] private ExecutableTaskTypes _type;
        private BaseTaskPanelControllerExecute _taskPanelControllerExecute;

        public override void Initialize(Canvas canvas, TaskData taskData)
        {
            _canvas = canvas;
            switch (_type)
            {
                case ExecutableTaskTypes.Asteroids :
                    _panelPrefab = taskData.TaskStruct.AsteroidsPanelPrefab;
                    _taskPanelController = new AsteroidsTaskPanelController(_canvas, _panelPrefab);
                    _taskPanelControllerExecute = (BaseTaskPanelControllerExecute) _taskPanelController;
                    break;
                case ExecutableTaskTypes.StabilizeSteering:
                    _panelPrefab = taskData.TaskStruct.StabilizeSteeringPanelPrefab;
                    break;
            }
        }

        public void Execute(float deltaTime)
        {
            if (_taskPanelController == null) return;
            if (!_taskPanelController.IsActive) return;
            _taskPanelControllerExecute.Execute(deltaTime);
        }
    }
}