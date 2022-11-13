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
                        selfBallSpawner.activeBalls[i].transform.position = Vector3.Lerp(
                            selfBallSpawner.activeBalls[i].transform.position,
                            enemyBallSpawner.activeBalls[0].transform.position, Time.deltaTime * 1f);
                    }
                    else
                    {
                        selfBallSpawner.FormatBallGroup();
                        StartCoroutine(StopAttack());
                    }
                }
            }
        }

        private IEnumerator StopAttack()
        {
            yield return new WaitForSeconds(0.1f);
            isAttack = false;
            //enemyBallSpawner.gameObject.SetActive(false);
        }
        
    }
}