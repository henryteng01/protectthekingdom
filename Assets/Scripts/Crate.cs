using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    public GameObject explosion;

    private int hp = 10;

    public void TakeDamage()
    {
        hp -= 1;

        if (hp == 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}
