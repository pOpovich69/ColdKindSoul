using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI
{
    class MainMenuState: MonoBehaviour
    {
        [SerializeField] private GameObject menu;
        [SerializeField] private GameObject settingWindow;
        [SerializeField] private GameObject levelList;

        private bool menuIsOpen;
        private bool settingIsOpen;

        private void Start()
        {
            menuIsOpen = true;
            settingIsOpen = false;
            levelList.SetActive(false);
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
        public void OpenLevelList()
        {
            menuIsOpen = false;
            menu.SetActive(menuIsOpen);
            levelList.SetActive(true);
        }
        public void CloseLevelList()
        {
            menuIsOpen = true;
            menu.SetActive(menuIsOpen);
            levelList.SetActive(false);
        }
        public void Exit()
        {
            Application.Quit();
        }
    }
}
