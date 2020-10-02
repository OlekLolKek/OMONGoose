using UnityEngine;


namespace OMONGoose
{
    public class FootstepEvent : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void Step()
        {
            _audioSource.Play();
        }
    }
}