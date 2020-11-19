using UnityEngine;
using UnityEngine.Serialization;


namespace OMONGoose
{
    [CreateAssetMenu(fileName = "InputData", menuName = "Data/Input")]
    public sealed class InputData : ScriptableObject
    {
        public InputStruct InputStruct;
    }
}