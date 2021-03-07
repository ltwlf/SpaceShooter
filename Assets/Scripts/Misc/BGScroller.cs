using System;
using UnityEngine;

namespace Misc
{
    public class BGScroller : MonoBehaviour
    {
        [SerializeField] private float _scrollSpeed = 5;

        [SerializeField] private float _tileSizeZ = 30;
        
        private Vector3 _startPosition;


        private void Start()
        {
            _startPosition = transform.position;
        }

        private void Update()
        {
            float newPosition = Mathf.Repeat(Time.time * _scrollSpeed, _tileSizeZ);
            transform.position = _startPosition + Vector3.forward * newPosition;
        }
    }
}