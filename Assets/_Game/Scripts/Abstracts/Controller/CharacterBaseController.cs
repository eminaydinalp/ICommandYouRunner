using _Game.Scripts.Abstracts.Movement;
using _Game.Scripts.Concretes.Managers;
using _Game.Scripts.Concretes.Movement;
using UnityEngine;

namespace _Game.Scripts.Abstracts.Controller
{
    public abstract class CharacterBaseController : MonoBehaviour, IEntityController
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
            if (GameManager.Instance.isFinish) return;
            
            _verticalMover.Move(moveDirection, verticalMoveSpeed);
        }
    }
}