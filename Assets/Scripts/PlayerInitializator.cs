using UnityEngine;

namespace OMONGoose
{
    public sealed class PlayerInitializator
    {
        public PlayerInitializator(MainController mainController, PlayerData playerData)
        {
            var spawnedPlayer = Object.Instantiate(playerData.Struct.PlayerPrefab, playerData.Struct.StartPosition, Quaternion.identity);

            var playerStruct = playerData.Struct;
            playerStruct.PlayerPrefab = spawnedPlayer;

            var cubeModel = new PlayerModel(playerStruct);
            mainController.AddUpdatable(new PlayerController(cubeModel));
        }
    }
}
