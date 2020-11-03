using UnityEngine;
using UnityEngine.UI;


namespace OMONGoose
{
    internal sealed class MobileInputFactory : IMobileInputFactory
    {
        //TODO: Разобраться (да, опять) что за gameObject и назвать его нормально
        private readonly Transform _root;
        private readonly Button _gameObject;

        public MobileInputFactory(Transform root, Button gameObject)
        {
            _root = root;
            _gameObject = gameObject;
        }

        public Button Create()
        {
            return Object.Instantiate(_gameObject, _root);
        }
    }
}