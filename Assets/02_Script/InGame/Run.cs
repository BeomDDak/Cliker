using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Run : MonoBehaviour
{
    //시작 조건
    public GameObject startpanel, endpanel, liePanel, startTxt;
    public Button startBtn;
    float startTime;


    // 남은 시간
    float timeremain;

    // 남은시간 UI
    public TextMeshProUGUI timeTxt, successTxt;
    public Slider timeSlider;

    // 도망가기 버튼
    public Button runBtn;

    // 플레이어
    public GameObject player;
    public Animator playerAnim;
    public GameObject TxtImage;

    // 도망가기
    float difficulty = 90; // 성공 기준
    int successUpgrade; // 성공 확률 업그레이드
    int successProbability; // 성공 기준과 업그레이드 합친 값

    // 도망친 후 나오는 UI
    public GameObject successUI, failUI;
    public Button goMainBtn;

    // 클릭 시 나오는 이미지
    public Button clickBtn;
    public GameObject[] prefapItem;
    GameObject[] clones;
    GameObject clone;

    //아이템 임시 저장
    uint gimbabCount;
    uint ramenCount;
    uint colaCount;
    public TextMeshProUGUI gimbabCountTxt;
    public TextMeshProUGUI ramenCountTxt;
    public TextMeshProUGUI colaCountTxt;

    // 가방
    public GameObject bagPanel;
    public int bagWeight;
    public GameObject overWeighNotice;
    public Slider weightSlider;


    // 스타트
    void Start()
    {
        //시작 패널 켜고 종료 패널 끄기
        startpanel.SetActive(true);
        liePanel.SetActive(false);
        endpanel.SetActive(false);

        // 시간초 계산해주기
        timeremain = 30 + Goods.gm.quickfeet.value;
        timeSlider.maxValue = timeremain;

        // 버튼 활성화
        runBtn.onClick.AddListener(LiePanal); //
        goMainBtn.onClick.AddListener(RunGame);
        clickBtn.onClick.AddListener(Click);

        // 가방 텍스트
        weightSlider.maxValue = Goods.gm.bagWeight;
        gimbabCountTxt.text = "수량 : 0 개";
        ramenCountTxt.text = "수량 : 0 개";
        colaCountTxt.text = "수량 : 0 개";
        
    }

    // 업데이트
    void Update()
    {
        // 게임 시작
        startTime += Time.deltaTime;
        if (startTime >= 2f)
        {
            startTxt.SetActive(true);
            startBtn.onClick.AddListener(StartGame);
        }

        // 게임 진행
        if (startpanel.activeSelf == false && liePanel.activeSelf == false)
        {
            TimeRemainingText();
            TimeRemainingSlider();

            // 아이템 수량,무게 텍스트 보여주기
            weightSlider.value = bagWeight;
            gimbabCountTxt.text = "수량 : " + gimbabCount.ToString() + "개";
            ramenCountTxt.text = "수량 : " + ramenCount.ToString() + "개";
            colaCountTxt.text = "수량 : " + colaCount.ToString() + "개";
            

            // 아이템 생성 효과 및 파괴
            clones = GameObject.FindGameObjectsWithTag("Item");
            foreach(GameObject clone in clones)
            {
                clone.transform.Rotate(0, 0, 0.2f);

                if (clone.transform.position.y <= -6f)
                {
                    Destroy(clone);
                }
            }

            // 10초 미만이면 탈출확률 하락
            if (timeremain < 10)
            {
                difficulty -= Time.deltaTime * 5;
            }

            // 0초가 되면 탈출확률 0
            if (timeremain == 0)
            {
                difficulty = 0;
                bagPanel.SetActive(false);
                EndAnim();
                Invoke("SuccessOrNot",2f);
            }

        }

        // 시작할때 들어오는 애니메이션
        else if (startpanel.activeSelf == true && liePanel.activeSelf == false)
        {
            StartAnim();
        }
        // 끝나고 도망가는 애니메이션
        else
        {
            EndAnim();
        }

    }
    // ----------- 함수 ---------------

    // 메인메뉴로 돌아가기
    void RunGame()
    {
        SceneManager.LoadScene("Main");
    }

    // 성공 실패 여부 판단
    void SuccessOrNot()
    {
        endpanel.SetActive(true);
        liePanel.SetActive(false);
        playerAnim.SetTrigger("Idle");
        int success = Random.Range(1, 100);

        // 0초가 되면 무조건 실패
        if (timeremain == 0)
        {
            difficulty = 0;
        }

        // 성공 실패 UI 띄우기
        if (success <= successProbability)
        {
            successUI.SetActive(true);

            // 아이템 경험치 올려줌
            Goods.gm.gimbab.count += gimbabCount;
            Goods.gm.lamen.count += ramenCount;
            Goods.gm.cola.count += colaCount;
            Goods.gm.characterLevel += 100;
        }
        else
        {
            failUI.SetActive(true);
        }

    }

    // 텍스트 시간초 계산
    void TimeRemainingText()
    {
        successProbability = (int)difficulty + successUpgrade;

        timeTxt.text = "남은 시간 : " + timeremain.ToString("F1") + " 초";
        timeremain -= Time.deltaTime;
        if (timeremain <= 0)
        {
            timeremain = 0;
        }

        successTxt.text = "성공 확률 : " + successProbability + " %";

    }

    // 슬라이더 시간초 계산
    public void TimeRemainingSlider()
    {
        timeSlider.value += Time.deltaTime;
    }

    // 캐릭터 애니메이션
    void StartAnim()
    {
        float speed = 4 * Time.deltaTime;
        float playerX = player.transform.position.x;
        if (playerX >= -1)
        {
            player.transform.position = new Vector2(-1,-1);
            playerAnim.SetInteger("AnimPlayer", 1);
            TxtImage.SetActive(true);
        }
        else
        {
            player.transform.Translate(Vector2.right * speed);
        }
    }
    
    // 게임 끝나는 애니메이션
    void EndAnim()
    {
        float speed = 4 * Time.deltaTime;
        float playerX = player.transform.position.x;
        if (playerX >= 7)
        {
            player.transform.position = new Vector2(7, -1);
            playerAnim.SetInteger("AnimPlayer", 1);
            
        }
        else
        {
            playerAnim.SetInteger("AnimPlayer", 3);
            player.transform.Translate(Vector2.right * speed);
        }
    }

    // 스타트 패널
    void StartGame()
    {
        startpanel.SetActive(false);
    }

    // 클릭시 호출되는 함수
    void Click()
    {
        // 아이템 생성, 캐릭터 애니메이션

        int i = Random.Range(0, 3);

        Vector2 clickPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject upclone = null;
            //클릭시 애니메이션
        playerAnim.SetTrigger("StealAnim");
        Invoke("ReturnToIdle", 0.23f);

        
        // 클릭시 아이템 수량 무게 올라감

        if(bagWeight < Goods.gm.bagWeight)
        {
            switch (i)
            {
                case 0:
                    upclone = Instantiate(prefapItem[0], clickPoint, Quaternion.identity);
                    upclone.GetComponent<Rigidbody2D>().velocity = Vector2.up * 3;
                    gimbabCount++;
                    
                    break;
                case 1:
                    upclone = Instantiate(prefapItem[1], clickPoint, Quaternion.identity);
                    upclone.GetComponent<Rigidbody2D>().velocity = Vector2.up * 3;
                    ramenCount++;
                    
                    break;
                default:
                    upclone = Instantiate(prefapItem[2], clickPoint, Quaternion.identity);
                    upclone.GetComponent<Rigidbody2D>().velocity = Vector2.up * 3;
                    colaCount++;
                    
                    break;
            }
            bagWeight = (int)(gimbabCount + ramenCount + colaCount);
        }
        else
        {
            Instantiate(overWeighNotice, clickPoint, Quaternion.identity);
        }
    }

    // Idle 애니메이션
    void ReturnToIdle()
    {
        playerAnim.SetTrigger("Idle");
    }

    // 가짜패널
    void LiePanal()
    {
        liePanel.SetActive(true); 
        Invoke("SuccessOrNot", 2f);
    }

}
