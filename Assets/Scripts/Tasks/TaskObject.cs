using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;


namespace OMONGoose
{
    public sealed class TaskObject : MonoBehaviour
    {
        #region Fields
        
        public bool IsDone = false;

        [SerializeField] private RoomNames _roomName; 
        [SerializeField] private TaskTypes _type;

        private TaskController _taskController;
        private GameObject _panelPrefab;
        private TaskModel _taskModel;
        private BaseTask _taskPanel;
        private Canvas _canvas;

        #endregion


        #region Methods

        public void Initialize(TaskController taskController, Canvas canvas, TaskModel taskModel)
        {
            _canvas = canvas;
            _taskController = taskController;
            _taskModel = taskModel;
            switch (_type)
            {
                case TaskTypes.Upload:
                    _panelPrefab = _taskModel.TaskStruct.DownloadPanelPrefab;
                    break;
                case TaskTypes.Garbage:
                    _panelPrefab = _taskModel.TaskStruct.GarbagePanelPrefab;
                    break;
                case TaskTypes.Wires:
                    _panelPrefab = _taskModel.TaskStruct.WiresPanelPrefab;
                    break;
            }
        }

        public void Switch()
        {
            if (!_taskPanel)
            {
                _taskPanel = Instantiate(_panelPrefab, _canvas.transform).GetComponent<BaseTask>();
                _taskPanel.Initialize(_taskController, _roomName);
            }
            else
            {
                if (_taskPanel.IsDone)
                {
                    IsDone = true;
                }
                _taskPanel.Deactivate();
            }
        }

        #endregion
    }
}