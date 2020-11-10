using System;
using System.Net.Configuration;

namespace OMONGoose
{
    public class InteractionSwitch
    {
        public event Action<bool> OnInteraction = delegate (bool b) {  };
        private bool _isInteracting = false;

        public void SwitchInteraction()
        {
            if (_isInteracting)
            {
                _isInteracting = false;
            }
            else
            {
                _isInteracting = true;
            }
            OnInteraction.Invoke(_isInteracting);
        }
    }
}