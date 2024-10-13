using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OverNotice : MonoBehaviour
{
    public GameObject notice;
    SpriteRenderer renderer;
    float speed;
    Color newAlpha;

    // Start is called before the first frame update
    void Start()
    {
        renderer = this.GetComponent<SpriteRenderer>();
        speed = Time.deltaTime * 1;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0, 1*speed));
        newAlpha.a = renderer.color.a - speed;
        renderer.color = new Color(255,255,255,newAlpha.a);

        if (renderer.color.a <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
