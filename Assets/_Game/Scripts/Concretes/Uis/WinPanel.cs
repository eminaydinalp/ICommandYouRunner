using _Game.Scripts.Concretes.Managers;
using UnityEngine;

namespace _Game.Scripts.Concretes.Uis
{
    public class WinPanel : MonoBehaviour
    {
        public void NextButton()
        {
            GameManager.Instance.LoadScene();
        }
    }
}