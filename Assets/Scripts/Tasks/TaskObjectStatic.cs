using System;
using UnityEngine;


namespace OMONGoose
{
    public sealed class TaskObjectStatic : TaskObject
    {
        [Tooltip("The type of the panel that is going to appear when a player interacts with this TaskObject.")]
        [SerializeField] private StaticTaskTypes _type;

        #region Methods
        
        public override void Initialize(Canvas canvas, TaskData taskData)
        {
            _canvas = canvas;
            switch (_type)
            {
                case StaticTaskTypes.UploadData:
                    _panelPrefab = taskData.TaskStruct.DownloadPanelPrefab;
                    _taskPanelController = new DownloadTaskPanelController(_roomName, _canvas, _panelPrefab);
                    break;
                case StaticTaskTypes.EmptyGarbage:
                    _panelPrefab = taskData.TaskStruct.GarbagePanelPrefab;
                    _taskPanelController = new GarbageTaskPanelController(_canvas, _panelPrefab);
                    break;
                case StaticTaskTypes.FixWiring:
                    _panelPrefab = taskData.TaskStruct.WiresPanelPrefab;
                    _taskPanelController = new WiresTaskPanelController(_canvas, _panelPrefab);
                    break;
                case StaticTaskTypes.AcceptDivertedPower:
                    _panelPrefab = taskData.TaskStruct.AcceptDivertedPowerPanelPrefab;
                    _taskPanelController = new AcceptDivertedPowerTaskPanelController(_canvas, _panelPrefab);
                    break;
            }
        }

        #endregion
    }
}