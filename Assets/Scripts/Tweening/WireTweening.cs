using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace OMONGoose
{
    public sealed class WireTweening : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
    {
        #region Fields

        [SerializeField] private AudioClipsSO _audioClips;
        private AudioSource _audioSource;
        private Slider _parentSlider;

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
            _audioSource.clip = _audioClips.AudioClips.Woosh;
            _audioSource.Play();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!_parentSlider.interactable) return;
            _audioSource.clip = _audioClips.AudioClips.WireBuzz;
            _audioSource.Play();
        }
        
        #endregion
    }
}