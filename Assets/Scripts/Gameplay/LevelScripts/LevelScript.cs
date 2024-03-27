using Assets.Scripts.Arch.Facades;
using Assets.Scripts.Gameplay.LevelScripts.LevelLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour
{
    [Header("Level objects")]
    [SerializeField] private GameObject Enemy;
    [SerializeField] private Transform[] RandomPoints;
    [SerializeField] private GameObject FinishPortal;
    [SerializeField] private GameObject player;

    [Header("UI Things")]
    [SerializeField] private Text levelTimeText;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject winPopup;

    private Animation anim;
    private Player playerScript;
    private Level currentLevel;

    //private int maxCountEnemysOnLevel;
    //private int maxWaves;
    //private int currentWave;
    private int levelTimeSec;
    private int levelTimeMin;

    void Start()
    {
        currentLevel = LevelsFacade.GetLevelWithId(LevelStatic.SelectedLevelId);
        currentLevel.CurrentWave = 1;
        Debug.Log(LevelStatic.SelectedLevelId);

        playerScript = player.GetComponent<Player>();

        anim = GetComponent<Animation>();

        Time.timeScale = 1.0f;

        StartCoroutine(SpawnEnemiesAfterSomeTimeRoutin(2f));
        StartCoroutine(LevelTimerRoutin());
    }
    void Update()
    {
        if (Time.timeScale <= 0)
            return;
        LevelCheck();
    }
    public void NextWave()
    {
        if (currentLevel.CurrentWave < currentLevel.MaxWaves)
        {
            currentLevel.CurrentWave++;
            playerScript.PlayAnimation("PlayerDisappears");;
            Time.timeScale = 0;

            anim.Play("LightDown");

            GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
            DestroyEnemyies(enemys);

            anim.Play("LightUp");

            Time.timeScale = 1f;
            player.transform.position = Vector3.zero;
            playerScript.PlayAnimation("PlayerAppears");
            StartCoroutine(SpawnEnemiesAfterSomeTimeRoutin(2f));
        }
        else
        {
            Time.timeScale = 0f;
            winPopup.SetActive(true);
        }
    }
    private void SpawnEnemies()
    {
        List<int> list = new();
        for (int i = 0; i < currentLevel.PointInCurrentWave; i++)
        {
            int randomPoint = GetRandomPoint(list);
            list.Add(randomPoint);
            Instantiate(Enemy, RandomPoints[randomPoint].position, Quaternion.identity);
        }
    }
    private void LevelCheck()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        FinishPortal.GetComponent<FinishPortal>().Deactivate();
        if (enemys.Length > 0)
        {
            for (int i = 0; i < enemys.Length; i++)
            {
                if (!enemys[i].GetComponent<Enemy>().IsFrozen)
                {
                    FinishPortal.GetComponent<FinishPortal>().Deactivate();
                    return;
                }
            }
            FinishPortal.GetComponent<FinishPortal>().Activate();
        }
    }
    private IEnumerator SpawnEnemiesAfterSomeTimeRoutin(float time)
    {
        yield return new WaitForSeconds(time);
        SpawnEnemies();
    }
    private IEnumerator LevelTimerRoutin()
    {
        while (true)
        {
            levelTimeText.text = $"{levelTimeMin:D2}:{levelTimeSec:D2}";
            yield return new WaitForSeconds(1);
            if(levelTimeSec == 59)
            {
                levelTimeSec = 0;
                levelTimeMin++;
                continue;
            }
            levelTimeSec++;
        }
    }

    private void DestroyEnemyies(GameObject[] enemyies)
    {
        foreach (GameObject enemy in enemyies)
        {
            Destroy(enemy);
        }
    }
    private int GetRandomPoint(List<int> listWithData)
    {
        int randomPoint = UnityEngine.Random.Range(0, RandomPoints.Length);
        if (listWithData.Contains(randomPoint))
            return GetRandomPoint(listWithData);
        else
            return randomPoint;
    }
}
