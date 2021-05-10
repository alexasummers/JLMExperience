using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class KinematicCore : MonoBehaviour
{
    public float maxSpeed = 2f;
    private float maxRotation = 88.8f;
    private bool yVelocityEnabled = false;

    public Vector3 velocity { get; private set; }   // m/s
    public float rotation { get; private set; } // degrees/s

    private CharacterController myCharacterController;

    void Start()
    {
        myCharacterController = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        myCharacterController.Move(velocity * Time.fixedDeltaTime);
        transform.Rotate(Vector3.up, rotation * Time.fixedDeltaTime);
    }

    public void SetVelocity(Vector3 newVelocity, float scale)
    {
        scale = Mathf.Clamp(scale, 0f, 1f);

        if (!yVelocityEnabled) newVelocity.y = 0;

        newVelocity.Normalize();

        velocity = newVelocity * scale * maxSpeed;
    }

    public void SetRotation(float parameterizedRotation)
    {
        float scale = Mathf.Clamp(parameterizedRotation, -1f, 1f);
        rotation = maxRotation * scale;
    }

}
