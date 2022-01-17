using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkWizard : MonoBehaviour
{
    public GameObject explosion;
    public GameObject chaosbolt;

    private float timer = 0;
    private float timeToMove = 0.5f;
    int numOfMovements = 0;
    float speed = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FireBack", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeToMove)
        {
            transform.Translate(new Vector3(speed, 0, 0));
            timer = 0;
            numOfMovements++;
        }
        if (numOfMovements == 28)
        {
            transform.Translate(new Vector3(0, -0.5f, 0));
            numOfMovements = 0;
            speed = -speed;
        }

    }

    void FireBack()
    {
        if (Random.value < 0.5f)
        {
            Instantiate(chaosbolt, transform.position, Quaternion.identity);
        }
    }

    public void GetHit()
    {
        GameControl.instance.RunningKills();
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
