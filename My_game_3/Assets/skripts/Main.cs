using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class Main : MonoBehaviour
    {
        private InputController _inputController;
        [SerializeField] private GameObject _player;
        private ListexecutivObject _interactiveObject;

        
        void Awake ()
        {
            _inputController = new InputController(_player.GetComponent<Unit>());
            _interactiveObject = new ListexecutivObject();
            _interactiveObject.AddExecuteObject(_inputController);
            
        }

        
        void Update()
        {
            for (int i=0; i< _interactiveObject.Length; i++)
            {
                if (_interactiveObject[i] == null)
                {
                    continue;
                }
                _interactiveObject[i].Update();
            }
        }
    }
}
