using System;
using UnityEngine;

namespace _Game.Scripts.Concretes.Managers
{
    public class EventManager : MonoBehaviour
    {
        public static Action<int> OnTriggerLensIncrease;
        public static Action<int> OnTriggerLensDecrease;
        public static Action OnStartMelt;
        public static Action OnFinishMelt;
        public static Action OnTriggerCollectable;
        public static Action OnFail;
        public static Action OnWin;
        public static Action OnTriggerFinishArea;
        public static Action OnFinishAttackAnimation;
    }
}