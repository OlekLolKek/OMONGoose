using System;


namespace OMONGoose
{
    [Serializable]
    public sealed class SavedData
    {
        #region Fields

        public string PlayerName;
        public Vector3Serializable PlayerPosition;
        public QuaternionSerializable PlayerRotation;
        public QuaternionSerializable CameraRotation;
        public bool IsEnabled;
        public int DoneTasksAmount;
        public bool[] TasksDone;

        #endregion
        
        public override string ToString()
        {
            return $"PlayerName = {PlayerName};\n PlayerPosition = {PlayerPosition};\n PlayerRotation = {PlayerRotation};\n CameraRotation = {CameraRotation} IsVisible = {IsEnabled};";
        }
    }
}