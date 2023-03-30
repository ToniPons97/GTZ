using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierController : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed = 0.1f;

    private Animator soldierAnimator;

    private void Start()
    {
        soldierAnimator = GetComponent<Animator>();
    }

    public void StopReloadingAnim ()
    {
        soldierAnimator.SetBool("isReloading", false);
    }

    // Update is called once per frame
    void Update()
    {
        // Rotation
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x -= objectPos.x;
        mousePos.y -= objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        // Movement

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Time.deltaTime * walkSpeed * Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Time.deltaTime * walkSpeed * Vector3.right;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.position += Time.deltaTime * walkSpeed * Vector3.up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += Time.deltaTime * walkSpeed * Vector3.down;
        }

        // Animation
        // Walking
        if (Input.GetKey(KeyCode.A)
            || Input.GetKey(KeyCode.D)
            || Input.GetKey(KeyCode.W)
            || Input.GetKey(KeyCode.S))
        {
            soldierAnimator.SetBool("isWalking", true);
        }
        else
        {
            soldierAnimator.SetBool("isWalking", false);
        }

        // Reloading
        if (Input.GetKey(KeyCode.R))
        {
            soldierAnimator.SetBool("isReloading", true);
        }
    }
}