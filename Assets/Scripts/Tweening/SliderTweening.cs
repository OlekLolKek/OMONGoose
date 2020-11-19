using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace OMONGoose
{
    public sealed class SliderTweening : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        #region Fields

        [SerializeField] private AudioClipsData _audioClips;
        private AudioSource _audioSource;
        private readonly Vector3 _tweeningScale = new Vector3(1.05f, 1.05f, 1.05f);
        private readonly Vector3 _defaultScale = new Vector3(1.0f, 1.0f, 1.0f);
        private Slider _parentSlider;
        private float _tweeningTime = 0.05f;

        #endregion
        

        #region Methods

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _parentSlider = GetComponentInParent<Slider>();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!_parentSlider.interactable) return;
            LeanTween.scale(gameObject, _tweeningScale, _tweeningTime);
            _audioSource.clip = _audioClips.AudioClips.Woosh;
            _audioSource.Play();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!_parentSlider.interactable) return;
            LeanTween.scale(gameObject, _defaultScale, _tweeningTime);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!_parentSlider.interactable) return;
            LeanTween.scale(gameObject, _defaultScale, _tweeningTime);
            _audioSource.clip = _audioClips.AudioClips.Pop;
            _audioSource.Play();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!_parentSlider.interactable) return;
            LeanTween.scale(gameObject, _tweeningScale, _tweeningTime);
        }

        #endregion
    }
}