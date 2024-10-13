using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    // 각 메뉴 버튼
    [Header("SelectBtn")]
    public Button shopBtn;
    public Button upgradeBtn;
    public Button gameStartBtn;
    public Button partnerBtn;
    public Button storageBtn;


    [Header("ViewUI")]
    public GameObject[] selectMenu;
    int currentMenu;

    void Start()
    {
        shopBtn.onClick.AddListener( delegate { SelectMenuUI(0); });
        upgradeBtn.onClick.AddListener(delegate { SelectMenuUI(1); });
        gameStartBtn.onClick.AddListener(delegate { SelectMenuUI(2); });
        partnerBtn.onClick.AddListener(delegate { SelectMenuUI(3); });
        storageBtn.onClick.AddListener(delegate { SelectMenuUI(4); });
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectMenuUI(int i)
    {
        Camera.main.transform.position = new Vector3(-12+6*i,0,-10);
        currentMenu = i;
        for ( i = 0; i < selectMenu.Length; i++)
        {
            if(currentMenu == i)
            {
                selectMenu[i].gameObject.SetActive(true);
            }
            else
            {
                selectMenu[i].gameObject.SetActive(false);
            }
        }
    }

}
