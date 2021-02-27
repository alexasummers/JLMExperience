using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(KinematicCore))]
public class KinematicWander : MonoBehaviour
{
    private KinematicCore agent;

    private float rotationRate = 0;
    public float wanderScale = 1;
    public float wanderRange = 0.5f;

    void Start()
    {
        agent = GetComponent<KinematicCore>();
    }
    
    void Update()
    {
        rotationRate += wanderScale * (Random.Range(0f, 1f) - Random.Range(0f, 1f));
        rotationRate = Mathf.Clamp(rotationRate, -wanderRange, wanderRange);
        agent.SetRotation(rotationRate);
        agent.SetVelocity(transform.forward, 1);
    }
}
