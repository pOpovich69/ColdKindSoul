using Assets.Scripts.Gameplay.LevelScripts.LevelLogic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MonoLevel : MonoBehaviour
{
    public Level Level { get; set; }

    private Text levelIdText;

    private void Start()
    {
        levelIdText = GetComponentInChildren<Text>();
        levelIdText.text = Level.LevelId.ToString();
    }

    public void StartLevel()
    {
        if (Level != null)
        {
            LevelStatic.SelectedLevelId = Level.LevelId;
            SceneManager.LoadScene("Game");
        }

    }

}
