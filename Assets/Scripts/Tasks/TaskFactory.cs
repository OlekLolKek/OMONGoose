using UnityEngine;


namespace OMONGoose
{
    public sealed class TaskFactory : ITaskFactory
    {
        // Сейчас этот класс не используется, так как я посчитал, что в нём нет смысла и всё, что изначально делалось тут, можно выполнять в TaskInitialization
        // Хотелось бы увидеть фидбек по этой теме
        
        #region Fields

        private GameContext _context;
        private TaskData _taskData;
        private TaskObjectStatic[] _tasks;

        #endregion
        
        public TaskFactory(TaskData taskData, Transform root, GameContext context)
        {
            _tasks = root.GetComponentsInChildren<TaskObjectStatic>();
            _context = context;
        }

        public void InitializeTasks()
        {
            foreach (var task in _tasks)
            {
                //task.Initialize(_context);
            }
        }
    }
}