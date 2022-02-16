using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerMovement))]
    public class Player : MonoBehaviour
    {
        public PlayerMovement Movement { get => _movement; }

        [SerializeField] private Vector3 _spawnPoint;
        [SerializeField] private float _dieHeight = -20;
        private PlayerMovement _movement;

        private void Awake()
        {
            _movement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            validateDeathHeight();
        }
        private void validateDeathHeight()
        {
            if (transform.position.y < _dieHeight)
            {
                transform.position = _spawnPoint;
                Debug.Log("Nope");
            }
        }
    }
}