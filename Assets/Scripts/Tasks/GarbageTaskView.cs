using System.Collections;
using UnityEngine;
using UnityEngine.UI;


namespace  OMONGoose
{
    public sealed class GarbageTaskView : BaseTaskView
    {
        #region Fields

        [SerializeField] private Slider _garbageSlider;
        [SerializeField] private Image _garbageCan;

        private float _garbageCanRotation = 180.0f;
        private float _garbageCanTweenTime = 0.75f;

        #endregion


        #region Methods

        public void OnSliderValueChanged(float value)
        {
            if (value >= 0.95f)
            {
                _garbageSlider.value = 1.0f;
                _garbageSlider.interactable = false;
                if (!IsDone)
                {
                    Completed();
                }
                LeanTween.scale(_garbageCan.gameObject, Vector3.zero, _garbageCanTweenTime);
                LeanTween.rotateAround(_garbageCan.gameObject,
                    _garbageCan.transform.forward, 
                    _garbageCanRotation, 
                    _garbageCanTweenTime);
                LeanTween.alpha(_garbageCan.rectTransform, 0.0f, _garbageCanTweenTime);
            }
        }

        #endregion
    }
}
