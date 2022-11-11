using System;
using _Game.Scripts.Abstracts.Spawner;
using UnityEngine;


namespace _Game.Scripts.Concretes.Spawner
{
    public class FriendBallSpawner : BallSpawner
    {
        public static FriendBallSpawner Instance;

        [SerializeField] private GameObject firstFrienfBall;
        private void Awake()
        {
            Instance = this;
        }

        protected override void Start()
        {
            base.Start();
            activeBalls.Add(firstFrienfBall);
        }
        
    }
}
