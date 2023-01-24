using System;
using UnityEngine;

namespace SwampAttack.Runtime.Model.Input
{
    public class ShootDirectionCalculator : IShootDirectionCalculator
    {
        private readonly Camera _camera;
        private readonly Transform _gunEndPosition;

        public ShootDirectionCalculator(Camera camera, Transform gunEndPosition)
        {
            _camera = camera ?? throw new ArgumentNullException(nameof(camera));
            _gunEndPosition = gunEndPosition ?? throw new ArgumentNullException(nameof(gunEndPosition));
        }

        public Vector2 CalculateDirection(Vector2 touchPosition)
            => (touchPosition - (Vector2)_camera.WorldToScreenPoint(_gunEndPosition.position)).normalized;
    }
}