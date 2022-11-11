using _Game.Scripts.Abstracts.Attack;
using _Game.Scripts.Concretes.Controllers;
using _Game.Scripts.Concretes.Managers;
using UnityEngine;

namespace _Game.Scripts.Concretes.Attack
{
    public class FriendBallAttack : BallAttack
    {

        protected override void Update()
        {
            base.Update();

            if (selfBallSpawner.activeBalls.Count <= 0)
            {
                Debug.Log("Fail");
            }

            if (enemyBallSpawner.activeBalls.Count <= 0)
            {
                Debug.Log("Win");
                
                EventManager.OnFinishMelt?.Invoke();
            }
        }
    }
}