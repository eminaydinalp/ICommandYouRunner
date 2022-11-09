using System;
using _Game.Scripts.Abstracts.Controller;
using _Game.Scripts.Abstracts.Movement;
using _Game.Scripts.Concretes.Movement;
using Lean.Touch;
using UnityEngine;

namespace _Game.Scripts.Concretes.Controllers
{
    public class PlayerController : MonoBehaviour, IEntityController
    {
        private IMover _verticalMovement;
        private HorizontalMovement _horizontalMovement;

        [Header("Vertical Movement Information \n")] 
        [SerializeField] private float moveDirection;
        [SerializeField] private float verticalMoveSpeed;

        [Header("Horizontal Movement Information \n")] 
        [SerializeField] private Transform localMoverTarget;
        [SerializeField] private Transform localMover;

        [SerializeField] private float xPositionClamp;
        [SerializeField] private float horizontalMoveSpeed;

        private BoxCollider _collider;
        
        private void Awake()
        {
            _verticalMovement = new VerticalMovement(this);
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

        private void FixedUpdate()
        {
            _verticalMovement.Move(moveDirection, verticalMoveSpeed);
        }
    }
}
