using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{

    public abstract class Bonus : MonoBehaviour, IExecute
    {
        //поле включен или выключен обьект
        private bool _isInteractable;

        //определяем расположение обьекта
        public Transform _transform;

        //Свойство как именно включается и выключается наш обьект
        public bool IsInteractable
        {
            get { return _isInteractable; }
            private set
            {
                _isInteractable = value;
                GetComponent<Renderer>().enabled = value;
                GetComponent<Collider>().enabled = value;
            }

        }

        // получаем ссылку на трансформ обьекта
        private void Awake()
        {
            _transform = GetComponent<Transform>();
        }

        //включаем рендер и коллаидр бонуса
        public void Start()
        {
            IsInteractable = true;
            
        }

        public abstract void Update();
        public abstract void Interaction();

        //при столкновении с тригером выполняем метод и выключаем обьект бонуса
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Interaction();
                IsInteractable = false;

            }

        }

    }

}
