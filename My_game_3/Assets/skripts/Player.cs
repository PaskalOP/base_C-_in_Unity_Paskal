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


        private void Awake()
        {
            _transform = transform;
            _rb = GetComponent<Rigidbody>();
            isDead = false;
            Health = 100;
            _material = GetComponent<Renderer>().material;
            goodBonus.TakeGoodBonus += NormalScale;
            badBonus.OnCoughtPl += ChangeColor;
            Debug.Log("Awake player DONE");
        }

        public override void Move(float x, float y, float z)
        {
            if (_rb)
            {
                _rb.AddForce(new Vector3(x, y, z) * Speed);
            }
            else
                Debug.Log("No RigidBody");
        }

       public void ChangeColor (string name, Color color)
        {
            _material.color = Color.blue;
            _transform.localScale = new Vector3(5, 5, 5);

            Debug.Log("Цвет  и размер сменился");
            
        }
        private void NormalScale (int i)
        {
            _transform.localScale = new Vector3(2, 2, 2);
        }
    }

}