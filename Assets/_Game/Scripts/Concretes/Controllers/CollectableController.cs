using _Game.Scripts.Abstracts.Affect;
using _Game.Scripts.Concretes.Managers;
using UnityEngine;

namespace _Game.Scripts.Concretes.Controllers
{
    public class CollectableController : MonoBehaviour, IAffectable
    {
        public void DoProcess()
        {
            EventManager.OnTriggerCollectable?.Invoke();
            gameObject.SetActive(false);
        }
    }
}