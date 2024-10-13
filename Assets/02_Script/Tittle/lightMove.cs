using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightMove : MonoBehaviour
{
    float dir = 1;
    float randomY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * 5.5f * dir,0);

        if (transform.position.x > 7)
        {
            randomY = Random.Range(-3, 4);
            transform.position = new Vector3(6.9f, randomY);
            dir = -1;
        }

        if (transform.position.x < -7)
        {
            randomY = Random.Range(-3, 2);
            transform.position = new Vector3(-6.9f, randomY);
            dir = 1;
        }
    }
}
