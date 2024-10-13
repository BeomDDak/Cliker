using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopper : MonoBehaviour
{
    public GameObject[] shopperSay;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShopperSay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ShopperSay()
    {
        while (true)
        {
            int i = Random.Range(0, shopperSay.Length);
            shopperSay[i].SetActive(true);

            yield return new WaitForSeconds(3f);

            foreach (GameObject go in shopperSay)
            {
                go.SetActive(false);
            }
        }
    }
}
