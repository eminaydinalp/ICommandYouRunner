using System;
using System.Collections;
using _Game.Scripts.Abstracts.Spawner;
using UnityEngine;

namespace _Game.Scripts.Abstracts.Attack
{
    public abstract class BallAttack : MonoBehaviour
    {
        public bool isAttack;
        public BallSpawner enemyBallSpawner;
        public BallSpawner selfBallSpawner;


        protected virtual void Update()
        {
            Attack();
            //Attack2();
        }

        private void Attack2()
        {
            if (isAttack && enemyBallSpawner.activeBalls.Count <= 0)
            {
                selfBallSpawner.FormatBallGroup();
                isAttack = false;
                enemyBallSpawner.gameObject.SetActive(false);
            }
        }

        private void Attack()
        {
            if (isAttack && selfBallSpawner.activeBalls.Count > 0)
            {
                var enemyDirection = enemyBallSpawner.transform.position - transform.position;

                for (int i = 0; i < selfBallSpawner.activeBalls.Count; i++)
                {
                    selfBallSpawner.activeBalls[i].transform.rotation =
                        Quaternion.Slerp(selfBallSpawner.activeBalls[i].transform.rotation,
                            Quaternion.LookRotation(enemyDirection, Vector3.up), Time.deltaTime * 3f);


                    if (enemyBallSpawner.activeBalls.Count > 0)
                    {
                        var distance = enemyBallSpawner.activeBalls[0].transform.position -
                                       selfBallSpawner.activeBalls[i].transform.position;

                        selfBallSpawner.activeBalls[i].transform.position = Vector3.Lerp(
                            selfBallSpawner.activeBalls[i].transform.position,
                            enemyBallSpawner.activeBalls[0].transform.position, Time.deltaTime * 1f);
                    }
                    else
                    {
                        selfBallSpawner.FormatBallGroup();
                        isAttack = false;
                        enemyBallSpawner.gameObject.SetActive(false);
                    }
                }
            }
        }
        
    }
}