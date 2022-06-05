using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class Reference
    {
        public GameObject _bonusText;
        public GameObject _gameOverText;
        public GameObject _restartButton;
        public GameObject _youWinText;
        public Camera _mainCamera;
        public Canvas _canvas;

        public GameObject BonusText
        {
            get
            { if (_bonusText==null)
                {
                    GameObject BonusPref = Resources.Load<GameObject>("Bonus");
                    _bonusText = Object.Instantiate(BonusPref, Canvas.transform);
                }
                return _bonusText;

            }
            set { _bonusText = value; }

        }

        public GameObject GameOverText
        {

            get
            {
                if (_gameOverText == null)
                {
                    GameObject GameOverTextPref = Resources.Load<GameObject>("GameOver_text");
                    _gameOverText = Object.Instantiate(GameOverTextPref, Canvas.transform);
                }
                return _gameOverText;
            }
            set { _gameOverText = value; }

        }

        public GameObject RestartButton
        {
            get
            {
                if (_restartButton == null)
                {
                    GameObject restartPref = Resources.Load<GameObject>("Restart");
                    _restartButton = Object.Instantiate(restartPref, Canvas.transform);
                }
                return _restartButton;
            }
            set { _restartButton = value; }
        }

        public GameObject YouWinText
        {
            get
            {
                if (_youWinText == null)
                {
                    GameObject youWinPref = Resources.Load<GameObject>("YouWinPref");
                    _youWinText = Object.Instantiate(youWinPref, Canvas.transform);
                }
                return _youWinText;

            }
            set
            {
                _youWinText = value;
            }
        }

        public Camera MainCamera
        {
            get
            {
                if (!_mainCamera)
                {
                    _mainCamera = Camera.main;
                }
                
                return _mainCamera;
            }
            set { _mainCamera = value; }
        }

        public Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                {
                    _canvas = Object.FindObjectOfType<Canvas>();
                }
                return _canvas; 
            }
            
            set { _canvas = value; }
        }
    }

}

