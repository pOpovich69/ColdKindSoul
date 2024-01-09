using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor;
using UnityEngine;

public class FinishPortal : MonoBehaviour
{
    [SerializeField] private GameObject helpButton;
    [SerializeField] private LevelScript levelScript;

    private LayerMask playerMask;


    private Animator anim;

    private bool isActive;

    public float activateRadius;

    private void Start()
    {
        anim = GetComponent<Animator>();
        this.gameObject.SetActive(false);
        helpButton.SetActive(false);
        isActive = false;
        playerMask = LayerMask.GetMask("Player");
    }
    private void Update()
    {
        if (!isActive)
            return;
        PlayerCheck();
    }
    public void Activate()
    {
        this.gameObject.SetActive(true);
        isActive = true;
        anim.SetBool("isActive", isActive);
    }
    public void Deactivate()
    {
        isActive = false;
        helpButton.SetActive(false);
        anim.SetBool("isActive", isActive);

    }
    public void DeactivateHelp()
    {
        this.gameObject.SetActive(false);
    }
    private void PlayerCheck()
    {
        Collider2D playerCol = Physics2D.OverlapCircle(transform.position, activateRadius, playerMask);
        if (playerCol != null)
        {
            helpButton.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                levelScript.NextWave();
            }
        }
        else
        {
            helpButton.SetActive(false);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, activateRadius);
    }
}
