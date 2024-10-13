using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class RunHeadBank : MonoBehaviour
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
    float difficulty = 40; // ���� ���� (����!)
    int successUpgrade; // ���� Ȯ�� ���׷��̵� (����ƽ ����!)
    int successProbability; // ���� ���ذ� ���׷��̵� ��ģ ��

    // ����ģ �� ������ UI
    public GameObject successUI, failUI;
    public Button goMainBtn;

    // Ŭ�� �� ������ �̹���
    public Button clickBtn;
    public GameObject[] prefapItem;
    GameObject[] clones;
    GameObject clone;

    //������ �ӽ� ���� (����!)
    uint cashCount;
    uint cashPacketCount;
    uint goldbarCount;
    uint goldbarPacketCount;
    uint bitcoinCount;
    public TextMeshProUGUI cashCountTxt;
    public TextMeshProUGUI cashPacketCountTxt;
    public TextMeshProUGUI goldbarCountTxt;
    public TextMeshProUGUI goldbarPacketCountTxt;
    public TextMeshProUGUI bitcoinCountTxt;

    // ����
    public GameObject bagPanel;
    public int bagWeight;
    public GameObject overWeighNotice;
    public Slider weightSlider;

    void Start()
    {
        //���� �г� �Ѱ� ���� �г� ����
        startpanel.SetActive(true);
        liePanel.SetActive(false);
        endpanel.SetActive(false);

        // �ð��� ������ֱ�  ( ����!)
        timeremain = 1 + Goods.gm.quickfeet.value;
        timeSlider.maxValue = timeremain;

        // ��ư Ȱ��ȭ
        runBtn.onClick.AddListener(LiePanal);
        goMainBtn.onClick.AddListener(RunGame);
        clickBtn.onClick.AddListener(Click);

        // ���� �ؽ�Ʈ
        weightSlider.maxValue = Goods.gm.bagWeight;
        cashCountTxt.text = "���� : 0 ��";
        cashPacketCountTxt.text = "���� : 0 ��";
        goldbarCountTxt.text = "���� : 0 ��";
        goldbarPacketCountTxt.text = "���� : 0 ��";
        bitcoinCountTxt.text = "���� : 0 ��";

    }

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

            // ������ ���� �ؽ�Ʈ �����ֱ�
            weightSlider.value = bagWeight;
            cashCountTxt.text = "���� : " + cashCount.ToString();
            cashPacketCountTxt.text = "���� : " + cashPacketCount.ToString();
            goldbarCountTxt.text = "���� : " + goldbarCount.ToString();
            goldbarPacketCountTxt.text = "���� : " + goldbarPacketCount.ToString();
            bitcoinCountTxt.text = "���� : " + bitcoinCount.ToString();

            // ������ ���� ȿ�� �� �ı�
            clones = GameObject.FindGameObjectsWithTag("Item");
            foreach (GameObject clone in clones)
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
                Invoke("SuccessOrNot", 2f);
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

            //������ ����ġ �÷���
            Goods.gm.cash.count += (cashCount+cashPacketCount*3);
            Goods.gm.goldbar.count += (goldbarCount+goldbarPacketCount*3);
            Goods.gm.bitcoin.count += bitcoinCount;
            Goods.gm.characterLevel += 20000;
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

    // ĳ���� �ִϸ��̼� �����Ҷ�
    void StartAnim()
    {
        float speed = 4 * Time.deltaTime;
        float playerX = player.transform.position.x;
        if (playerX >= -1)
        {
            player.transform.position = new Vector2(-1, -1);
            playerAnim.SetInteger("AnimPlayer", 1);
            TxtImage.SetActive(true);
        }
        else
        {
            player.transform.Translate(Vector2.right * speed);
        }
    }

    // ĳ���� �ִϸ��̼� ������
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

    // �����Ҷ� ���� �г�
    void StartGame()
    {
        startpanel.SetActive(false);
    }

    void Click()
    {
        // ������ ����, ĳ���� �ִϸ��̼�

        int i = Random.Range(0, 1001);

        Vector2 clickPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        playerAnim.SetTrigger("StealAnim");
        Invoke("ReturnToIdle", 0.23f);


        // Ŭ���� ������ ���� ���� �ö�
        if (bagWeight < Goods.gm.bagWeight)
        {
            switch (i)
            {
                case int x when (x >= 0 && x < 600 - Goods.gm.judgment.value):
                    GameObject upclone = Instantiate(prefapItem[0], clickPoint, Quaternion.identity);
                    upclone.GetComponent<Rigidbody2D>().velocity = Vector2.up * 3;
                    cashCount++;
                    break;
                case int x when (x >= 600 - Goods.gm.judgment.value && x < 800 - Goods.gm.judgment.value / 2):
                    upclone = Instantiate(prefapItem[1], clickPoint, Quaternion.identity);
                    upclone.GetComponent<Rigidbody2D>().velocity = Vector2.up * 3;
                    goldbarCount++;
                    break;
                case int x when (x >= 800 - Goods.gm.judgment.value / 2 && x < 920 - Goods.gm.judgment.value / 4):
                    upclone = Instantiate(prefapItem[2], clickPoint, Quaternion.identity);
                    upclone.GetComponent<Rigidbody2D>().velocity = Vector2.up * 3;
                    cashPacketCount++;
                    break;
                case int x when (x >= 920 - Goods.gm.judgment.value / 4 && x < 999 - Goods.gm.judgment.value / 5):
                    upclone = Instantiate(prefapItem[3], clickPoint, Quaternion.identity);
                    upclone.GetComponent<Rigidbody2D>().velocity = Vector2.up * 3;
                    goldbarPacketCount++;
                    break;
                default:
                    upclone = Instantiate(prefapItem[4], clickPoint, Quaternion.identity);
                    upclone.GetComponent<Rigidbody2D>().velocity = Vector2.up * 3;
                    bitcoinCount++;
                    break;
            }
            bagWeight = (int)(cashCount + cashPacketCount + goldbarCount + goldbarPacketCount + bitcoinCount);
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

    // ������ ����
    void LiePanal()
    {
        liePanel.SetActive(true);

        Invoke("SuccessOrNot", 2f);
    }
}
