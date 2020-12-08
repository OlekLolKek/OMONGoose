using DG.Tweening;
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
        private readonly Vector3 _tweeningScale = new Vector3(1.05f, 1.05f, 1.05f);
        private readonly Vector3 _defaultScale = new Vector3(1.0f, 1.0f, 1.0f);
        private readonly Vector3 _tweeningAngle = new Vector3(0.0f, 0.0f, 3.0f);
        private Button _thisButton;

        private readonly float _defaultAngle = 0.0f;
        private readonly float _tweeningTime = 0.05f;

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
            transform.DOScale(_tweeningScale, _tweeningTime);
            transform.DORotate(_tweeningAngle, _tweeningTime);
            _audioSource.clip = _audioClips.AudioClips.Woosh;
            _audioSource.Play();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!_thisButton.interactable) return;
            transform.DOScale(_defaultScale, _tweeningTime);
            transform.DORotate(Vector3.zero, _tweeningTime);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!_thisButton.interactable) return;
            transform.DOScale(_defaultScale, _tweeningTime);
            _audioSource.clip = _audioClips.AudioClips.Pop;
            _audioSource.Play();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!_thisButton.interactable) return;
            transform.DOScale(_tweeningScale, _tweeningTime);
        }

        #endregion
    }
}