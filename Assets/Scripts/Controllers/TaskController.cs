using System.Collections.Generic;
using UnityEngine;


namespace OMONGoose
{
    public class TaskController : IInitializable, IExecutable, ICleanable
    {
        #region Fields

        private readonly List<IExecutable> _executeTasks = new List<IExecutable>();
        private readonly TaskObject[] _taskObjects;
        private readonly TaskbarView _taskbar;
        private MainController _mainController;
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
                if (taskObject is IExecutable executeTask)
                {
                    _executeTasks.Add(executeTask);
                }
            }
        }

        #region Methods

        public void Initialization()
        {
        }

        public void Execute(float deltaTime)
        {
            foreach (var executeTask in _executeTasks)
            {
                executeTask.Execute(deltaTime);
            }
        }

        private void CompleteTask(TaskObject taskObject)
        {
            _tasksDone++;
            _taskbar.TaskCompleted(_tasksDone, _taskObjects.Length);
            taskObject.CompletedTask -= CompleteTask;
        }

        public void Cleanup()
        {
            foreach (var taskObject in _taskObjects)
            {
                taskObject.CompletedTask -= CompleteTask;
            }
        }

        #endregion
    }
}