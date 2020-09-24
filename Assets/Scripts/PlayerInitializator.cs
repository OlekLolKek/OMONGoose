using UnityEngine;


namespace OMONGoose
{
    public sealed class PlayerInitializator
    {
        public PlayerInitializator(MainController mainController, PlayerData playerData)
        {
            var spawnedPlayer = Object.Instantiate(playerData.playerStruct.PlayerPrefab, 
                playerData.playerStruct.StartPosition, 
                Quaternion.identity);

            var playerStruct = playerData.playerStruct;
            playerStruct.PlayerPrefab = spawnedPlayer;

            var cubeModel = new PlayerModel(playerStruct);
            mainController.AddUpdatable(new PlayerController(cubeModel));
        }
    }
}
