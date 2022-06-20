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

        private JSONBonus _dataBonus;
        private SObject SavedObject = new SObject();
        // создаем событие на которое будет реагировать игрок 
        public event Action<string, Color> OnCoughtPl = delegate (string str, Color color) { };

        private void Awake()
        {
            speedRotation = Random.Range(3f, 8f);
            hightFly = Random.Range(2f, 6f);
            _transform = GetComponent<Transform>();

            _dataBonus = new JSONBonus();
            SavedObject.HightOfFly = hightFly;
            SavedObject.SpeedOfRotation = speedRotation;
            SavedObject.Name = gameObject.name;
            SavedObject.Position = _transform.position;
            SavedObject.Rotation = _transform.rotation;
            SavedObject.BonusColor = _color;

            _dataBonus.SaveDataB(SavedObject);
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
        public void SaveBadBonus()
        {
            _dataBonus.SaveDataB(SavedObject);
            SObject NewPlayer = _dataBonus.LoadB();
            Debug.Log(NewPlayer.Name);
            Debug.Log(NewPlayer.Position);
            Debug.Log(NewPlayer.SpeedOfRotation);
            Debug.Log(NewPlayer.HightOfFly);
        }
    }
    
}

