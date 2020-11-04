using UnityEngine;
using UnityEngine.Serialization;


namespace OMONGoose
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player")]
    public sealed class PlayerData : ScriptableObject, IUnit
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField, Range(1, 10)] private float _speed;
        public GameObject PlayerPrefab => _playerPrefab;
        public float Speed => _speed;
    }
}