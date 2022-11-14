using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Game.Scripts.Concretes.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public GameObject confetti;
        
        public bool isFinish;
        public bool isFinishAttackArea;

        private void OnEnable()
        {
            EventManager.OnFail += () => isFinish = true;
            EventManager.OnWin += () => isFinish = true;
            EventManager.OnWin += PlayConfetti;
            EventManager.OnTriggerFinishArea += () => isFinishAttackArea = true;
        }

        private void OnDisable()
        {
            EventManager.OnFail -= () => isFinish = true;
            EventManager.OnWin -= () => isFinish = true;
            EventManager.OnWin -= PlayConfetti;
            EventManager.OnTriggerFinishArea -= () => isFinishAttackArea = true;
        }

        private void Awake()
        {
            Instance = this;
        }

        public void LoadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void PlayConfetti()
        {
            confetti.SetActive(true);
        }
    }
}