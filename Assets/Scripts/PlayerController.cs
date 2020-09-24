using UnityEngine;


namespace OMONGoose
{
    public sealed class PlayerController : IUpdatable
    {
        private PlayerModel _playerModel;

        public PlayerController(PlayerModel playermodel)
        {
            _playerModel = playermodel;
        }

        public void UpdateTick()
        {
            _playerModel.PlayerStruct.PlayerPrefab.transform.position +=
                _playerModel.PlayerStruct.PlayerPrefab.transform.forward *
                _playerModel.PlayerStruct.PlayerSpeed * Time.deltaTime;
        }
    }
}