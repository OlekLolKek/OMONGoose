using UnityEngine;
using System;


namespace OMONGoose
{
    [Serializable]
    public struct PlayerStruct
    {
        public GameObject PlayerPrefab;
        public Vector3 StartPosition;
        public float PlayerSpeed;
    }
}