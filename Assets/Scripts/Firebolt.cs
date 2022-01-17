using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firebolt : MonoBehaviour
{
    private float speed = 1.8f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0f, 2f) * speed * Time.deltaTime);

        if (transform.position.y >= 7)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        DarkWizard temp = target.GetComponent<DarkWizard>();
        Crate temp1 = target.GetComponent<Crate>();
        if (temp != null)
        {
            Destroy(gameObject);
            temp.GetHit();
        }
        else if (temp1 != null)
        {
            Destroy(gameObject);
            temp1.TakeDamage();
        }
    }
}
