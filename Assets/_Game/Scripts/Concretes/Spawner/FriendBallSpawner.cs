using _Game.Scripts.Abstracts.Spawner;
using _Game.Scripts.Concretes.Controllers;
using _Game.Scripts.Concretes.Managers;
using UnityEngine;


namespace _Game.Scripts.Concretes.Spawner
{
    public class FriendBallSpawner : BallSpawner
    {
        [SerializeField] private GameObject firstFriendBall;

        private BallController _ballController;
   
        protected override void Start()
        {
            base.Start();
            activeBalls.Add(firstFriendBall);
        }

        public void DecreaseBall(int number)
        {
            var activeBallCount = activeBalls.Count;
            
            if (activeBallCount <= number)
            {
                for (int i = 0; i < activeBallCount; i++)
                {
                    activeBalls[i].gameObject.SetActive(false);
                    EventManager.OnFail?.Invoke();
                }
            }
            else
            {
                for (int i = activeBallCount- number; i < activeBallCount; i++)
                {
                    activeBalls[^1].gameObject.SetActive(false);
                    activeBalls.RemoveAt(activeBalls.Count -1);
                }


                SetNumberOfBalls();
                FormatBallGroup();
            }
            
        }

        public void FindSmallestBallScale()
        {
            _ballController = activeBalls[0].GetComponent<BallController>();
            
            for (int i = 0; i < activeBalls.Count; i++)
            {
                if (activeBalls[i].GetComponent<BallController>().scale < _ballController.scale)
                {
                    _ballController = activeBalls[i].GetComponent<BallController>();
                }
            }
            
            _ballController.IncreaseScale();
        }
    }
}
