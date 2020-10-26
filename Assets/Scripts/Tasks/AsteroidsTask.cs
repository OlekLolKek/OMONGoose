using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


namespace OMONGoose
{
    public class AsteroidsTask : BaseTask
    {
        #region Fields

        [SerializeField] private GameObject _asteroidButtonPrefab;
        private Image[] _asteroids = new Image[10];

        #endregion
        
        
        #region Methods

        public override void Initialize(TaskController taskController, RoomNames roomName)
        {
            base.Initialize(taskController, roomName);
            _maxProgress = 10.0f;
            for (int i = 0; i < _asteroids.Length; i++)
            {
                _asteroids[i] = Instantiate(
                    _asteroidButtonPrefab,
                    transform).GetComponent<Image>();
            }
        }

        #endregion
    }
}