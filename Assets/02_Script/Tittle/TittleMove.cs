using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TittleMove : MonoBehaviour
{
    SpriteRenderer playerSprit;
    float dir = 1;
    float randomY;
    // Start is called before the first frame update
    void Start()
    {
        playerSprit = GetComponent<SpriteRenderer>();
        StartCoroutine(random());
    }

    // Update is called once per frame
    void Update()
    {

        // 플레이어
        transform.Translate(Vector2.right * Time.deltaTime * 5 * dir, 0);

        if (transform.position.x > 5)
        {
            transform.position = new Vector2(4.9f, randomY);
            playerSprit.flipX = true;
            dir = -1;
        }

        if (transform.position.x < -6)
        {
            transform.position = new Vector2(-4.9f, randomY);
            playerSprit.flipX = false;
            dir = 1;
        }
    }
    IEnumerator random()
    {
        while (true)
        {
            randomY = Random.Range(-3, 2);
            yield return new WaitForSeconds(2f);
        }
    }
}
