using Assets.Scripts.Arch.Facades;
using UnityEngine;

namespace Assets.Scripts.UI
{
    class MainMenuState : MonoBehaviour
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
            AllBtnsToDefault();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (settingIsOpen && !menuIsOpen)
                {
                    CloseSettings();
                    AllBtnsToDefault();
                }
            }
            if(Input.GetKeyDown(KeyCode.Numlock))
            {
                LevelsFacade.SetLevelsByDefault();
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
        public void OpenLevelList()
        {
            menuIsOpen = false;
            menu.SetActive(menuIsOpen);
            levelList.SetActive(true);
            AllBtnsToDefault();
        }
        public void CloseLevelList()
        {
            menuIsOpen = true;
            menu.SetActive(menuIsOpen);
            levelList.SetActive(false);
            AllBtnsToDefault();
        }
        public void Exit()
        {
            Application.Quit();
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
