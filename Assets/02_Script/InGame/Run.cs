using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Run : MonoBehaviour
{
    //���� ����
    public GameObject startpanel, endpanel, liePanel, startTxt;
    public Button startBtn;
    float startTime;


    // ���� �ð�
    float timeremain;

    // �����ð� UI
    public TextMeshProUGUI timeTxt, successTxt;
    public Slider timeSlider;

    // �������� ��ư
    public Button runBtn;

    // �÷��̾�
    public GameObject player;
    public Animator playerAnim;
    public GameObject TxtImage;

    // ��������
    float difficulty = 90; // ���� ����
    int successUpgrade; // ���� Ȯ�� ���׷��̵�
    int successProbability; // ���� ���ذ� ���׷��̵� ��ģ ��

    // ����ģ �� ������ UI
    public GameObject successUI, failUI;
    public Button goMainBtn;

    // Ŭ�� �� ������ �̹���
    public Button clickBtn;
    public GameObject[] prefapItem;
    GameObject[] clones;
    GameObject clone;

    //������ �ӽ� ����
    uint gimbabCount;
    uint ramenCount;
    uint colaCount;
    public TextMeshProUGUI gimbabCountTxt;
    public TextMeshProUGUI ramenCountTxt;
    public TextMeshProUGUI colaCountTxt;

    // ����
    public GameObject bagPanel;
    public int bagWeight;
    public GameObject overWeighNotice;
    public Slider weightSlider;


    // ��ŸƮ
    void Start()
    {
        //���� �г� �Ѱ� ���� �г� ����
        startpanel.SetActive(true);
        liePanel.SetActive(false);
        endpanel.SetActive(false);

        // �ð��� ������ֱ�
        timeremain = 30 + Goods.gm.quickfeet.value;
        timeSlider.maxValue = timeremain;

        // ��ư Ȱ��ȭ
        runBtn.onClick.AddListener(LiePanal); //
        goMainBtn.onClick.AddListener(RunGame);
        clickBtn.onClick.AddListener(Click);

        // ���� �ؽ�Ʈ
        weightSlider.maxValue = Goods.gm.bagWeight;
        gimbabCountTxt.text = "���� : 0 ��";
        ramenCountTxt.text = "���� : 0 ��";
        colaCountTxt.text = "���� : 0 ��";
        
    }

    // ������Ʈ
    void Update()
    {
        // ���� ����
        startTime += Time.deltaTime;
        if (startTime >= 2f)
        {
            startTxt.SetActive(true);
            startBtn.onClick.AddListener(StartGame);
        }

        // ���� ����
        if (startpanel.activeSelf == false && liePanel.activeSelf == false)
        {
            TimeRemainingText();
            TimeRemainingSlider();

            // ������ ����,���� �ؽ�Ʈ �����ֱ�
            weightSlider.value = bagWeight;
            gimbabCountTxt.text = "���� : " + gimbabCount.ToString() + "��";
            ramenCountTxt.text = "���� : " + ramenCount.ToString() + "��";
            colaCountTxt.text = "���� : " + colaCount.ToString() + "��";
            

            // ������ ���� ȿ�� �� �ı�
            clones = GameObject.FindGameObjectsWithTag("Item");
            foreach(GameObject clone in clones)
            {
                clone.transform.Rotate(0, 0, 0.2f);

                if (clone.transform.position.y <= -6f)
                {
                    Destroy(clone);
                }
            }

            // 10�� �̸��̸� Ż��Ȯ�� �϶�
            if (timeremain < 10)
            {
                difficulty -= Time.deltaTime * 5;
            }

            // 0�ʰ� �Ǹ� Ż��Ȯ�� 0
            if (timeremain == 0)
            {
                difficulty = 0;
                bagPanel.SetActive(false);
                EndAnim();
                Invoke("SuccessOrNot",2f);
            }

        }

        // �����Ҷ� ������ �ִϸ��̼�
        else if (startpanel.activeSelf == true && liePanel.activeSelf == false)
        {
            StartAnim();
        }
        // ������ �������� �ִϸ��̼�
        else
        {
            EndAnim();
        }

    }
    // ----------- �Լ� ---------------

    // ���θ޴��� ���ư���
    void RunGame()
    {
        SceneManager.LoadScene("Main");
    }

    // ���� ���� ���� �Ǵ�
    void SuccessOrNot()
    {
        endpanel.SetActive(true);
        liePanel.SetActive(false);
        playerAnim.SetTrigger("Idle");
        int success = Random.Range(1, 100);

        // 0�ʰ� �Ǹ� ������ ����
        if (timeremain == 0)
        {
            difficulty = 0;
        }

        // ���� ���� UI ����
        if (success <= successProbability)
        {
            successUI.SetActive(true);

            // ������ ����ġ �÷���
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

    // �ؽ�Ʈ �ð��� ���
    void TimeRemainingText()
    {
        successProbability = (int)difficulty + successUpgrade;

        timeTxt.text = "���� �ð� : " + timeremain.ToString("F1") + " ��";
        timeremain -= Time.deltaTime;
        if (timeremain <= 0)
        {
            timeremain = 0;
        }

        successTxt.text = "���� Ȯ�� : " + successProbability + " %";

    }

    // �����̴� �ð��� ���
    public void TimeRemainingSlider()
    {
        timeSlider.value += Time.deltaTime;
    }

    // ĳ���� �ִϸ��̼�
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
    
    // ���� ������ �ִϸ��̼�
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

    // ��ŸƮ �г�
    void StartGame()
    {
        startpanel.SetActive(false);
    }

    // Ŭ���� ȣ��Ǵ� �Լ�
    void Click()
    {
        // ������ ����, ĳ���� �ִϸ��̼�

        int i = Random.Range(0, 3);

        Vector2 clickPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject upclone = null;
            //Ŭ���� �ִϸ��̼�
        playerAnim.SetTrigger("StealAnim");
        Invoke("ReturnToIdle", 0.23f);

        
        // Ŭ���� ������ ���� ���� �ö�

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

    // Idle �ִϸ��̼�
    void ReturnToIdle()
    {
        playerAnim.SetTrigger("Idle");
    }

    // ��¥�г�
    void LiePanal()
    {
        liePanel.SetActive(true); 
        Invoke("SuccessOrNot", 2f);
    }

}
