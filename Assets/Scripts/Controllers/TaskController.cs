using UnityEngine;


namespace OMONGoose
{
    public class TaskController : IInitializable
    {
        #region Fields

        private readonly TaskObject[] _taskObjects;
        private MainController _mainController;
        private TaskbarView _taskbar;
        private int _tasksDone = 0;

        #endregion

        public TaskController(TaskObject[] taskObjectObjects, TaskData taskData, GameContext context)
        {
            _taskObjects = taskObjectObjects;
            _taskbar = Object.Instantiate(taskData.TaskStruct.TaskbarPrefab, context.Canvas.transform).GetComponent<TaskbarView>();
            _taskbar.Initialize(_taskObjects.Length);
            
            foreach (var taskObject in _taskObjects)
            {
                taskObject.Initialize(context, taskData);
                taskObject.CompletedTask += CompleteTask;
            }
        }


        #region Methods

        public void CompleteTask(TaskObject taskObject)
        {
            _tasksDone++;
            _taskbar.TaskCompleted(_tasksDone, _taskObjects.Length);
            taskObject.CompletedTask -= CompleteTask;
        }
        
        public void Initialization()
        {
        }
        
        #endregion
    }
}