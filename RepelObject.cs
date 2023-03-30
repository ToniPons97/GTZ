using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepelObject : MonoBehaviour
{

    [SerializeField]
    private GameObject objectToRepel;

    private Rigidbody2D objectRigidBody;

    [SerializeField]
    private float thrust = 3f;



    private void Start()
    {
        objectRigidBody = objectToRepel.GetComponent<Rigidbody2D>();
    }

    IEnumerator applyThrustAfterTime(float timeDelay)
    {

        // The added vector should depend on the car's approaching direction.
        // Maybe we want to add a bit of rotation as well.
        objectRigidBody.AddForce(Vector2.left * thrust, ForceMode2D.Impulse);
        //objectRigidBody.inertia = 0f;

        yield return new WaitForSeconds(timeDelay);

        objectRigidBody.velocity = Vector2.zero;
        objectRigidBody.inertia = 100f;

        Debug.Log("Stopped thrust.");
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(objectToRepel.tag))
            StartCoroutine(applyThrustAfterTime(2f));
    }
}
