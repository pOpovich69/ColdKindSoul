using Assets.Scripts.Arch.Facades;
using Assets.Scripts.Gameplay.LevelScripts.LevelLogic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MonoLevel : MonoBehaviour
{
    public Level Level { get; set; }

    [SerializeField] private Image info;
    [SerializeField] private Image isLock;

    [SerializeField] private Text timeText;
    [SerializeField] private Text starsText;

    private Text levelIdText;

    private void Start()
    {
        levelIdText = GetComponentInChildren<Text>();
        levelIdText.text = Level.LevelId.ToString();
        info.gameObject.SetActive(false);
        
        timeText.text = $"Time: {Level.Time}";
        if(Level.Time == null)
            timeText.text = $"Time: 00:00";
        starsText.text = $"Stars: {Level.Stars}";

        if (Level.LevelId > 1)
        {
            Level prevLevel = LevelsFacade.GetLevelWithId(Level.LevelId - 1);
            isLock.gameObject.SetActive(!prevLevel.IsDone);
            return;
        }
        isLock.gameObject.SetActive(false);
    }

    public void StartLevel()
    {
        if (Level != null && !isLock.gameObject.activeSelf)
        {
            LevelStatic.SelectedLevelId = Level.LevelId;
            SceneManager.LoadScene("Game");
        }
    }

    public void ShowInfo()
    {
        info.gameObject.SetActive(true);
    }

    public void CloseInfo()
    {
        info.gameObject.SetActive(false);
    }

}
