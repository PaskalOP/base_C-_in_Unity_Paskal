using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class MainForHomeWork7 : MonoBehaviour
    {
        private List<int> _listHomeWork7;
        

        void Awake()
        {
            _listHomeWork7 = new List<int>();

            _listHomeWork7.Add(5);
            _listHomeWork7.Add(4);
            _listHomeWork7.Add(4);
            _listHomeWork7.Add(1);
            _listHomeWork7.Add(1);
            _listHomeWork7.Add(1);
            _listHomeWork7.Add(1);
            _listHomeWork7.Add(1);

            CountElements(_listHomeWork7);

            

    }
        private void CountElements(List<int> list)
        {
            list = _listHomeWork7;

            for (int i = 0; i < list.Count; i++)
            {
                int countElements = 0;
                for (int l = 0; l < list.Count; l++)
                {
                    if (list[i] == list[l])
                    {
                        countElements++;

                    }
                }
                string mass = ("Элемент " + _listHomeWork7[i] + " встречается  " + countElements + " раз в листе");
                Debug.Log(mass);

            }
        }

    }
}
