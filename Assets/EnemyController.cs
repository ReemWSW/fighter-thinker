using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 100;

    public int damage = 50;

    public int number;

    public float fireRate = 0.2f;

    public float nextFireRate = 0.0f;

    public GameObject hitEnemy;

    private Rigidbody2D rb2d;

    private Animator anim;

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetBool("Grounded", true);
        number = Random.Range(1, 1000);
        if (number == 5 && Time.time > nextFireRate)
        {
            nextFireRate = Time.time + fireRate;
            anim.SetBool("Attack", true);
            hitEnemy.SetActive(true);
            Instantiate(hitEnemy, transform.position,  Quaternion.Euler(0f, 180f, 0f));
            Debug.Log("SHOOT");
        }
        else
        {
            anim.SetBool("Attack", false);
            hitEnemy.SetActive(false);
        }

        if (health <= 0)
        {
            Destroy (gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "HitArea")
        {
            health -= damage;
        }
    }
}
