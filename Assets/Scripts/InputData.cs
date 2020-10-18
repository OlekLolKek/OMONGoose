using UnityEngine;


namespace OMONGoose
{
    [CreateAssetMenu(fileName = "InputData", menuName = "Data/Input")]
    public sealed class InputData : ScriptableObject
    {
        public InputStruct inputStruct;
    }
}