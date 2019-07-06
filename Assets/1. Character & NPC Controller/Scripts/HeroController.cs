using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class HeroController : MonoBehaviour
{
    private Animator animator; // reference to the animator component
    private NavMeshAgent agent; // reference to the NavMeshAgent
    private static readonly int Speed = Animator.StringToHash("Speed");

    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        animator.SetFloat(Speed, agent.velocity.magnitude);
    }
}
