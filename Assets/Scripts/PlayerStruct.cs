using UnityEngine;
using System;


namespace OMONGoose
{
    [Serializable]
    public class PlayerStruct : MonoBehaviour
    {
        public GameObject PlayerPrefab;
        public Vector3 StartPosition;
        public float PlayerSpeed;
    }
}