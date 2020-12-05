using OMONGoose;
using UnityEngine;
using UnityEngine.UI;


namespace OMONGoose
{
    public sealed class WiresTaskView : BaseTaskView
    {
        #region Fields
    
        [SerializeField] private Slider _sliderRed;
        [SerializeField] private Slider _sliderBlue;
        [SerializeField] private Slider _sliderYellow;
        [SerializeField] private Slider _sliderPurple;
    
        #endregion
        
        
        #region Methods
    
        public override void Initialize()
        {
            base.Initialize();
            //_maxProgress = 4.0f;
        }
    
        public void OnRedSliderValueChanged(float value)
        {
            ChangeSliderValue(_sliderRed , value);
        }
        
        public void OnBlueSliderValueChanged(float value)
        {
            ChangeSliderValue(_sliderBlue , value);
        }
        
        public void OnYellowSliderValueChanged(float value)
        {
            ChangeSliderValue(_sliderYellow , value);
        }
        
        public void OnPurpleSliderValueChanged(float value)
        {
            ChangeSliderValue(_sliderPurple , value);
        }
        
        private void ChangeSliderValue(Slider slider, float value)
        {
            if (!(value >= 0.95f)) return;
            slider.value = 1.0f;
            if (!slider.interactable) return;
            AddProgress();
            slider.interactable = false;
        }
    
        private void AddProgress()
        {
            // _progress += 1.0f;
            // if (_progress >= _maxProgress)
            // {
            //     Completed();
            // }
        }
    
        #endregion
    }
}
