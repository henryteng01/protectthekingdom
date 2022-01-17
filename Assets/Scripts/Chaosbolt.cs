using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaosbolt : MonoBehaviour
{
    public GameObject greensplosion;

    private float speed = 1.8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0f, -2f) * speed * Time.deltaTime);

        if (transform.position.y <= -3.87)
        {
            Instantiate(greensplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        Player temp = target.GetComponent<Player>();
        Crate temp1 = target.GetComponent<Crate>();
        if (temp != null)
        {
            Destroy(gameObject);
            temp.TakeDamage();
        }
        else if (temp1 != null)
        {
            Destroy(gameObject);
            temp1.TakeDamage();
        }
    }
}
