using System;
using UnityEngine;

namespace OMONGoose
{
    public class TaskModel : IInitializable
    {
        #region Fields

        public event Action<int> OnTasksDoneChanged = delegate(int i) {  }; 
        
        private TaskObject[] _taskObjects;
        private int _tasksDone = 0;

        #endregion

        public int TasksDone
        {
            get => _tasksDone;
            set
            {
                _tasksDone = value;
                OnTasksDoneChanged.Invoke(_tasksDone);
            }
        }

        public TaskModel(Transform taskRoot)
        {
            _taskObjects = taskRoot.GetComponentsInChildren<TaskObject>();
        }

        public void Initialization()
        {
        }

        public TaskObject[] GetTasks()
        {
            return _taskObjects;
        }
    }
}