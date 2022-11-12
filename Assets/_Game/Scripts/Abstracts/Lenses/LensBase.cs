using TMPro;
using UnityEngine;

namespace _Game.Scripts.Abstracts.Lenses
{
    public abstract class LensBase : MonoBehaviour
    {
        [SerializeField] protected TextMeshPro gateNo;
        [SerializeField] private int minCount;
        [SerializeField] private int maxCount;
        public int randomNumber;

        protected virtual void Start()
        {
            InitialLens();
        }

        private void InitialLens()
        {
            randomNumber = Random.Range(minCount, maxCount);

            if (randomNumber % 2 != 0)
                randomNumber += 1;

        }


        public abstract void DoProcess();
    }
}