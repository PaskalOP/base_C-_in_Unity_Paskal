using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
     public class GoodBonus : Bonus, IFly, IFlick
    {
        //поля высоты полета  и скорости вращения
        private float hightFly;
        private float speedRotation;


        private void Awake()
        {
            speedRotation = Random.Range(1f, 5f);
            hightFly = Random.Range(13f, 40f);
        }
        public override void Interaction()
        {

        }

        private void OnTriggerEnter(Collider other)
        {

        }
        public void Start()
        {
            
        }


        public override void Update()
        {
            Fly();
            Flick();
        }

        //меняем позицию обьекта через метод Пинг понг. Тоесть туда и обратно.
        public void Fly()
        {
            _transform.position = new Vector3(_transform.position.x, Mathf.PingPong(Time.time, hightFly), _transform.position.z);
        }
        public void Flick()
        {
            
        }
    }

}

