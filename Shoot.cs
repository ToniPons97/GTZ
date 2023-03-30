using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    
    [SerializeField]
    private GameObject bullet;

    private Transform spawnPoint;

    [SerializeField]
    private float bulletForce = 10f;

    private Animator soldierAnimator;

    private void Start()
    {
        spawnPoint = transform.GetChild(0).transform;
        soldierAnimator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        // Shooting
        if (Input.GetMouseButtonDown(0))
            soldierAnimator.SetBool("isShooting", true);
        else if (Input.GetMouseButtonUp(0))
            soldierAnimator.SetBool("isShooting", false);  
    }

    public void Fire()
    {
        GameObject bulletInstance = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
        Rigidbody2D rb2D = bulletInstance.GetComponent<Rigidbody2D>();
        rb2D.AddForce(spawnPoint.up * bulletForce, ForceMode2D.Impulse);
    }
}