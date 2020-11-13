using System;
using UnityEngine;


namespace OMONGoose
{
    [Serializable]
    public struct QuaternionSerializable
    {
        public float X;
        public float Y;
        public float Z;
        public float W;

        private QuaternionSerializable(float valueX, float valueY, float valueZ, float valueW)
        {
            X = valueX;
            Y = valueY;
            Z = valueZ;
            W = valueW;
        }

        public static implicit operator Quaternion(QuaternionSerializable value)
        {
            return new Quaternion(value.X, value.Y, value.Z, value.W);
        }

        public static implicit operator QuaternionSerializable(Quaternion value)
        {
            return new QuaternionSerializable(value.x, value.y, value.z, value.w);
        }
    }
}