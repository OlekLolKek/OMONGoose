using UnityEngine;


namespace OMONGoose.Minimap
{
    public sealed class MinimapView : MonoBehaviour
    {
        [SerializeField] private GameObject _minimapRoot;
        [SerializeField] private RectTransform _minimapRectTransform;
        [SerializeField] private Transform _minimapRotation;
        
        [SerializeField] private GameObject _mapSprite;
        [SerializeField] private RectTransform _playerDotRectTransform;
        
        private Transform _playerTransform;
        
        private float _minimapRatio = 500.0f / 135.0f;
        private float _mapRatio = 750 / 135.0f;
        private bool _isMaximized;

        public void Initialization(Transform playerTransform)
        {
            _playerTransform = playerTransform;
        }
        
        public void UpdateMap()
        {
            if (_isMaximized)
            {
                var playerPosition = _playerTransform.position;
                var newPosition = new Vector3(playerPosition.x, playerPosition.z, 0.0f);
                _playerDotRectTransform.anchoredPosition = newPosition * _mapRatio;
            }
            else
            {
                var rotation = new Vector3(0.0f, 0.0f, _playerTransform.eulerAngles.y);
                _minimapRotation.rotation = Quaternion.Euler(rotation);
            
                var playerPosition = _playerTransform.position;
                var newPosition = new Vector3(playerPosition.x, playerPosition.z, 0.0f);
                _minimapRectTransform.anchoredPosition = -newPosition * _minimapRatio;
            }
        }

        public void MaximizeMap()
        {
            _isMaximized = true;
            _minimapRoot.SetActive(false);
            _mapSprite.SetActive(true);
        }

        public void MinimizeMap()
        {
            _isMaximized = false;
            _minimapRoot.SetActive(true);
            _mapSprite.SetActive(false);
        }
    }
}