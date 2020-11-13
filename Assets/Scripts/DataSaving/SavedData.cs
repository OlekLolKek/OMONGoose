using System;
using UnityEngine;


namespace OMONGoose
{
    [Serializable]
    public sealed class SavedData
    {
        #region Fields

        public string Name;
        public Vector3Serializable Position;
        public QuaternionSerializable Rotation;
        public bool IsEnabled;

        #endregion
        
        public override string ToString()
        {
            return $"Name = {Name};\n Position = {Position.X}, {Position.Y}, {Position.Z};\n Rotation = {Rotation.X}, {Rotation.Y}, {Rotation.Z}, {Rotation.W}; IsVisible = {IsEnabled};";
        }
    }
}