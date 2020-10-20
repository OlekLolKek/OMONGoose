using UnityEngine;


namespace OMONGoose
{
    public sealed class PlayerInitializator
    {
        public PlayerInitializator(MainController mainController, PlayerData playerData, GameContext links)
        {
            var player = GameObject.FindGameObjectWithTag("Player");

            var playerStruct = playerData.playerStruct;
            playerStruct.Player = player;

            var playerModel = new PlayerModel(playerStruct);
            mainController.AddUpdatable(new PlayerController(playerModel, links));
        }
    }
}
