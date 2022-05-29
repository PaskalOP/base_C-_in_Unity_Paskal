using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField] public Rigidbody _rb;
        public Transform _transform;
        public static float Speed =5 ;
        public static float Health = 100;
        public bool isDead;
       

        public abstract void Move(float x, float y, float z);
       
    }

}
