using UnityEngine;
using System.Collections.Generic;


namespace OMONGoose
{
    public class MainController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private PlayerData _player;

        private List<IUpdatable> _iUpdatebles = new List<IUpdatable>();

        #endregion


        #region UnityMethods

        private void Start()
        {
            new InitializeController(this, _player);
        }

        private void Update()
        {
            for (int i = 0; i < _iUpdatebles.Count; i++)
            {
                _iUpdatebles[i].UpdateTick();
            }
        }

        #endregion


        #region Methods

        public void AddUpdatable(IUpdatable iUpdatable)
        {
            _iUpdatebles.Add(iUpdatable);
        }

        #endregion
    }
}

