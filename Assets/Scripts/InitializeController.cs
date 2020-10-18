namespace OMONGoose
{
    public sealed class InitializeController
    {
        public InitializeController(MainController mainController, PlayerData playerData, InputData inputData, UILinks links)
        {
            new PlayerInitializator(mainController, playerData, links);
            new InputInitializator(mainController, inputData, links);
        }
    }
}