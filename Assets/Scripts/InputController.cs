using UnityEngine;


namespace OMONGoose
{
    public sealed class InputController : IUpdatable
    {
        public float Horizontal;
        public float Vertical;

        public void UpdateTick()
        {
            Horizontal = Input.GetAxis("Horizontal");
            Vertical = Input.GetAxis("Vertical");
        }
    }
}
