using OMONGoose.Minimap;
using UnityEngine;


namespace OMONGoose
{
    public sealed class MinimapController : IInitializable, IExecutable, ICleanable
    {
        private readonly MinimapView _minimapView;
        private readonly Transform _playerTransform;
        private readonly IInputKeyPressable _map1;
        private readonly IInputKeyPressable _map2;

        private bool _isMapFullscreen = false;
        

        public MinimapController(MinimapView minimapView, Transform playerTransform,
            (IInputKeyPressable Map1, IInputKeyPressable Map2) inputMap)
        {
            _minimapView = minimapView;
            Debug.Log(playerTransform);
            _playerTransform = playerTransform;
            _map1 = inputMap.Map1;
            _map2 = inputMap.Map2;
            _map1.OnKeyPressed += SwitchMap;
            _map2.OnKeyPressed += SwitchMap;
        }

        public void Initialization()
        {
            _minimapView.Initialization(_playerTransform);
        }

        public void Execute(float deltaTime)
        {
            _minimapView.UpdateMap();
        }

        private void SwitchMap(bool b)
        {
            if (_isMapFullscreen)
            {
                _minimapView.MinimizeMap();
            }
            else
            {
                _minimapView.MaximizeMap();
            }

            _isMapFullscreen = !_isMapFullscreen;
        }

        public void Cleanup()
        {
            _map1.OnKeyPressed -= SwitchMap;
            _map2.OnKeyPressed -= SwitchMap;
        }
    }
}