using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpgradeUI : MonoBehaviour
{
    public Image upgrade_Background_Image;
    int randomColor;

    void Start()
    {
        StartCoroutine(RandomRgb());
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    IEnumerator RandomRgb()
    {
        while (true)
        {
            randomColor = Random.Range(100, 255);
            upgrade_Background_Image.color = new Color(randomColor/255f, randomColor/255f, randomColor/255f);
            yield return new WaitForSeconds(0.8f);
            upgrade_Background_Image.color = new Color(100 / 255f, 100 / 255f, 100 / 255f);
        }

    }
}
