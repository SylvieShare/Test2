using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngularVelocity : MonoBehaviour
{
    public Vector2 angularVelocity;
    public Vector2 Scale;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.angularVelocity = Random.Range(angularVelocity.x, angularVelocity.y);
        transform.localScale *= Random.Range(Scale.x, Scale.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
