using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy_Level_2 : MonoBehaviour
{

    public NavMeshAgent enemy;
    public Transform player;
    private Lvl2Controller levelController;

    private void Start()
    {
        levelController = FindObjectOfType<Lvl2Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            levelController.YouLose();
        }
    }
}
