using OMONGoose.Minimap;
using UnityEngine;
using UnityEngine.PlayerLoop;


namespace OMONGoose
{
    public class MinimapController : IInitializable, IExecutable
    {
        private readonly MinimapView _minimapView;
        private readonly Transform _playerTransform;
        

        public MinimapController(MinimapView minimapView, Transform playerTransform)
        {
            _minimapView = minimapView;
            _playerTransform = playerTransform;
        }

        public void Initialization()
        {
            _minimapView.Initialization(_playerTransform);
        }

        public void Execute(float deltaTime)
        {
            _minimapView.UpdateMap();
        }
    }
}