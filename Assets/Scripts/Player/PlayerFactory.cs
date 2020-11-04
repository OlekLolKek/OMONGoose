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

        public CharacterController CreatePlayer()
        {
            //Так как игрок - не просто кружок, а полноценный персонаж с анимациями, решил заменить постепенное создание на префаб 
            //Возможно, поменяю позже на постепенное формирование игрока
            return Object.Instantiate(_playerData.PlayerPrefab).GetComponent<CharacterController>();
        }
    }
}