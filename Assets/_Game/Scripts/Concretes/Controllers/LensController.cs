using System;
using _Game.Scripts.Abstracts.Affect;
using _Game.Scripts.Concretes.Spawner;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Game.Scripts.Concretes.Controllers
{
    public class LensController : MonoBehaviour, IAffectable
    {
        [SerializeField] private TextMeshPro gateNo;
        [SerializeField] private int minCount;
        [SerializeField] private int maxCount;
        public int randomNumber;

        private void Start()
        {
           InitialLens();
        }

        private void InitialLens()
        {
            randomNumber = Random.Range(minCount, maxCount);

            if (randomNumber % 2 != 0)
                randomNumber += 1;

            gateNo.text = "+" + randomNumber.ToString();
        }
        

        public void DoProcess()
        {
            BallSpawner.Instance.MakeStickMan(BallSpawner.Instance.numberOfBalls + randomNumber);
        }
    }
}