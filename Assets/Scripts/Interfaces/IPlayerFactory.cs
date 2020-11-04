using UnityEngine;

namespace OMONGoose
{
    public interface IPlayerFactory
    {
        CharacterController CreatePlayer();
    }
}