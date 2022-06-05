using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Maze
{
    public sealed class ListexecutivObject : IEnumerable, IEnumerator
    {
        //поля

        private IExecute[] _interactiveObject; //создаем массив из интерактивных обектов, у которых есть интвервейс IExecute
        private int _index = -1;//создаем индейк для пользования массивом

    //свойства
    public object Current => _interactiveObject[_index]; // получение индекса интерактивного обекта
        public int Length => _interactiveObject.Length; //получение длины массива интерактивных обектов

        public ListexecutivObject()
        {
            Bonus[] listBonus = Object.FindObjectsOfType<Bonus>();
            for (int i = 0; i< listBonus.Length; i++)
            {
                if(listBonus[i] is IExecute execute)
                {
                    AddExecuteObject(execute);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        // переходим к следующему интерактивному обьекту
        public bool MoveNext()
        {
            if (_index== Length - 1)
            {
                Reset();
                return false;
            }

            _index++;
            return true;
        }
        //сброс индекса, после того как все обьекты перечислены
        public void Reset()
        {
            _index = -1;
        }
        //добавляем новый обьект в массив
        public void AddExecuteObject(IExecute exe)
        {
            if (_interactiveObject == null)
            {
                _interactiveObject = new[] { exe };
                return;
            }

            Array.Resize(ref _interactiveObject, Length + 1);
            _interactiveObject[Length - 1] = exe;
        }

        public IExecute this [int curr]
        {
            get => _interactiveObject[curr];
            private set => _interactiveObject[curr] = value;
        }
    }

}
