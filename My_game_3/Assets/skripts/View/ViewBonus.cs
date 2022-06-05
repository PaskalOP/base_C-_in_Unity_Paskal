using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Maze
{
    public class ViewBonus
    {
        private Text _bonusText;
        private Text _youWin;

        public ViewBonus(GameObject bonusTextPref, GameObject youWinPref)
        {
            _bonusText = bonusTextPref.GetComponent<Text>();
            _bonusText.text = string.Empty;

            _youWin = youWinPref.GetComponent<Text>();
            _youWin.text = string.Empty;
        }

        public void Dysplay(int value)
        {
            if (value < 5)
            {
                _bonusText.text = ("Bonus:" + value);
            }
            if (value == 5)
            {
                _bonusText.text = string.Empty;
                _youWin.text = ("You WIN! \n Bonus: " + value);
                Time.timeScale = 0f;

            }
            
        }
    }
}

