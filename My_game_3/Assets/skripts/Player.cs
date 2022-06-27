using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Maze
{
    public sealed class Player : Unit
    {
        
        [SerializeField] private BadBonus badBonus;
        private Material _material;
        [SerializeField] private GoodBonus goodBonus;

        PlayerData SinglePlayerData = new PlayerData();

        private ISaveData _data;
        [SerializeField] private Transform _playerDot;

        private void Awake()
        {
            
            _transform = transform;
            _rb = GetComponent<Rigidbody>();
            isDead = false;
            Health = 100;
           
            goodBonus.TakeGoodBonus += NormalScale;
            badBonus.OnCoughtPl += ChangeColor;

            SinglePlayerData.PlayerDead = isDead;
            SinglePlayerData.PlayerHealth = Health;
            SinglePlayerData.PlayerName = gameObject.name;
            

            _data = new JSONData();
            _data.SaveData(SinglePlayerData);

        }

        public override void Move(float x, float y, float z)
        {
            if (_rb)
            {
                _rb.AddForce(new Vector3(x, y, z) * Speed);
            }
            else
                Debug.Log("No RigidBody");
            SinglePlayerData.PlayerPosition = _transform.position;
            _playerDot.position = new Vector3(_transform.position.x, _playerDot.position.y, _transform.position.z);  


        }

       public void ChangeColor (string name, Color color)
        {
            _material = GetComponent<Renderer>().material;
            _material.color = Color.blue;
            _transform.localScale = new Vector3(2, 2, 2);
            SinglePlayerData.PlayerColor = _material.color;
            SinglePlayerData.PlayerScale = _transform.localScale;

            Debug.Log("Цвет  и размер сменился");
            
        }
        private void NormalScale (int i)
        {
            _transform.localScale = new Vector3(1, 1, 1);
            SinglePlayerData.PlayerScale = _transform.localScale;
        }

        public override  void SavePlayer()
        {
            _data.SaveData(SinglePlayerData);
            PlayerData NewPlayer = _data.Load();
            Debug.Log(NewPlayer.PlayerName);
            Debug.Log(NewPlayer.PlayerPosition);
            Debug.Log(NewPlayer.PlayerColor );
            Debug.Log(NewPlayer.PlayerScale );
            badBonus.SaveBadBonus();
        }
    }

}