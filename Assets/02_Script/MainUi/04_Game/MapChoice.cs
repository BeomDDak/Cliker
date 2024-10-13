using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapChoice : MonoBehaviour
{
    
    int maxPage = 5;
    int minPage = 0;
    int currentPage = 0;
    public GameObject[] arrChoiceMaps;
    public GameObject[] arrConfirmMap;

    public Button nextBtn, prevBtn,selectMapBtn,startBtn;
    // Start is called before the first frame update
    void Start()
    {
        nextBtn.onClick.AddListener(NextPage);
        prevBtn.onClick.AddListener(PrevPage);
        selectMapBtn.onClick.AddListener(SelectMap);
        startBtn.onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NextPage()
    {
        if (currentPage <= maxPage-1 && currentPage >=minPage)
        {
            nextBtn.interactable = true;
#pragma warning disable CS1717 // 같은 변수에 할당했습니다.
            for(currentPage = currentPage; currentPage < maxPage; currentPage++)
            {
                arrChoiceMaps[currentPage].gameObject.SetActive(false);
                currentPage++;
                arrChoiceMaps[currentPage].gameObject.SetActive(true);
                break;
            }
#pragma warning restore CS1717 // 같은 변수에 할당했습니다.
        }
        else
        {
            nextBtn.interactable = false;
        }
        nextBtn.interactable = true;
    }

    void PrevPage()
    {
        if (currentPage <= maxPage && currentPage > minPage)
        {
            prevBtn.interactable = true;
            for (currentPage = currentPage; currentPage <= maxPage; currentPage--)
            {
                arrChoiceMaps[currentPage].gameObject.SetActive(false);
                currentPage--;
                arrChoiceMaps[currentPage].gameObject.SetActive(true);
                break;
            }
        }
        else
        {
            prevBtn.interactable = false;
        }
        prevBtn.interactable = true;
    }

    void SelectMap()
    {
        for (int i = 0; i < arrChoiceMaps.Length; i++)
        {
            arrConfirmMap[i].gameObject.SetActive(false);
        }
        arrConfirmMap[currentPage].gameObject.SetActive(true);
        GameObject.Find("Map").SetActive(false);
    }

    void StartGame()
    {
        if (currentPage == 0)
        {
            SceneManager.LoadScene("ConvenienceStoreScene");
        }

        else if (currentPage == 1)
        {
            SceneManager.LoadScene("MartScene");
        }

        else if (currentPage == 2)
        {
            SceneManager.LoadScene("BankScene");
        }

        else if (currentPage == 3)
        {
            SceneManager.LoadScene("ElectronicMartScene");
        }

        else if (currentPage == 4)
        {
            SceneManager.LoadScene("JewelShopScene");
        }

        else
        {
            SceneManager.LoadScene("HeadBankScene");
        }
    }
}
