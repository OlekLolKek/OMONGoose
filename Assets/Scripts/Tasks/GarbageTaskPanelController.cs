using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace OMONGoose
{
    public class GarbageTaskPanelController : BaseTaskPanelController
    {
        private GarbageTaskView _garbageViewPanel;
        private Slider _slider;
        private Image _garbageCan;
        private Color _garbageCanColor;
        private Vector3 _garbageCanRotation = new Vector3(0.0f, 0.0f, 180.0f);
        private float _garbageCanTweenTime = 0.75f;
        private float _maxValue = 0.95f;

        
        public GarbageTaskPanelController(Canvas canvas, GameObject taskPanelPrefab) 
            : base(canvas, taskPanelPrefab)
        {
        }

        protected override void Activate()
        {
            base.Activate();
            _garbageViewPanel = (GarbageTaskView) _taskViewPanel;
            _slider = _garbageViewPanel.GarbageSlider;
            _slider.onValueChanged.AddListener(OnSliderValueChanged);
            _garbageCan = _garbageViewPanel.GarbageCan;
            _garbageCanColor = _garbageViewPanel.GarbageCanColor;
        }

        protected override void Deactivate()
        {
            base.Deactivate();
            _slider.onValueChanged.RemoveAllListeners();
        }

        private void OnSliderValueChanged(float value)
        {
            if (value >= _maxValue)
            {
                _slider.value = 1.0f;
                _slider.interactable = false;
                if (!_garbageViewPanel.IsDone)
                {
                    _garbageViewPanel.Completed();
                }

                _garbageCan.transform.DOScale(Vector3.zero, _garbageCanTweenTime);
                _garbageCan.transform.DORotate(_garbageCanRotation, _garbageCanTweenTime);
                _garbageCan.DOColor(_garbageCanColor, _garbageCanTweenTime);
            }
        }
    }
}