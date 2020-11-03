using UnityEngine;


namespace OMONGoose
{
    [CreateAssetMenu(fileName = "AudioClips", menuName = "Data/Audio Clips")]
    public sealed class AudioClipsData : ScriptableObject
    {
        public AudioClips AudioClips;
    }
}