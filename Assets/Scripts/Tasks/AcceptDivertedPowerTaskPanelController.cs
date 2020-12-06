using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace OMONGoose
{
    public class AcceptDivertedPowerTaskPanelController : BaseTaskPanelController
    {
        private AcceptDivertedPowerView _acceptTaskViewPanel;
        private Vector3 _rotation = new Vector3(0.0f, 0.0f, 90.0f);
        private Color _wiresColor;
        private Button _button;
        private Image _wires;

        
        public AcceptDivertedPowerTaskPanelController(Canvas canvas, GameObject taskPanelPrefab) 
            : base(canvas, taskPanelPrefab)
        {
        }

        protected override void Activate()
        {
            base.Activate();
            _acceptTaskViewPanel = (AcceptDivertedPowerView) _taskViewPanel;
            _button = _acceptTaskViewPanel.Button;
            _button.onClick.AddListener(OnButtonPressed);
            _wires = _acceptTaskViewPanel.Wires;
            _wiresColor = _acceptTaskViewPanel.WiresColor;
        }

        protected override void Deactivate()
        {
            base.Deactivate();
            _button.onClick.RemoveAllListeners();
        }

        private void OnButtonPressed()
        {
            _acceptTaskViewPanel.Completed();
            _button.transform.DORotate(_rotation, _tweenTime);
            _button.interactable = false;
            _wires.DOColor(_wiresColor, _tweenTime);
        }
    }
}