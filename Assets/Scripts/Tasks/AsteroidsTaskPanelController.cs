using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OMONGoose
{
    public class AsteroidsTaskPanelController : BaseTaskPanelControllerExecute
    {
        #region Fields

        private AsteroidsTaskView _asteroidsTaskViewPanel;
        private AsteroidView _asteroidPrefab;
        
        private readonly List<AsteroidController> _asteroids = new List<AsteroidController>();
        
        private Image _taskImage;
        private Vector2 _sizeDelta;
        private readonly float _canvasScaleFactor;
        private readonly float _startOffset = 150.0f;
        private float _maxRight;
        private float _maxLeft;
        private float _maxDown;
        private float _maxUp;
        private int _asteroidsCount = 10;

        #endregion

        
        #region Methods
        
        public AsteroidsTaskPanelController(Canvas canvas, GameObject taskPanelPrefab) 
            : base(canvas, taskPanelPrefab)
        {
            _maxProgress = 10.0f;
            _canvasScaleFactor = canvas.scaleFactor;
            _startOffset *= _canvasScaleFactor / 2;
        }

        public override void Execute(float deltaTime)
        {
            foreach (var asteroid in _asteroids)
            {
                asteroid.Execute(deltaTime);
            }
        }

        protected override void Activate()
        {
            base.Activate();
            Links();
            CalculateScreenBorders();
            CreateAsteroids();
        }

        private void Links()
        {
            _asteroidsTaskViewPanel = (AsteroidsTaskView) _taskViewPanel;
            _asteroidPrefab = _asteroidsTaskViewPanel.AsteroidViewPrefab;
            _taskImage = _taskViewPanel.GetComponent<Image>();
            _sizeDelta = _taskImage.rectTransform.sizeDelta;
        }

        private void CalculateScreenBorders()
        {
            _maxLeft = Screen.width / 2 - _sizeDelta.x * _canvasScaleFactor / 2;
            _maxRight = Screen.width / 2 + _sizeDelta.x * _canvasScaleFactor / 2;
            _maxDown = Screen.height / 2 - _sizeDelta.y * _canvasScaleFactor / 2;
            _maxUp = Screen.height / 2 + _sizeDelta.y * _canvasScaleFactor / 2;
        }

        private void CreateAsteroids()
        {
            for (int i = 0; i < _asteroidsCount; i++)
            {
                var i1 = i;
                var asteroid = new AsteroidController(i1, _maxRight, _maxLeft,
                    _maxUp, _maxDown, _startOffset,
                    _asteroidPrefab, _canvas);
                _asteroids.Add(asteroid);
                _asteroids[i].OnAsteroidDestroyed += DestroyAsteroid;
            }
        }

        private void DestroyAsteroid(int index)
        {
            _progress++;
            if (_progress >= _maxProgress)
            {
                _taskViewPanel.Completed();
            }
        }

        protected override void Deactivate()
        {
            base.Deactivate();
            foreach (var asteroid in _asteroids)
            {
                asteroid.DestroyGameObject();
            }
            
            _asteroids.Clear();
        }

        #endregion
    }
}