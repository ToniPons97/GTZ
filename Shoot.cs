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


    [SerializeField]
    private float coolDown = 0.2f;
    private float nextFireTime = 0f;

    [SerializeField]
    private Sprite flashSprite;

    [SerializeField]
    private SpriteRenderer flashPointRenderer;

    [SerializeField]
    private float flashTime = 0.3f;



    private void Start()
    {
        spawnPoint = transform.GetChild(0).transform;
        soldierAnimator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        // Shooting
        if (Input.GetMouseButtonDown(0) && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + coolDown;
            soldierAnimator.SetBool("isShooting", true);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            soldierAnimator.SetBool("isShooting", false);  
        }
    }

    public void Fire()
    {
        GameObject bulletInstance =
            Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

        Rigidbody2D rb2D = bulletInstance.GetComponent<Rigidbody2D>();
        rb2D.AddForce(-spawnPoint.right * bulletForce, ForceMode2D.Impulse);
    }

    public IEnumerator DoFlash()
    {
        flashPointRenderer.enabled = true;
        yield return new WaitForSeconds(flashTime);
        flashPointRenderer.enabled = false;
    }
}