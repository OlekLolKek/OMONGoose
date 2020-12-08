using System.Collections.Generic;
using UnityEngine;


namespace OMONGoose
{
    public sealed class TaskController : IExecutable, ICleanable
    {
        #region Fields

        private readonly List<IExecutable> _executeTasks = new List<IExecutable>();
        private readonly TaskObject[] _taskObjects;
        private readonly TaskbarView _taskbar;
        private readonly TaskModel _taskModel;
        private MainController _mainController;

        #endregion

        public TaskController(TaskModel taskModel, TaskData taskData, GameContext context)
        {
            _taskModel = taskModel;
            _taskObjects = taskModel.GetTasks();
            _taskbar = Object.Instantiate(taskData.TaskStruct.TaskbarPrefab, context.Canvas.transform).GetComponent<TaskbarView>();
            _taskbar.Initialize(_taskObjects.Length, taskModel);
            taskModel.LoadTaskObject += LoadTaskObject;
            
            foreach (var taskObject in _taskObjects)
            {
                taskObject.Initialize(context.Canvas, taskData);
                taskObject.CompletedTask += CompleteTask;

                if (taskObject is TaskObjectExecutable executeTask)
                {
                    _executeTasks.Add(executeTask);
                }
            }
        }

        #region Methods

        public void Execute(float deltaTime)
        {
            foreach (var executeTask in _executeTasks)
            {
                executeTask.Execute(deltaTime);
            }
        }

        private void CompleteTask(TaskObject taskObject)
        {
            _taskModel.TasksDone++;
            taskObject.CompletedTask -= CompleteTask;
        }

        private void LoadTaskObject(TaskObject taskObject)
        {
            taskObject.CompletedTask += CompleteTask;
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