using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    public Transform jugador;
    public float speedIncreasePerSecond = 0.1f;
    public NavMeshAgent agent;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.destination = jugador.position;
    }

}
