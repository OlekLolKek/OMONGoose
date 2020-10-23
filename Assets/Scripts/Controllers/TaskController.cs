using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace OMONGoose
{
    public class TaskController
    {
        #region Fields

        private TaskObject[] _tasks;
        private MainController _mainController;
        private TaskModel _taskModel;
        private GameContext _context;
        private TaskbarView _taskbar;
        private int _tasksDone = 0;

        #endregion

        public TaskController(MainController mainController, TaskModel taskModel, TaskObject[] tasksArray, GameContext context)
        {
            _mainController = mainController;
            _taskModel = taskModel;
            _context = context;
            _tasks = tasksArray;
            _taskbar = Object.Instantiate(_taskModel.TaskStruct.TaskbarPrefab, _context.Canvas.transform).GetComponent<TaskbarView>();
            Initialize();
        }


        #region Methods

        public void CompleteTask()
        {
            _tasksDone++;
            _taskbar.TaskCompleted(_tasksDone, _tasks.Length);
        }

        private void Initialize()
        {
            foreach (var taskObject in _tasks)
            {
                taskObject.Initialize(this, _context.Canvas, _taskModel);
            }
            _taskbar.Initialize(_tasks.Length);
        }

        #endregion
    }
}