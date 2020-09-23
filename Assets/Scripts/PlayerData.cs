using UnityEngine;


namespace OMONGoose
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerData")]
    public sealed class PlayerData : ScriptableObject
    {
        public PlayerStruct Struct;
    }
}