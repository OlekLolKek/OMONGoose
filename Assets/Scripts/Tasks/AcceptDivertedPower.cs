using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace OMONGoose
{
    public class AcceptDivertedPower : BaseTask
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _wires;
        [SerializeField] private Color _wiresColor;


        public override void Initialize(RoomNames roomName, Canvas canvas)
        {
            base.Initialize(roomName, canvas);
            _button.onClick.AddListener(OnButtonPressed);
        }

        private void OnButtonPressed()
        {
            Completed();
            _button.transform.DORotate(new Vector3(0.0f, 0.0f, 90.0f), _tweenTime);
            _wires.DOColor(_wiresColor, _tweenTime);
            _button.interactable = false;
        }
    }
}