using _Game.Scripts.Abstracts.Affect;
using _Game.Scripts.Concrates.Utilities;
using _Game.Scripts.Concretes.Managers;
using UnityEngine;

namespace _Game.Scripts.Concretes.Controllers
{
    public class CollectableController : MonoBehaviour, IAffectable
    {
        public void DoProcess()
        {
            EventManager.OnTriggerCollectable?.Invoke();
            SoundManager.Instance.PlaySound(Consts.TriggerCollectableSoundIndex);
            gameObject.SetActive(false);
        }
    }
}