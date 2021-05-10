using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(KinematicCore))]
public class KinematicWander : MonoBehaviour
{
    private KinematicCore agent;

    private float rotationRate = 0;
    private float wanderScale = .44f;
    private float wanderRange = 0.5f;

    public Transform targetTransform;
    public Vector3 targetPosition;

    void Start()
    {
        agent = GetComponent<KinematicCore>();
    }
    
    void Update()
    {
        rotationRate += wanderScale * (Random.Range(0f, .5f) - Random.Range(0f, .5f));
        rotationRate = Mathf.Clamp(rotationRate, -wanderRange, wanderRange);
        agent.SetRotation(rotationRate);
        agent.SetVelocity(transform.forward, 1);
    }

    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, 20)){
            Debug.Log("wall");
            Vector3 positionDifference = targetPosition - transform.position;
            agent.SetRotation(90f);
        }
    }

}

