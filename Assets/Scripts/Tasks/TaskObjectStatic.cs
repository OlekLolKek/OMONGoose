using System;
using UnityEngine;


namespace OMONGoose
{
    public sealed class TaskObjectStatic : TaskObject
    {
        [SerializeField] private StaticTaskTypes _type;
        private BaseTask _taskPanel;
        
        #region Methods
        
        public override void Initialize(Canvas canvas, TaskData taskData)
        {
            _canvas = canvas;
            switch (_type)
            {
                case StaticTaskTypes.Upload:
                    _panelPrefab = taskData.TaskStruct.DownloadPanelPrefab;
                    break;
                case StaticTaskTypes.Garbage:
                    _panelPrefab = taskData.TaskStruct.GarbagePanelPrefab;
                    break;
                case StaticTaskTypes.Wires:
                    _panelPrefab = taskData.TaskStruct.WiresPanelPrefab;
                    break;
            }
        }

        public override void Switch()
        {
            if (!_taskPanel)
            {
                _taskPanel = Instantiate(_panelPrefab, _canvas.transform).GetComponent<BaseTask>();
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

        #endregion
    }
}