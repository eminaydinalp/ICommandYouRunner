using _Game.Scripts.Abstracts.Affect;
using _Game.Scripts.Concretes.Managers;
using UnityEngine;

namespace _Game.Scripts.Concretes.Finish
{
    public class FinishArea : MonoBehaviour, IAffectable
    {
        public void DoProcess()
        {
            EventManager.OnTriggerFinishArea?.Invoke();
        }
    }
}
