using UnityEngine;


namespace OMONGoose
{
    public sealed class PlayerInitializator
    {
        public PlayerInitializator(MainController mainController, PlayerData playerData)
        {
            var player = GameObject.FindGameObjectWithTag("Player");

            var playerStruct = playerData.playerStruct;
            playerStruct.PlayerPrefab = player;

            var cubeModel = new PlayerModel(playerStruct);
            mainController.AddUpdatable(new PlayerController(cubeModel));
        }
    }
}
