using UnityEngine;

namespace OMONGoose
{
    public interface IPlayerFactory
    {
        void CreatePlayer();
        CharacterController GetCharacterController();
        Transform GetTransform();
        Camera GetCamera();
    }
}