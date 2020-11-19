using UnityEngine;

namespace OMONGoose
{
    internal class TaskInitialization : IInitializable
    {
        #region Fields

        private TaskObject[] _taskObjects;

        #endregion
        
        public TaskInitialization(Transform taskRoot)
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