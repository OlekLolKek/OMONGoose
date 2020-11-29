using System;
using System.Net.Configuration;

namespace OMONGoose
{
    public class InteractionSwitch
    {
        public event Action<bool> OnInteraction = delegate (bool b) {  };

        public void Interaction()
        {
            OnInteraction.Invoke(true);
        }
    }
}