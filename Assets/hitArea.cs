using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitArea : MonoBehaviour
{
    public float speed = 6f;

    public float SecondaryDestroy = 0.5f;

    float startTime;

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
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "HitEnemy")
        {
            Destroy(gameObject);
        }
    }

}
