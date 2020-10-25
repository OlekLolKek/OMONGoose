using UnityEngine;
using UnityEngine.Serialization;


namespace OMONGoose
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player")]
    public sealed class PlayerData : ScriptableObject
    {
        public PlayerStruct PlayerStruct;
    }
}