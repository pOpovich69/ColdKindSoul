using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI
{
    class MenuState: MonoBehaviour
    {
        [SerializeField] private GameObject menu;
        [SerializeField] private GameObject settingWindow;

        private bool menuIsOpen;
        private bool settingIsOpen;

        private void Start()
        {
            menuIsOpen = false;
            settingIsOpen = false;
            menu.SetActive(menuIsOpen);
            settingWindow.SetActive(settingIsOpen);
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (menuIsOpen && !settingIsOpen)
                {
                    menuIsOpen = !menuIsOpen;
                    menu.SetActive(menuIsOpen);
                    Time.timeScale = Convert.ToSingle(!menuIsOpen);
                }
                else if (!menuIsOpen && !settingIsOpen)
                {
                    menuIsOpen = !menuIsOpen;
                    menu.SetActive(menuIsOpen);
                    Time.timeScale = Convert.ToSingle(!menuIsOpen);
                }
                else if (settingIsOpen && !menuIsOpen)
                {
                    CloseSettings();
                }
            }
        }
        public void ContinueGame()
        {
            if (menuIsOpen)
            {
                menuIsOpen = false;
                menu.SetActive(menuIsOpen);
                Time.timeScale = Convert.ToSingle(!menuIsOpen);
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
        public void GoToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
