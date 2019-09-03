using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int hp;
    public int score;
    public bool automove;
    public Bolt shot;
    public Transform[] Cannon;
    public GameObject Explosion;

    private Rigidbody2D rb2d;
    private Vector3 pointMove;
    private bool firstMove;
    private static float FIRSTSPEEDK = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        if (automove)
        {
            speed *= FIRSTSPEEDK;
            firstMove = true;
            pointMove = transform.position + new Vector3(0, -3, 0);
        }
        else
            rb2d.velocity = speed * new Vector3(
                0,
                -speed,
                0);

        if (shot != null)
            InvokeRepeating("Fire", 1, shot.fireRate);
    }

    void Fire()
    {
        if(!firstMove)
            foreach (Transform cann in Cannon) {
                Bolt bolt = Instantiate(shot, cann.position, cann.rotation);
                bolt.sideEnemy = true;
            }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Bolt bolt = other.gameObject.GetComponent(typeof(Bolt)) as Bolt;
        if (bolt != null && bolt.sideFriend)
        {
            Damage(bolt.damage);
            Destroy(other.gameObject);
        }
    }

    public void Damage(int d)
    {
        hp -= d;
        if (hp <= 0)
        {
            if (Explosion != null)
            {
                Destroy(
                    Instantiate(Explosion, transform.position, Quaternion.identity),
                    1f);
            }
            GameController.Score += score;
            Destroy(this.gameObject);
        }
    }

    void NewMovePoint()
    {
        pointMove = new Vector3(Random.Range(-20f, 20f), Random.Range(0f, 10f), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (automove)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointMove, Time.deltaTime * speed);
            if (transform.position == pointMove)
            {
                if (firstMove)
                {
                    speed /= FIRSTSPEEDK;
                    firstMove = false;
                }
                NewMovePoint();
            }
        }
    }
}
