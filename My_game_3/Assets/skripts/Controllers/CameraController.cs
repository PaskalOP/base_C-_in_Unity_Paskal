using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class CameraController : IExecute
    {
        private Transform _player;
        private Transform _camera;
        private Vector3 _offSet;

        public CameraController(Transform player, Transform mainCamera)
        {
            _player = player;
            _camera = mainCamera;
            _camera.LookAt(_player); 
            _offSet = _camera.position - _player.position;
        }

        public void Update()
        {
            _camera.position = _player.position + _offSet;
        }
    }
}

