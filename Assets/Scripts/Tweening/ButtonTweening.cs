using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace OMONGoose
{
    public sealed class ButtonTweening : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        #region Fields

        [SerializeField] private AudioClipsData _audioClips;

        private AudioSource _audioSource;
        private Vector3 _tweeningScale = new Vector3(1.05f, 1.05f, 1.05f);
        private Vector3 _defaultScale = new Vector3(1.0f, 1.0f, 1.0f);
        private Button _thisButton;
        private float _tweeningAngle = 3.0f;
        private float _defaultAngle = 0.0f;
        private float _tweeningTime = 0.05f;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _thisButton = GetComponent<Button>();
            _audioSource = GetComponent<AudioSource>();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!_thisButton.interactable) return;
            LeanTween.scale(gameObject, _tweeningScale, _tweeningTime);
            LeanTween.rotateZ(gameObject, _tweeningAngle, _tweeningTime);
            _audioSource.clip = _audioClips.AudioClips.Woosh;
            _audioSource.Play();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!_thisButton.interactable) return;
            LeanTween.scale(gameObject, _defaultScale, _tweeningTime);
            LeanTween.rotateZ(gameObject, _defaultAngle, _tweeningTime);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!_thisButton.interactable) return;
            LeanTween.scale(gameObject, _defaultScale, _tweeningTime);
            _audioSource.clip = _audioClips.AudioClips.Pop;
            _audioSource.Play();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!_thisButton.interactable) return;
            LeanTween.scale(gameObject, _tweeningScale, _tweeningTime);
        }

        #endregion
    }
}