using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

namespace Maze
{
     public class GoodBonus : Bonus, IFly, IFlick
    {
        //поля высоты полета  и скорости вращения
        private float hightFly=3f;
       
        private Material _material;
        [SerializeField]public int poin = 1;

        //обявляем событие
        public event Action<int> TakeGoodBonus = delegate (int _point) { };


        private void Awake()
        {
            
            hightFly = Random.Range(4f, 10f);
            _material = GetComponent<Renderer>().material;
            _transform = GetComponent<Transform>();
        }
        public override void Interaction()
        {
            TakeGoodBonus.Invoke(poin);
            poin++;
        }

       

        public override void Update()
        {
            Fly();
            Flick();
           // Debug.Log("Апдейт гуд бонуса");
        }

        //меняем позицию обьекта через метод Пинг понг. Тоесть туда и обратно.
        public void Fly()
        {
            _transform.position = new Vector3(_transform.position.x, Mathf.PingPong(Time.time, hightFly), _transform.position.z);
        }
        //метод мерцания цвета (материал должен быть или transparent или fade)
        public void Flick()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, Mathf.PingPong(Time.time, 1.0f));
        }
    }

}

