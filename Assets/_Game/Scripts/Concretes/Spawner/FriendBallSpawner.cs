using _Game.Scripts.Abstracts.Spawner;


namespace _Game.Scripts.Concretes.Spawner
{
    public class FriendBallSpawner : BallSpawner
    {
        public static FriendBallSpawner Instance;

        private void Awake()
        {
            Instance = this;
        }
        
    }
}
