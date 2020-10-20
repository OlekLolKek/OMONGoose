namespace OMONGoose
{
    internal class TaskInitializator
    {
        public TaskInitializator(MainController mainController, TaskData taskData, TaskObject[] tasksArray, GameContext context)
        {
            var model = new TaskModel(taskData.TaskStruct);
            var controller = new TaskController(mainController, model, tasksArray, context);

            ServiceLocator.SetService(controller);
        }
    }
}