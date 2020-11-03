using UnityEngine;


namespace OMONGoose
{
    public sealed class PlayerFactory : IPlayerFactory
    {
        private readonly PlayerData _playerData;

        public PlayerFactory(PlayerData playerData)
        {
            _playerData = playerData;
        }

        public Transform CreatePlayer()
        {
            //Так как игрок - не просто кружок, а полноценный персонаж с анимациями, решил заменить постепенное создание на префаб 
            //Возможно, поменяю позже
            return Object.Instantiate(_playerData.PlayerStruct.Player).transform;
        }
    }
}