using System;
using UnityEngine;

namespace OMONGoose
{
    public abstract class TaskObject : MonoBehaviour
    {
        public event CompletedTaskChange CompletedTask;
        public bool IsDone { get; set; }
        
        [Tooltip("The room this TaskObject is located in.")]
        [SerializeField] protected RoomNames _roomName;

        protected BaseTaskPanelController _taskPanelController;
        protected GameObject _panelPrefab;
        protected Canvas _canvas;

        public abstract void Initialize(Canvas canvas, TaskData taskData);

        public void Switch()
        {
            _taskPanelController.Switch();
            if (_taskPanelController.IsActive)
            {
                _taskPanelController.CompletedTask += OnTaskPanelCompleted;
            }
            else
            {
                if (_taskPanelController.IsDone)
                {
                    IsDone = true;
                }
                _taskPanelController.CompletedTask -= OnTaskPanelCompleted;
            }
        }

        protected void OnTaskPanelCompleted()
        {
            CompletedTask?.Invoke(this);
        }
    }
}