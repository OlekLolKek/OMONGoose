using System;
using UnityEngine;


namespace OMONGoose
{
    public sealed class TaskObjectStatic : TaskObject
    {
        [Tooltip("The type of the panel that is going to appear when a player interacts with this TaskObject.")]
        [SerializeField] private StaticTaskTypes _type;
        //private BaseTaskView _taskViewPanel;

        #region Methods
        
        public override void Initialize(Canvas canvas, TaskData taskData)
        {
            _canvas = canvas;
            switch (_type)
            {
                case StaticTaskTypes.UploadData:
                    _panelPrefab = taskData.TaskStruct.DownloadPanelPrefab;
                    TaskPanelController = new DownloadTaskPanelController(_roomName, _canvas, _panelPrefab);
                    break;
                case StaticTaskTypes.EmptyGarbage:
                    _panelPrefab = taskData.TaskStruct.GarbagePanelPrefab;
                    TaskPanelController = new GarbageTaskPanelController(_canvas, _panelPrefab);
                    break;
                case StaticTaskTypes.FixWiring:
                    _panelPrefab = taskData.TaskStruct.WiresPanelPrefab;
                    TaskPanelController = new WiresTaskPanelController(_canvas, _panelPrefab);
                    break;
                case StaticTaskTypes.AcceptDivertedPower:
                    _panelPrefab = taskData.TaskStruct.AcceptDivertedPowerPanelPrefab;
                    TaskPanelController = new AcceptDivertedPowerTaskPanelController(_canvas, _panelPrefab);
                    break;
            }
        }

        public override void Switch()
        {
            TaskPanelController.Switch();
            if (TaskPanelController.IsActive)
            {
                TaskPanelController.CompletedTask += OnTaskPanelCompleted;
            }
            else
            {
                if (TaskPanelController.IsDone)
                {
                    IsDone = true;
                }
                TaskPanelController.CompletedTask -= OnTaskPanelCompleted;
            }
            // if (!_taskViewPanel)
            // {
            //     _taskViewPanel = Instantiate(_panelPrefab, _canvas.transform).GetComponent<BaseTaskView>();
            //     _taskViewPanel.Initialize(_roomName, _canvas);
            //     _taskViewPanel.CompletedTask += OnTaskCompleted;
            // }
            // else
            // {
            //     if (_taskViewPanel.IsDone)
            //     {
            //         IsDone = true;
            //     }
            //
            //     _taskViewPanel.CompletedTask -= OnTaskCompleted;
            //     _taskViewPanel.Deactivate();
            // }
        }

        #endregion
    }
}