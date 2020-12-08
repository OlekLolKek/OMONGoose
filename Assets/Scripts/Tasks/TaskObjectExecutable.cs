using UnityEngine;

namespace OMONGoose
{
    public class TaskObjectExecutable : TaskObject, IExecutable
    {
        [Tooltip("The type of the panel that is going to appear when players interacts with this TaskObject.")]
        [SerializeField] private ExecutableTaskTypes _type;
        private BaseTaskViewExecutable _taskViewPanel;

        public override void Initialize(Canvas canvas, TaskData taskData)
        {
            _canvas = canvas;
            switch (_type)
            {
                case ExecutableTaskTypes.Asteroids :
                    _panelPrefab = taskData.TaskStruct.AsteroidsPanelPrefab;
                    break;
                case ExecutableTaskTypes.StabilizeSteering:
                    _panelPrefab = taskData.TaskStruct.StabilizeSteeringPanelPrefab;
                    break;
            }
        }

        public void Execute(float deltaTime)
        {
            if (!_taskViewPanel) return;
            _taskViewPanel.Execute(deltaTime);
        }

        public override void Switch()
        {
            if (!_taskViewPanel)
            {
                _taskViewPanel = Instantiate(_panelPrefab, _canvas.transform).GetComponent<BaseTaskViewExecutable>();
                _taskViewPanel.Initialize();
                _taskViewPanel.CompletedTask += OnTaskPanelCompleted;
            }
            else
            {
                if (_taskViewPanel.IsDone)
                {
                    IsDone = true;
                }

                _taskViewPanel.CompletedTask -= OnTaskPanelCompleted;
                _taskViewPanel.Deactivate();
            }
        }
    }
}