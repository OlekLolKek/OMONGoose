using UnityEngine;
using UnityEngine.Serialization;


namespace OMONGoose
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player")]
    public sealed class PlayerData : ScriptableObject, IUnit
    {
        #region Fields

        [SerializeField] private GameObject _playerPrefab;
        [SerializeField, Range(0, 10)] private float _speed;
        [SerializeField, Range(0, 100)] private float _sensitivity;
        [SerializeField, Range(-180, 180)] private float _minXRotation;
        [SerializeField, Range(-180, 180)] private float _maxXRotation;

        #endregion


        #region Properties

        public GameObject PlayerPrefab => _playerPrefab;
        public float Speed => _speed;
        public float Sensitivity => _sensitivity;
        public float MinXRotation => _minXRotation;
        public float MaxXRotation => _maxXRotation;

        #endregion
    }
}