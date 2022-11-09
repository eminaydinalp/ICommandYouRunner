using System;
using _Game.Scripts.Abstracts.Affect;
using _Game.Scripts.Abstracts.Movement;
using _Game.Scripts.Concretes.Movement;
using _Game.Scripts.Concretes.Spawner;
using Lean.Touch;
using UnityEngine;

namespace _Game.Scripts.Concretes.Controllers
{
    public class PlayerController : VerticalMovementBase
    {
        private HorizontalMovement _horizontalMovement;
        
        [Header("Horizontal Movement Information \n")] 
        [SerializeField] private Transform localMoverTarget;
        [SerializeField] private Transform localMover;

        [SerializeField] private float xPositionClamp;
        [SerializeField] private float horizontalMoveSpeed;

        private BoxCollider _collider;

        protected override void Awake()
        {
            base.Awake();
            _horizontalMovement =
                new HorizontalMovement(localMover, localMoverTarget, xPositionClamp, horizontalMoveSpeed);
        }
        
        private void Start()
        {
            LeanTouch.OnFingerUpdate +=_horizontalMovement.SwerveLean;
        }

        private void Update()
        {
            _horizontalMovement.FollowLocalMoverTarget();
        }

        private void OnTriggerEnter(Collider other)
        {
            var affectable = other.GetComponent<IAffectable>();

            affectable?.DoProcess();
        }
    }
}
