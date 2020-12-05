using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


namespace OMONGoose
{
    public class StabilizeSteering : BaseTaskViewExecutable
    {
        #region Fields

        [SerializeField] private GameObject _crosshairPrefab;
        [SerializeField] private Transform _crosshairParent;
        [SerializeField] private Color _finalCrossColor;
        private Image _crosshair;
        private float _canvasScaleFactor;
        private float _circleRadius;
        private float _originalSpriteRatio = 98.0f / 128.0f;
        private float _maxDistance;
        private float _doneDistance = 20.0f;

        #endregion


        #region Methods

        public override void Initialize()
        {
            base.Initialize();

            var rectTransform = GetComponent<RectTransform>();
            _circleRadius = rectTransform.sizeDelta.x / 2;
            //_maxDistance = _canvas.scaleFactor * _circleRadius * _originalSpriteRatio;
            _crosshair = Instantiate(
                _crosshairPrefab,
                _crosshairParent
            ).GetComponent<Image>();
            _crosshair.transform.localPosition = new Vector3(
                Random.Range(-_maxDistance / 2, _maxDistance / 2),
                Random.Range(-_maxDistance / 2, _maxDistance / 2),
                0);
        }

        public override void Execute(float deltaTime)
        {
            MoveCrosshair();
        }

        private void MoveCrosshair()
        {
            if (IsDone) return;
            if (Input.GetKey(AxisManager.LEFT_MOUSE_BUTTON))
            {
                var positionFromCenter = new Vector2(Screen.width / 2 - Input.mousePosition.x, 
                    Screen.height / 2 - Input.mousePosition.y);
                if (positionFromCenter.magnitude < _maxDistance)
                {
                    _crosshair.transform.position = Input.mousePosition;
                    if (positionFromCenter.magnitude < _doneDistance)
                    {
                        Completed();
                        _crosshair.transform.localPosition = Vector3.zero;
                        _crosshair.DOColor(_finalCrossColor, _tweenTime);
                    }
                }
            }
        }

        #endregion
    }
}