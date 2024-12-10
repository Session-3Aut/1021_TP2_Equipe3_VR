using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementEnnemies : MonoBehaviour
{
    private Transform pointA;
    public float speed = 1f;

    private Transform currentTarget;

    private enum MovementState { MovingToPointA };
    private MovementState currentState = MovementState.MovingToPointA;


  void Start()
    {
        // Automatically find the object named "PointA" in the scene
        if (pointA == null)
        {
            GameObject foundPointA = GameObject.Find("PointA");
            if (foundPointA != null)
            {
                pointA = foundPointA.transform;
            }
            else
            {
                Debug.LogError("No object named 'PointA' found in the scene!");
            }
        }
    }
    void Update()
    {
        switch (currentState)
        {
            case MovementState.MovingToPointA:
                MoveToPoint(pointA);
                break;
        }

        if (currentTarget != null) 
        {
            Vector3 directionToTarget = (currentTarget.position - transform.position).normalized;

            if (directionToTarget != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(directionToTarget);
            }
        }
    }

    private void MoveToPoint(Transform targetPoint)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPoint.position) < 0.01f){

            switch (currentState)
            {
                case MovementState.MovingToPointA:
                    currentTarget = pointA;
                    break;
            }
        
        }
    }
}
