using System;
using _Game.Scripts.Abstracts.Movement;
using _Game.Scripts.Abstracts.Spawner;
using _Game.Scripts.Concretes.Managers;
using _Game.Scripts.Concretes.Spawner;
using UnityEngine;

namespace _Game.Scripts.Concretes.Controllers
{
    public class FriendBallGroupController : VerticalMovementBase
    {
        [SerializeField] private BallSpawner _friendBallSpawner;
        
        private void OnValidate()
        {
            if (_friendBallSpawner == null)
            {
                _friendBallSpawner = GetComponent<BallSpawner>();
            }
        }

        private void OnEnable()
        {
            EventManager.OnTriggerLens += _friendBallSpawner.MakeStickMan;
        }

        private void OnDisable()
        {
            EventManager.OnTriggerLens -= _friendBallSpawner.MakeStickMan;
        }
    }
}
