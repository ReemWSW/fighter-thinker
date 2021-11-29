using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitEnemy : MonoBehaviour
{
    public float speed = 6f;

    public float SecondaryDestroy = 0.5f;

    float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "HitArea")
        {
            Destroy(gameObject);
        }
    }
}
