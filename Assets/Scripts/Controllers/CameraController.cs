using UnityEngine;


namespace OMONGoose
{
    public class CameraController : IExecutable
    {
        private readonly Transform _player;
        private readonly Transform _camera;

        public CameraController(Transform player, Transform camera)
        {
            _player = player;
            _camera = camera;
        }

        public void Execute(float deltaTime)
        {
            
        }
    }
}