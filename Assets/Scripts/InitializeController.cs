namespace OMONGoose
{
    public sealed class InitializeController
    {
        public InitializeController(MainController mainController, PlayerData playerData)
        {
            new PlayerInitializator(mainController, playerData);
        }
    }
}