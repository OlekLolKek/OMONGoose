using System;
using UnityEngine;


namespace OMONGoose
{
    public class TaskModel
    {
        #region Fields

        public event Action<int> OnTasksDoneChanged = delegate(int i) {  }; 
        public event Action<TaskObject> LoadTaskObject = delegate(TaskObject o) {  }; 
        
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

        public TaskObject[] GetTasks()
        {
            return _taskObjects;
        }

        public void LoadTask(TaskObject taskObject)
        {
            Debug.Log("Invoke");
            LoadTaskObject.Invoke(taskObject);
        }
    }
}