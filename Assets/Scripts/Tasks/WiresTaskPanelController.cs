using UnityEngine;
using UnityEngine.UI;

namespace OMONGoose
{
    public class WiresTaskPanelController : BaseTaskPanelController
    {
        private WiresTaskView _wiresTaskPanel;
        private Slider _redSlider;
        private Slider _blueSlider;
        private Slider _yellowSlider;
        private Slider _purpleSlider;
        private float _maxSliderValue = 0.95f;
        
        public WiresTaskPanelController(Canvas canvas, GameObject taskPanelPrefab) : base(canvas, taskPanelPrefab)
        {
            _maxProgress = 4.0f;
        }

        protected override void Activate()
        {
            base.Activate();
            _wiresTaskPanel = (WiresTaskView) _taskViewPanel;
            _redSlider = _wiresTaskPanel.SliderRed;
            _blueSlider = _wiresTaskPanel.SliderBlue;
            _yellowSlider = _wiresTaskPanel.SliderYellow;
            _purpleSlider = _wiresTaskPanel.SliderPurple;
            
            _redSlider.onValueChanged.AddListener(OnRedSliderValueChanged);
            _blueSlider.onValueChanged.AddListener(OnBlueSliderValueChanged);
            _yellowSlider.onValueChanged.AddListener(OnYellowSliderValueChanged);
            _purpleSlider.onValueChanged.AddListener(OnPurpleSliderValueChanged);
        }

        protected override void Deactivate()
        {
            base.Deactivate();
            _redSlider.onValueChanged.RemoveAllListeners();
            _blueSlider.onValueChanged.RemoveAllListeners();
            _yellowSlider.onValueChanged.RemoveAllListeners();
            _purpleSlider.onValueChanged.RemoveAllListeners();
        }

        private void OnRedSliderValueChanged(float value)
        {
            ChangeSliderValue(_redSlider, value);
        }
        
        private void OnBlueSliderValueChanged(float value)
        {
            ChangeSliderValue(_blueSlider, value);
        }
        
        private void OnYellowSliderValueChanged(float value)
        {
            ChangeSliderValue(_yellowSlider, value);
        }
        
        private void OnPurpleSliderValueChanged(float value)
        {
            ChangeSliderValue(_purpleSlider, value);
        }

        private void ChangeSliderValue(Slider slider, float value)
        {
            if (value < _maxSliderValue) return;
            slider.value = 1.0f;
            if (!slider.interactable) return;
            AddProgress();
            slider.interactable = false;
        }

        private void AddProgress()
        {
            _progress += 1.0f;
            Debug.Log(_progress);
            if (_progress >= _maxProgress)
            {
                _wiresTaskPanel.Completed();
            }
        }
    }
}