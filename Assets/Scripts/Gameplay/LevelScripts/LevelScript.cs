using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    [SerializeField] private Transform[] RandomPoints;
    [SerializeField] private GameObject FinishPortal;
    [SerializeField] private GameObject player;
    private Animation anim;
    private Player playerScript;
    private int maxCountEnemysOnLevel;
    private int maxWaves;
    private int currentWave;
    void Start()
    {
        playerScript = player.GetComponent<Player>();
        anim = GetComponent<Animation>();
        Time.timeScale = 1.0f;
        maxCountEnemysOnLevel = 1;
        maxWaves = 3;   
        currentWave = 1;
        SpawnEnemies();
    }
    void Update()
    {
        LevelCheck();
    }
    public void NextWave()
    {
        if (currentWave < maxWaves)
        {
            currentWave++;
            playerScript.PlayAnimation("PlayerDisappears");;
            Time.timeScale = 0;
            anim.Play("LightDown");
            GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
            DestroyEnemyies(enemys);
            anim.Play("LightUp");
            Time.timeScale = 1f;
            player.transform.position = Vector3.zero;
            playerScript.PlayAnimation("PlayerAppears");
            StartCoroutine(SpawnEnemiesAfterSomeTimeRoutin(3f));
        }
        else
        {
            Time.timeScale = 0;
            Debug.Log("You win!");
        }
    }
    private void SpawnEnemies()
    {
        List<int> list = new();
        for (int i = 0; i < maxCountEnemysOnLevel; i++)
        {
            int randomPoint = GetRandomPoint(list);
            list.Add(randomPoint);
            Debug.Log(RandomPoints[randomPoint].position);
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
    private void DestroyEnemyies(GameObject[] enemyies)
    {
        foreach (GameObject enemy in enemyies)
        {
            Destroy(enemy);
        }
    }
    private int GetRandomPoint(List<int> listWithData)
    {
        int randomPoint = Random.Range(0, RandomPoints.Length);
        if (listWithData.Contains(randomPoint))
            return GetRandomPoint(listWithData);
        else
            return randomPoint;
    }
}
