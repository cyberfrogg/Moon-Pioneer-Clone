using System;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public bool IsMoving
        {
            get
            {
                return _inputMove.magnitude > 0.05f;
            }
        }

        [SerializeField] private PlayerMovementSettings _settings;
        [SerializeField] private Transform _modelContainer;

        [Inject] private PlayerControls _controls;
        private Vector3 _inputMove;
        private Vector3 _move;

        private void Update()
        {
            move();
            rotateModel();
        }
        private void move()
        {
            _inputMove = new Vector3(
                applySensitivity(_controls.Horizontal),
                0,
                applySensitivity(_controls.Vertical)
            );
            _move = _inputMove * Time.deltaTime * _settings.Speed;

            transform.Translate(_move);
        }
        private void rotateModel()
        {
            Vector3 rotationLookAtVector = Quaternion.AngleAxis(-135, Vector3.up) * new Vector3(_controls.Horizontal, 0, _controls.Vertical);

            if (rotationLookAtVector == Vector3.zero)
                return;

            _modelContainer.rotation = Quaternion.LookRotation(rotationLookAtVector);
        }
        private float applySensitivity(float value)
        {
            return _settings.SpeedSensitivityCurve.Evaluate(value);
        }
    }
}
