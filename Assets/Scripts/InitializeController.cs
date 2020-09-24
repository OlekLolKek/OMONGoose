namespace OMONGoose
{
    public sealed class InitializeController
    {
        public InitializeController(MainController mainController, PlayerData playerData)
        {
            new InputInitializator(mainController);
            new PlayerInitializator(mainController, playerData);
        }
    }
}