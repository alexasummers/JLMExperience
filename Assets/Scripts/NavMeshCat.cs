using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMeshCat : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent _navMeshAgent;
    public Transform goToPoint;
    public RaycastHit hit;

    private Transform _raycastPoint;
    private Animator _animator;

    void Start() 
    {
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        _navMeshAgent.SetDestination(goToPoint.position);
        Vector3 shootRay = _raycastPoint.TransformDirection(Vector3.down) * 100;

        Vector3 moveTowardsPosition = hit.point;
        moveTowardsPosition.y = transform.position.y;

        transform.position = Vector3.MoveTowards(transform.position,moveTowardsPosition,_navMeshAgent.speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "OVRPlayerController")
        {
            _animator.SetFloat("Cat", 0.5f);
            _navMeshAgent.speed = 0;
        }
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.name == "OVRPlayerController")
        {
            _animator.SetFloat("Cat", 1f);
        }
    }

     void OnCollisionExit(Collision collisionInfo)
    {
         _animator.SetFloat("Cat", 0.0f);
         _navMeshAgent.speed = 1.5f;
    }
}