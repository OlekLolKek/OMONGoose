namespace OMONGoose
{
    public sealed class InitializeController
    {
        public InitializeController(MainController mainController, PlayerData playerData, InputData inputData, TaskData taskData, TaskObject[] tasksArray, GameContext links)
        {
            new PlayerInitializator(mainController, playerData, links);
            new InputInitializator(mainController, inputData, links);
            new TaskInitializator(mainController, taskData, tasksArray, links);
        }
    }
}