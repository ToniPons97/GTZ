using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCar : MonoBehaviour
{
    [SerializeField]
    private GameObject car;

    private void LateUpdate()
    {
        // This is another way.
        // transform.position = car.transform.position + new Vector3(0, 0, -10);

        // I like mine better, because we're using a native method.

        Vector3 carPosition = car.transform.position;
        transform.SetPositionAndRotation(
            new Vector3(carPosition.x, carPosition.y, transform.position.z),
            transform.rotation
        );        
    }
}