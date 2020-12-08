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

        protected GameObject _panelPrefab;
        protected Canvas _canvas;

        public abstract void Initialize(Canvas canvas, TaskData taskData);

        public abstract void Switch();

        protected void OnTaskCompleted()
        {
            CompletedTask?.Invoke(this);
        }
    }
}