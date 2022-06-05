using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;


namespace Maze
{
    public class BadBonus : Bonus, IFly, IRotate
    {
        //поля высоты полета  и скорости вращения
        private float hightFly;
        private float speedRotation;

        // создаем событие на которое будет реагировать игрок 
        public event Action<string, Color> OnCoughtPl = delegate (string str, Color color) { };

        private void Awake()
        {
            speedRotation = Random.Range(3f, 8f);
            hightFly = Random.Range(2f, 6f);
            _transform = GetComponent<Transform>();
        }
        public override void Interaction()
        {
            OnCoughtPl.Invoke(gameObject.name, _color);
        }

       

        public override void Update()
        {
            Fly();
            Rotate();
           // Debug.Log("Апдейт бед бонуса");
        }
        public void Fly()
        {
            _transform.position = new Vector3(_transform.position.x, Mathf.PingPong(Time.time, hightFly), _transform.position.z);
           // Debug.Log("Сработал флай бед бонуса");
        }
        public void Rotate()
        {
            _transform.Rotate(Vector3.up * (Time.deltaTime * speedRotation), Space.World);
           // Debug.Log("Сработал ротейт  бед бонуса");
        }
    }
    
}

