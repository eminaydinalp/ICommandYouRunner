using _Game.Scripts.Abstracts.Movement;
using Lean.Touch;
using UnityEngine;

namespace _Game.Scripts.Concretes.Movement
{
    public class HorizontalMovement : IMover
    {
        private Transform _localMover;
        private Transform _localMoverTarget;

        private readonly float _clamXPosition;
        private readonly float _speed;

        public HorizontalMovement(Transform localMover, Transform localMoverTarget, float clamXPosition, float speed)
        {
            _localMover = localMover;
            _localMoverTarget = localMoverTarget;
            _clamXPosition = clamXPosition;
            _speed = speed;
        }
        
        public void SwerveLean(LeanFinger finger)
        {
            Vector2 direction = finger.ScaledDelta;

            if (Input.GetMouseButton(0))
            {
                Move(direction.x, _speed);
                
            }
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase is TouchPhase.Moved or TouchPhase.Stationary)
                {
                    Move(direction.x / 2f, _speed);
                }
            }
        }

        public void Move(float direction, float speed)
        {
            _localMoverTarget.localPosition += Vector3.right * (direction * speed * Time.deltaTime);
            
            XPositionClamp();
        }

        private void XPositionClamp()
        {
            var pos = _localMoverTarget.localPosition;

            pos.x = Mathf.Clamp(pos.x, -_clamXPosition, _clamXPosition);

            _localMoverTarget.localPosition = pos;
        }
        
        public void FollowLocalMoverTarget()
        {
            Vector3 nextPos = new Vector3(_localMoverTarget.localPosition.x, _localMover.localPosition.y, _localMover.localPosition.z); ;
            _localMover.localPosition = Vector3.Lerp(_localMover.localPosition, nextPos, _speed * Time.deltaTime);
        }
    }
}
