namespace OMONGoose
{
    public sealed class InitializeController
    {
        public InitializeController(MainController mainController, PlayerData playerData, InputData inputData, TaskData taskData, TaskObject[] tasksArray, GameContext links)
        {
            new PlayerInitialization(mainController, playerData, links);
            new InputInitialization(mainController, inputData, links);
            new TaskInitialization(mainController, taskData, tasksArray, links);
        }
    }
}