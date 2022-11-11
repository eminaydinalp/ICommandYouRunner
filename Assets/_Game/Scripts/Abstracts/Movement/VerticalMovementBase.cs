using _Game.Scripts.Abstracts.Controller;
using _Game.Scripts.Concretes.Movement;
using UnityEngine;

namespace _Game.Scripts.Abstracts.Movement
{
    public abstract class VerticalMovementBase : MonoBehaviour, IEntityController
    {
        private IMover _verticalMover;
        
        [Header("Vertical Movement Information \n")] 
        [SerializeField] private float moveDirection;
        public float verticalMoveSpeed;
        public float defaultVerticalMoveSpeed;
        public float minVerticalMoveSpeed;
        protected virtual void Awake()
        {
            _verticalMover = new VerticalMovement(this);
        }

        protected virtual void FixedUpdate()
        {
            _verticalMover.Move(moveDirection, verticalMoveSpeed);
        }
    }
}