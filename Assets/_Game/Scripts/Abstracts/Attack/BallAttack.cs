using System;
using _Game.Scripts.Abstracts.Spawner;
using UnityEngine;

namespace _Game.Scripts.Abstracts.Attack
{
    public class BallAttack : MonoBehaviour
    {
        public bool isAttack;
        public BallSpawner enemyBallSpawner;
        public BallSpawner selfBallSpawner;


        private void Update()
        {
            Attack();
        }

        private void Attack()
        {
            if (isAttack && selfBallSpawner.activeBalls.Count > 0)
            {
                var enemyDirection = enemyBallSpawner.transform.position - transform.position;

                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).rotation = 
                        Quaternion.Slerp(transform.GetChild(i).rotation,Quaternion.LookRotation(enemyDirection,Vector3.up), Time.deltaTime * 3f);
                

                    if (enemyBallSpawner.activeBalls.Count > 0)
                    {
                        var distance = enemyBallSpawner.activeBalls[0].transform.position - transform.GetChild(i).position;

                        if (distance.magnitude < 1.5f)
                        {
                            transform.GetChild(i).position = Vector3.Lerp(transform.GetChild(i).position,
                                enemyBallSpawner.activeBalls[0].transform.position,Time.deltaTime * 2f);
                        } 
                    }
              
                }
            }
        }
    }
}