using UnityEngine;


namespace OMONGoose.Minimap
{
    public sealed class MinimapView : MonoBehaviour
    {
        [SerializeField] private GameObject _minimapRoot;
        [SerializeField] private Transform _minimapSprite;
        [SerializeField] private Transform _minimapRotation;
        
        [SerializeField] private GameObject _mapSprite;
        [SerializeField] private Transform _playerDot;

        private RectTransform _minimapRectTransform;
        private RectTransform _playerRectTransform;
        private Transform _playerTransform;

        // Размеры карты и миникарты я высчитал вручную, так что тут придётся оставить числа. Другого способа не нашёл.
        private float _minimapRatio = 500.0f / 135.0f;
        private float _mapRatio = 750 / 135.0f;
        private bool _isMaximized = false;

        public void Initialization(Transform playerTransform)
        {
            _minimapRectTransform = _minimapSprite.GetComponent<RectTransform>();
            _playerRectTransform = _playerDot.GetComponent<RectTransform>();
            _playerTransform = playerTransform;
        }
        
        public void UpdateMap()
        {
            if (_isMaximized)
            {
                var playerPosition = _playerTransform.position;
                var newPosition = new Vector3(playerPosition.x, playerPosition.z, 0.0f);
                _playerRectTransform.anchoredPosition = newPosition * _mapRatio;
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