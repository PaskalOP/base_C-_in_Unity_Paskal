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

        //задаем поле для цвета бонуса, который будет меняться
        protected Color _color;

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

       

        //включаем рендер и коллаидр бонуса
        public void Start()
        {
            _color = Random.ColorHSV();
            if (TryGetComponent(out Renderer rer))
                rer.sharedMaterial.color = _color;
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
