using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;

    [SerializeField]
    private float soldierCam, carCam;


    private void Start()
    {
        Camera mainCamera = GetComponent<Camera>();

        if (obj.CompareTag("soldier"))
            mainCamera.orthographicSize = soldierCam;
        else if (obj.CompareTag("car"))
            mainCamera.orthographicSize = carCam;
    }

    private void LateUpdate()
    {
        // This is another way.
        // transform.position = car.transform.position + new Vector3(0, 0, -10);

        // I like mine better, because we're using a native method.

        Vector3 carPosition = obj.transform.position;
        transform.SetPositionAndRotation(
            new Vector3(carPosition.x, carPosition.y, transform.position.z),
            transform.rotation
        );        
    }
}