using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Maze
{
    public class ViewGameOver
    {
        private Text _gameOverText;

        public ViewGameOver(GameObject gameOverTextPref)
        {
            _gameOverText = gameOverTextPref.GetComponent<Text>();
            _gameOverText.text = string.Empty;
        }

        public void GameOver(string name, Color color)
        {
            _gameOverText.text = $"Game Over. Bonus name: {name}. Цвет: {color} ";
        }
    }
}

