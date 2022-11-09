using _Game.Scripts.Abstracts.Controller;
using _Game.Scripts.Abstracts.Movement;
using _Game.Scripts.Concretes.Movement;
using UnityEngine;

namespace _Game.Scripts.Concretes.Controllers
{
    public class BallController : MonoBehaviour,IEntityController
    {
        private IMover _verticalMover;
        
        [Header("Vertical Movement Information \n")] 
        [SerializeField] private float moveDirection;
        [SerializeField] private float verticalMoveSpeed;
        private void Awake()
        {
            _verticalMover = new VerticalMovement(this);
        }

        private void FixedUpdate()
        {
            _verticalMover.Move(moveDirection, verticalMoveSpeed);
        }
    }
}
