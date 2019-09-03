using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;
    public Bolt Weapon;
    public Transform shotSpawn;
    public int hp = 10;

    public GameObject Explosion;

    private float velocityNow;
    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        velocityNow = 0;
        nextFire = 0;
        GameController.HPPlayer = hp;
        GameController.HPPlayerMax = hp;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        rb2d.velocity = new Vector2(moveHorizontal, 0) * speed;

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + Weapon.fireRate;
            Bolt bolt = Instantiate(Weapon, shotSpawn.position, shotSpawn.rotation);
            bolt.sideFriend = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Bolt bolt = other.gameObject.GetComponent(typeof(Bolt)) as Bolt;
        if (bolt != null && (bolt.sideEnemy))
        {
            Damage(bolt.damage);
            Destroy(other.gameObject);
        }
        Enemy enemy = other.gameObject.GetComponent(typeof(Enemy)) as Enemy;
        if (enemy != null)
        {
            Damage(enemy.hp);
            enemy.Damage(hp);
        }
    }

    public void Damage(int d)
    {
        hp -= d;
        GameController.HPPlayer = hp;
        if (hp <= 0)
        {
            Destroy(this.gameObject);
            if (Explosion != null)
                Destroy(
                    Instantiate(Explosion, transform.position, Quaternion.identity),
                    1f);
        }
    }
}
