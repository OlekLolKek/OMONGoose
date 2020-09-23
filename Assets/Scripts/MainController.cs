using UnityEngine;
using System.Collections.Generic;


namespace OMONGoose
{
    public class MainController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private PlayerData _player;

       // private List<IUpdateble> _iUpdatebles = new List<IUpdateble>();

        #endregion


        #region UnityMethods

        private void Start()
        {
          //  new InitializeController(this, _player);
        }

        private void Update()
        {
            
        }

        #endregion

    }
}

