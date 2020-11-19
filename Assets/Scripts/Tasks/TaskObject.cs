using UnityEngine;


namespace OMONGoose
{
    public sealed class TaskObject : MonoBehaviour
    {
        #region Fields
        
        
        public delegate void CompletedTaskChange(TaskObject taskObject);
        public event CompletedTaskChange CompletedTask;
        public bool IsDone = false;

        [SerializeField] private RoomNames _roomName; 
        [SerializeField] private TaskTypes _type;
        
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

        public void Switch()
        {
            if (!_taskPanel)
            {
                _taskPanel = Instantiate(_panelPrefab, _canvas.transform).GetComponent<BaseTask>();
                _taskPanel.Initialize(_roomName);
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

        private void OnTaskCompleted()
        {
            CompletedTask?.Invoke(this);
        }

        #endregion
    }
}