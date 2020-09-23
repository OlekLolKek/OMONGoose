using UnityEngine;


namespace OMONGoose
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player")]
    public sealed class PlayerData : ScriptableObject
    {
        public PlayerStruct Struct;
    }
}