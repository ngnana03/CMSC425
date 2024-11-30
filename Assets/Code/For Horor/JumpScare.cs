using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class JumpScare : MonoBehaviour
{
    private Transform player;
    public GameObject body;
    public GameObject scary;
    private enum EnemyState { NoScare, Scare }
    private EnemyState currentState = EnemyState.NoScare;
    public void OnTriggerEnter()
    {
        player = body.transform;
        scary.SetActive(true);
        currentState = EnemyState.Scare;
        
    }


    private void Start()
    {
        switch (currentState)
        {
            case EnemyState.NoScare:
                scary.SetActive(false);
                break;
            case EnemyState.Scare:
                scary.SetActive(true);
                scary.transform.position = Vector3.MoveTowards(scary.transform.position, player.position, 5 * Time.deltaTime);
                break;
        }
    }
}
