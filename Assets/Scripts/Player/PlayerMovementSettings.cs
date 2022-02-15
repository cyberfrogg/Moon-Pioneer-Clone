using System;
using UnityEngine;

namespace Player
{
    [Serializable]
    public class PlayerMovementSettings
    {
        public float Speed { get => _speed; }
        public AnimationCurve SpeedSensitivityCurve { get => _speedSensitivityCurve; }

        [SerializeField] private float _speed;
        [SerializeField] private AnimationCurve _speedSensitivityCurve;
    }
}
