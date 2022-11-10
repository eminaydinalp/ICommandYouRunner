using System;
using UnityEngine;

namespace _Game.Scripts.Concretes.Managers
{
    public class EventManager : MonoBehaviour
    {
        public static Action<int> OnTriggerLens;
    }
}