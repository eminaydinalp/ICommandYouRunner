using System;
using _Game.Scripts.Abstracts.Affect;
using _Game.Scripts.Abstracts.Lenses;
using _Game.Scripts.Concretes.Managers;
using _Game.Scripts.Concretes.Spawner;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Game.Scripts.Concretes.Lenses
{
    public class LensIncrease : LensBase, IAffectable
    {
        protected override void Start()
        {
            base.Start();
            
            SetGateText();
        }

        public override void DoProcess()
        {
            EventManager.OnTriggerLensIncrease?.Invoke(randomNumber);
        }

        private void SetGateText()
        {
            gateNo.text = "+" + randomNumber.ToString();
        }
    }
}