using System;
using _Game.Scripts.Abstracts.Controller;
using _Game.Scripts.Abstracts.Movement;
using _Game.Scripts.Concretes.Movement;
using UnityEngine;

namespace _Game.Scripts.Concretes.Controllers
{
    public class PlayerController : MonoBehaviour, IEntityController
    {
        private IMover _verticalMovement;

        [Header("Movement Information")] 
        [SerializeField] private float moveDirection;
        [SerializeField] private float moveSpeed;
        
        private void Awake()
        {
            _verticalMovement = new VerticalMovement(this);
        }

        private void FixedUpdate()
        {
            _verticalMovement.Move(moveDirection, moveSpeed);
        }
    }
}
