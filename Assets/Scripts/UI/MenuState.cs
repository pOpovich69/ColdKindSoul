using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI
{
    class MenuState : MonoBehaviour
    {
        [SerializeField] private GameObject menu;
        [SerializeField] private GameObject settingWindow;
        [SerializeField] private GameObject loseWindow;
        [SerializeField] private GameObject winWindow;

        private bool menuIsOpen;
        private bool settingIsOpen;

        private void Start()
        {
            menuIsOpen = false;
            settingIsOpen = false;
            menu.SetActive(menuIsOpen);
            settingWindow.SetActive(settingIsOpen);
            AllBtnsToDefault();
        }
        private void Update()
        {
            if (!loseWindow.activeSelf && !winWindow.activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    if (menuIsOpen && !settingIsOpen)
                    {
                        menuIsOpen = !menuIsOpen;
                        menu.SetActive(menuIsOpen);
                        Time.timeScale = Convert.ToSingle(!menuIsOpen);
                        AllBtnsToDefault();
                    }
                    else if (!menuIsOpen && !settingIsOpen)
                    {
                        menuIsOpen = !menuIsOpen;
                        menu.SetActive(menuIsOpen);
                        Time.timeScale = Convert.ToSingle(!menuIsOpen);
                        AllBtnsToDefault();
                    }
                    else if (settingIsOpen && !menuIsOpen)
                    {
                        CloseSettings();
                        AllBtnsToDefault();
                    }
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
                AllBtnsToDefault();
            }
        }
        public void OpenSettings()
        {
            menuIsOpen = false;
            settingIsOpen = true;
            menu.SetActive(menuIsOpen);
            settingWindow.SetActive(settingIsOpen);
            AllBtnsToDefault();
        }
        public void CloseSettings()
        {
            menuIsOpen = true;
            settingIsOpen = false;
            menu.SetActive(menuIsOpen);
            settingWindow.SetActive(settingIsOpen);
            AllBtnsToDefault();
        }
        public void RestartGame()
        {
            SceneManager.LoadScene("Game");
            AllBtnsToDefault();
        }
        public void GoToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
            AllBtnsToDefault();
        }
        private void AllBtnsToDefault()
        {
            Transform[] comps = GetComponentsInChildren<Transform>();
            foreach (var item in comps)
            {
                item.localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }
}
