using Assets.Scripts.Arch.Facades;
using Assets.Scripts.DataSave.Data;
using Assets.Scripts.Gameplay.LevelScripts.LevelLogic;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelListMenu : MonoBehaviour
{
    public Image ImagePrefab;

    private bool isActive;

    void Start()
    {
        isActive = false;
        Vector3 lastVector = new Vector3(0, 0, 0);
        foreach (var level in LevelsFacade.Levels)
        {
            var levelPreview = Instantiate(ImagePrefab, lastVector, Quaternion.identity);
            levelPreview.gameObject.transform.SetParent(transform, false);
            MonoLevel levelData = levelPreview.gameObject.GetComponent<MonoLevel>();
            levelData.Level = level.Value;
            lastVector = new Vector3(lastVector.x + 1500, lastVector.y, lastVector.z);

        }
    }
    public void PreviousBtn()
    {
        if (!isActive)
        {
            if(transform.localPosition.x < 0)
            {
                StartCoroutine(SwapRoutin("p"));
            }
            
        }
            
    }
    public void NextBtn()
    {
        if (!isActive)
        {
            
            if (transform.localPosition.x > (-1500 * (LevelsFacade.Levels.Count - 1)))
            {
                StartCoroutine(SwapRoutin("n"));
            }

        }
    }

    private IEnumerator SwapRoutin(String type)
    {
        isActive = true;
        if (type == "n")
        {
            int size = 0;
            while (size < 1500)
            {
                transform.localPosition += new Vector3(-6, 0, 0);
                size += 6;
                yield return null;
            }

        }
        else
        {
            int size = 0;
            while (size < 1500)
            {
                transform.localPosition += new Vector3(6, 0, 0);
                size += 6;
                yield return null;
            }

        }
        isActive = false;
    }

}
