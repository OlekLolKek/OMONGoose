using UnityEngine;

namespace OMONGoose
{
    public class TaskObjectExecutable : TaskObject, IExecutable
    {
        [Tooltip("The type of the panel that is going to appear when players interacts with this TaskObject.")]
        [SerializeField] private ExecutableTaskTypes _type;
        private BaseTaskExecutable _taskPanel;

        public override void Initialize(Canvas canvas, TaskData taskData)
        {
            _canvas = canvas;
            switch (_type)
            {
                case ExecutableTaskTypes.Asteroids :
                    _panelPrefab = taskData.TaskStruct.AsteroidsPanelPrefab;
                    break;
            }
        }

        public void Execute(float deltaTime)
        {
            if (!_taskPanel) return;
            _taskPanel.Execute(deltaTime);
        }

        public override void Switch()
        {
            if (!_taskPanel)
            {
                _taskPanel = Instantiate(_panelPrefab, _canvas.transform).GetComponent<BaseTaskExecutable>();
                _taskPanel.Initialize(_roomName, _canvas);
                _taskPanel.CompletedTask += OnTaskCompleted;
            }
            else
            {
                if (_taskPanel.IsDone)
                {
                    IsDone = true;
                }

                _taskPanel.CompletedTask -= OnTaskCompleted;
                _taskPanel.Deactivate();
            }
        }
    }
}