using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    public float speed;
    public float fireRate;
    public int damage;

    [HideInInspector]
    public bool sideFriend;
    [HideInInspector]
    public bool sideEnemy;

    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = speed * new Vector3(
            -Mathf.Sin(transform.rotation.eulerAngles[2] / 180 * Mathf.PI), 
            Mathf.Cos(transform.rotation.eulerAngles[2] / 180 * Mathf.PI),
            0);
    }

    // Update is called once per frame
    void Update()
    {
        //if (transform.position[1] > 50)
        //    Destroy(gameObject);
    }
}
