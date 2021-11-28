using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 1.5f;

    public float maxSpeed = 10f;

    public float fireRate = 0.2f;

    public float nextFireRate = 0.0f;

    private Rigidbody2D rb2d;

    private Animator anim;

    Animator animator;

    public GameObject hitArea;

    public int healthBar = 50;

    public Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "HEALTH : " + healthBar;
        anim.SetBool("Grounded", true);
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }
        else if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (Input.GetKeyDown(KeyCode.J) && Time.time > nextFireRate)
        {
            nextFireRate = Time.time + fireRate;
            anim.SetBool("Attack", true);
            Attack();
        }
        else
        {
            anim.SetBool("Attack", false);
        }
    }

    public void Attack()
    {
        Instantiate(hitArea, transform.position, transform.rotation);
    }
}
