using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    public float dampTime = 0.15f;

    public Vector3 velocity = Vector2.zero;

    public float currentPostX;

    public Transform target;

    Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            transform.position =
                Vector3
                    .SmoothDamp(transform.position,
                    new Vector3(target.position.x,
                        transform.position.y,
                        transform.position.z),
                    ref velocity,
                    dampTime);
        }
    }
}
