using _Game.Scripts.Abstracts.Attack;
using _Game.Scripts.Concretes.Managers;
using UnityEngine;

namespace _Game.Scripts.Concretes.Attack
{
    public class FriendBallAttack : BallAttack
    {

        protected override void Update()
        {
            base.Update();
            
            if(selfBallSpawner == null || enemyBallSpawner == null || !isAttack) return;

            if (selfBallSpawner.activeBalls.Count <= 0)
            {
                EventManager.OnFail?.Invoke();
            }

            if (enemyBallSpawner.activeBalls.Count <= 0)
            {

                if (GameManager.Instance.isFinishAttackArea)
                {
                    EventManager.OnWin?.Invoke();
                }
                
                EventManager.OnFinishMelt?.Invoke();
            }
        }
    }
}