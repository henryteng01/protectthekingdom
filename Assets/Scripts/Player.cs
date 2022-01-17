using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject firebolt;
    public GameObject explosion;
    public GameObject shieldExplosion;

    private float speed = 5f;
    private float timer = 0;
    private float shootingTimer = 1f;
    private int hp = 7;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.A) && transform.position.x >= -7.3)
        {
            transform.position += new Vector3(-1f, 0, 0) * Time.deltaTime * speed;
            anim.SetTrigger("Left");
        }

        if (Input.GetKey(KeyCode.D) && transform.position.x <= 8.5)
        {
            transform.position += new Vector3(1f, 0, 0) * Time.deltaTime * speed;
            anim.SetTrigger("Right");
        }

        if (Input.GetKeyDown(KeyCode.Space) && timer > shootingTimer)
        {
            timer = 0;
            anim.SetTrigger("Shoot");
            Fireball();
        }
    }

    void Fireball()
    {
        Instantiate(firebolt, new Vector3(transform.position.x, transform.position.y + 1.5f, 0), Quaternion.identity);
    }

    public void TakeDamage()
    {
        hp -= 1;
        GameControl.instance.DeductHealth(hp);

        if (hp > 0)
        {
            Instantiate(shieldExplosion, new Vector3(transform.position.x, -2.12f, 0), Quaternion.identity);
        }
        else 
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            GameControl.instance.PlayerDied();
        }
    }
}
