using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Maze
{
    public class Main : MonoBehaviour
    {
        private InputController _inputController;
        [SerializeField] private GameObject _player;
        

        private ListexecutivObject _interactiveObject;
       // [SerializeField] private BadBonus badBonus;

        private Reference _reference;
        private ViewBonus _viewBonus;
        private ViewGameOver _viewGameOver;

        private int _bonusCount;

        [SerializeField] private Button _restart;

        private CameraController _cameraController;
       

        void Awake()
        {
            Time.timeScale = 1f;
            _inputController = new InputController(_player.GetComponent<Unit>());
            _interactiveObject = new ListexecutivObject();
            _interactiveObject.AddExecuteObject(_inputController);
            
           
            _reference = new Reference();
             _viewBonus = new ViewBonus(_reference.BonusText, _reference.YouWinText);
             _viewGameOver = new ViewGameOver(_reference.GameOverText);

             _restart.onClick.AddListener(RestartGame);
             _restart.gameObject.SetActive(false);

            _cameraController = new CameraController(_player.transform, _reference.MainCamera.transform);
            _interactiveObject.AddExecuteObject(_cameraController);

            foreach (var item in _interactiveObject)
             {
                if (item is GoodBonus goodBonus)
                {
                    goodBonus.TakeGoodBonus += AddBonus;

                   
                }
                    
                if(item is BadBonus badBonus)
                {
                   
                    badBonus.OnCoughtPl += _viewGameOver.GameOver;
                    badBonus.OnCoughtPl += GameEnd;
                }
             }

            

        }

            public void GameEnd(string name, Color color)
        {
           
            _restart.gameObject.SetActive(true);
            Time.timeScale = 0f;
            

        }
            void Update()
            {
                for (int i = 0; i < _interactiveObject.Length; i++)
                {
                    if (_interactiveObject[i] == null)
                    {
                        continue;
                    }
                    _interactiveObject[i].Update();
                }
            }

        private void RestartGame()
        {
            SceneManager.LoadScene(0);
        }

    
        private void AddBonus(int _point)
            {
                _bonusCount += _point;
            _viewBonus.Dysplay(_bonusCount);
            if(_bonusCount==5)
                _restart.gameObject.SetActive(true);


        }
      
            
    }

}

