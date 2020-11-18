using UnityEngine;


namespace OMONGoose.Minimap
{
    public sealed class MinimapView : MonoBehaviour
    {
        [SerializeField] private Transform _minimap;

        private RectTransform _minimapRectTransform;
        private Transform _playerTransform;

        // Размеры карты и миникарты я высчитал вручную, так что тут придётся оставить числа. Другого способа не нашёл.
        private float _ratio = 500.0f / 135.0f;

        public void Initialization(Transform playerTransform)
        {
            _minimapRectTransform = _minimap.GetComponent<RectTransform>();
            _playerTransform = playerTransform;
        }
        
        public void UpdateMap()
        {
            var rotation = new Vector3(0.0f, 0.0f, _playerTransform.eulerAngles.y);
            transform.rotation = Quaternion.Euler(rotation);
            
            var playerPosition = _playerTransform.position;
            var newPosition = new Vector3(playerPosition.x, playerPosition.z, 0.0f);
            _minimapRectTransform.anchoredPosition = -newPosition * _ratio;
        }
    }
}