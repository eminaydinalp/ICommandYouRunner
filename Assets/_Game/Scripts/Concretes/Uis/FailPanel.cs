using _Game.Scripts.Concretes.Managers;
using UnityEngine;

namespace _Game.Scripts.Concretes.Uis
{
    public class FailPanel : MonoBehaviour
    {
        public void TryAgainButton()
        {
            GameManager.Instance.LoadScene();
        }
    }
}