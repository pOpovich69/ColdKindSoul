using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI
{
    class MainMenuState: MonoBehaviour
    {
        [SerializeField] private GameObject menu;
        [SerializeField] private GameObject settingWindow;

        private bool menuIsOpen;
        private bool settingIsOpen;

        private void Start()
        {
            menuIsOpen = true;
            settingIsOpen = false;
            menu.SetActive(menuIsOpen);
            settingWindow.SetActive(settingIsOpen);
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (settingIsOpen && !menuIsOpen)
                {
                    CloseSettings();
                }
            }
        }
        public void StartGame()
        {
            SceneManager.LoadScene("Game");
        }
        public void OpenSettings()
        {
            menuIsOpen = false;
            settingIsOpen = true;
            menu.SetActive(menuIsOpen);
            settingWindow.SetActive(settingIsOpen);
        }
        public void CloseSettings()
        {
            menuIsOpen = true;
            settingIsOpen = false;
            menu.SetActive(menuIsOpen);
            settingWindow.SetActive(settingIsOpen);
        }
        public void Exit()
        {
            Application.Quit();
        }
    }
}
