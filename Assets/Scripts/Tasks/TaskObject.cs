using UnityEngine;


namespace OMONGoose
{
    //TODO: сделать класс ExecuteTaskObject с наследованием от интерфейса ITaskObjectable
    //             ITaskObjectable      IExecutable
    //                  / \                 /
    //  TaskObjectStatic   TaskObjectExecute
    public sealed class TaskObject : MonoBehaviour, IExecutable
    {
        #region Fields
        
        
        public delegate void CompletedTaskChange(TaskObject taskObject);
        public event CompletedTaskChange CompletedTask;
        public bool IsDone = false;

        [SerializeField] private RoomNames _roomName; 
        [SerializeField] private TaskTypes _type;

        private IExecutable _executeTask;
        private GameObject _panelPrefab;
        private BaseTask _taskPanel;
        private Canvas _canvas;

        #endregion


        #region Methods

        public void Initialize(GameContext context, TaskData taskData)
        {
            _canvas = context.Canvas;
            switch (_type)
            {
                case TaskTypes.Upload:
                    _panelPrefab = taskData.TaskStruct.DownloadPanelPrefab;
                    break;
                case TaskTypes.Garbage:
                    _panelPrefab = taskData.TaskStruct.GarbagePanelPrefab;
                    break;
                case TaskTypes.Wires:
                    _panelPrefab = taskData.TaskStruct.WiresPanelPrefab;
                    break;
                case TaskTypes.Asteroids:
                    _panelPrefab = taskData.TaskStruct.AsteroidsPanelPrefab;
                    break;
            }
        }

        public void Execute(float deltaTime)
        {
            _executeTask?.Execute(deltaTime);
        }

        public void Switch()
        {
            if (!_taskPanel)
            {
                _taskPanel = Instantiate(_panelPrefab, _canvas.transform).GetComponent<BaseTask>();
                _taskPanel.Initialize(_roomName, _canvas);
                _taskPanel.CompletedTask += OnTaskCompleted;
                if (_taskPanel is IExecutable executeTask)
                {
                    _executeTask = executeTask;
                }
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

        private void OnTaskCompleted()
        {
            CompletedTask?.Invoke(this);
        }

        #endregion
    }
}