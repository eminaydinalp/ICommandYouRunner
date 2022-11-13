using System;
using _Game.Scripts.Concretes.Managers;
using UnityEngine;

namespace _Game.Scripts.Concretes.Uis
{
    public class GameCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject winPanel;
        [SerializeField] private GameObject failPanel;


        private void OnEnable()
        {
            EventManager.OnWin += OpenWinPanel;
            EventManager.OnFail += OpenFailPanel;
        }

        private void OnDisable()
        {
            EventManager.OnWin -= OpenWinPanel;
            EventManager.OnFail -= OpenFailPanel;
        }

        private void OpenWinPanel()
        {
            winPanel.SetActive(true);
        }
        
        private void OpenFailPanel()
        {
            failPanel.SetActive(true);
        }
    }
}
