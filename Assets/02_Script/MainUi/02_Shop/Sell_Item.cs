using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Sell_Item : MonoBehaviour
{
    // ������ ��ư�� onClick���� ���� ������

    // �Ǹ� ��ư, ���ǰ���, ����, ���� ���� �����̵�, �Ǹ� �� �ѱݾ�
    public Button sellBtn;
    public TextMeshProUGUI totalItemCount;
    public TextMeshProUGUI priceTxt;
    public TextMeshProUGUI itemCountTxt;
    public Slider countSlider;
    public TextMeshProUGUI totalAmount;

    // �ǸŹ�ư ����ġ��
    public int[] sellItemes;
    int i;

    // �̹��� off
    public GameObject[] imageOff;
    public Button backBtn;

    // ���ڸ� ����Ϸ��� ���� ���� ( �ǸŰ���, �� �ݾ� )
    ulong price;
    ulong itemCount;
    ulong total;

    // �����̴� �ʱ�ȭ �ϱ� ���ؼ� 
    public GameObject sellPanel;

    void Start()
    {
        sellBtn.onClick.AddListener(SellItem);
        backBtn.onClick.AddListener(ImageOff);
    }

    // Update is called once per frame
    void Update()
    {
        // ȭ�� ������, �����̴� �ʱ�ȭ
        if(sellPanel.activeSelf == false)
        {
            countSlider.value = 0f;
        }
    }

    // �Ǹ� ��ư
    void SellItem()
    {
        switch (sellItemes[i])
        {
            case 0:
                Goods.gm.money += total;
                Goods.gm.gimbab.count -= (uint)itemCount;
                break;
            case 1:
                Goods.gm.money += total;
                Goods.gm.lamen.count -= (uint)itemCount;
                break;
            case 2:
                Goods.gm.money += total;
                Goods.gm.cola.count -= (uint)itemCount;
                break;
            case 3:
                Goods.gm.money += total;
                Goods.gm.vegetable.count -= (uint)itemCount;
                break;
            case 4:
                Goods.gm.money += total;
                Goods.gm.fish.count -= (uint)itemCount;
                break;
            case 5:
                Goods.gm.money += total;
                Goods.gm.meat.count -= (uint)itemCount;
                break;
            case 6:
                Goods.gm.money += total;
                Goods.gm.coin.count -= (uint)itemCount;
                break;
            case 7:
                Goods.gm.money += total;
                Goods.gm.cash.count -= (uint)itemCount;
                break;
            case 8:
                Goods.gm.money += total;
                Goods.gm.mouse.count -= (uint)itemCount;
                break;
            case 9:
                Goods.gm.money += total;
                Goods.gm.headset.count -= (uint)itemCount;
                break;
            case 10:
                Goods.gm.money += total;
                Goods.gm.nintendo.count -= (uint)itemCount;
                break;
            case 11:
                Goods.gm.money += total;
                Goods.gm.graphicCard.count -= (uint)itemCount;
                break;
            case 12:
                Goods.gm.money += total;
                Goods.gm.ring.count -= (uint)itemCount;
                break;
            case 13:
                Goods.gm.money += total;
                Goods.gm.pearl.count -= (uint)itemCount;
                break;
            case 14:
                Goods.gm.money += total;
                Goods.gm.ruby.count -= (uint)itemCount;
                break;
            case 15:
                Goods.gm.money += total;
                Goods.gm.diamond.count -= (uint)itemCount;
                break;
            case 16:
                Goods.gm.money += total;
                Goods.gm.goldbar.count -= (uint)itemCount;
                break;
            default:
                Goods.gm.money += total;
                Goods.gm.bitcoin.count -= (uint)itemCount;
                break;
        }

        // �̹��� ����
        for (int i = 0;i < imageOff.Length; i++)
        {
            imageOff[i].SetActive(false);
        }
        // ȭ�� ����
        sellPanel.SetActive(false);
    }

    // ��ư �������� ������ �Ǹ� UI
    public void GimbabAmount()
    {
        i = 0;
       
        totalItemCount.text = "�� ���� : " + Goods.gm.gimbab.count;

        //                      �ǸŰ���                     ���׷��̵�
        priceTxt.text = (Goods.gm.gimbab.price + Goods.gm.gimbab.price * Goods.gm.manipulation.value).ToString("N0");
        price = (ulong)(Goods.gm.gimbab.price + Goods.gm.gimbab.price * Goods.gm.manipulation.value);

        countSlider.onValueChanged.AddListener(SliderGimbab);
    }

    public void RamenAmount()
    {
        i = 1;
        totalItemCount.text = "�� ���� : " + Goods.gm.lamen.count;

        //                      �ǸŰ���                     ���׷��̵�
        priceTxt.text = (Goods.gm.lamen.price + Goods.gm.lamen.price * Goods.gm.manipulation.value).ToString("N0");
        price = (ulong)(Goods.gm.lamen.price + Goods.gm.lamen.price * Goods.gm.manipulation.value);

        countSlider.onValueChanged.AddListener(SliderRamen);
    }

    public void ColaAmount()
    {
        i = 2;
        totalItemCount.text = "�� ���� : " + Goods.gm.cola.count;

        //                      �ǸŰ���                     ���׷��̵�
        priceTxt.text = (Goods.gm.cola.price + Goods.gm.cola.price * Goods.gm.manipulation.value).ToString("N0");
        price = (ulong)(Goods.gm.cola.price + Goods.gm.cola.price * Goods.gm.manipulation.value);

        countSlider.onValueChanged.AddListener(SliderCola);
    }

    public void VegetableAmount()
    {
        i = 3;
        totalItemCount.text = "�� ���� : " + Goods.gm.vegetable.count;

        //                      �ǸŰ���                     ���׷��̵�
        priceTxt.text = (Goods.gm.vegetable.price + Goods.gm.vegetable.price * Goods.gm.manipulation.value).ToString("N0");
        price = (ulong)(Goods.gm.vegetable.price + Goods.gm.vegetable.price * Goods.gm.manipulation.value);

        countSlider.onValueChanged.AddListener(SliderVegetable);
    }

    public void FishAmount()
    {
        i = 4;
        totalItemCount.text = "�� ���� : " + Goods.gm.fish.count;

        //                      �ǸŰ���                     ���׷��̵�
        priceTxt.text = (Goods.gm.fish.price + Goods.gm.fish.price * Goods.gm.manipulation.value).ToString("N0");
        price = (ulong)(Goods.gm.fish.price + Goods.gm.fish.price * Goods.gm.manipulation.value);

        countSlider.onValueChanged.AddListener(SliderFish);
    }
    public void MeetAmount()
    {
        i = 5;
        totalItemCount.text = "�� ���� : " + Goods.gm.meat.count;

        //                      �ǸŰ���                     ���׷��̵�
        priceTxt.text = (Goods.gm.meat.price + Goods.gm.meat.price * Goods.gm.manipulation.value).ToString("N0");
        price = (ulong)(Goods.gm.meat.price + Goods.gm.meat.price * Goods.gm.manipulation.value);

        countSlider.onValueChanged.AddListener(SliderMeet);
    }

    public void CoinAmount()
    {
        i = 6;
        totalItemCount.text = "�� ���� : " + Goods.gm.coin.count;

        //                      �ǸŰ���                     ���׷��̵�
        priceTxt.text = (Goods.gm.coin.price + Goods.gm.coin.price * Goods.gm.manipulation.value).ToString("N0");
        price = (ulong)(Goods.gm.coin.price + Goods.gm.coin.price * Goods.gm.manipulation.value);

        countSlider.onValueChanged.AddListener(SliderCoin);
    }

    public void CashAmount()
    {
        i = 7;
        totalItemCount.text = "�� ���� : " + Goods.gm.cash.count;

        //                      �ǸŰ���                     ���׷��̵�
        priceTxt.text = (Goods.gm.cash.price + Goods.gm.cash.price * Goods.gm.manipulation.value).ToString("N0");
        price = (ulong)(Goods.gm.cash.price + Goods.gm.cash.price * Goods.gm.manipulation.value);

        countSlider.onValueChanged.AddListener(SliderCash);
    }

    public void MouseAmount()
    {
        i = 8;
        totalItemCount.text = "�� ���� : " + Goods.gm.mouse.count;

        //                      �ǸŰ���                     ���׷��̵�
        priceTxt.text = (Goods.gm.mouse.price + Goods.gm.mouse.price * Goods.gm.manipulation.value).ToString("N0");
        price = (ulong)(Goods.gm.mouse.price + Goods.gm.mouse.price * Goods.gm.manipulation.value);

        countSlider.onValueChanged.AddListener(SliderMouse);
    }

    public void HeadsetAmount()
    {
        i = 9;
        totalItemCount.text = "�� ���� : " + Goods.gm.headset.count;

        //                      �ǸŰ���                     ���׷��̵�
        priceTxt.text = (Goods.gm.headset.price + Goods.gm.headset.price * Goods.gm.manipulation.value).ToString("N0");
        price = (ulong)(Goods.gm.headset.price + Goods.gm.headset.price * Goods.gm.manipulation.value);

        countSlider.onValueChanged.AddListener(SliderHeadset);
    }

    public void NintendoAmount()
    {
        i = 10;
        totalItemCount.text = "�� ���� : " + Goods.gm.nintendo.count;

        //                      �ǸŰ���                     ���׷��̵�
        priceTxt.text = (Goods.gm.nintendo.price + Goods.gm.nintendo.price * Goods.gm.manipulation.value).ToString("N0");
        price = (ulong)(Goods.gm.nintendo.price + Goods.gm.nintendo.price * Goods.gm.manipulation.value);

        countSlider.onValueChanged.AddListener(SliderNintendo);
    }

    public void GraphicAmount()
    {
        i = 11;
        totalItemCount.text = "�� ���� : " + Goods.gm.graphicCard.count;

        //                      �ǸŰ���                     ���׷��̵�
        priceTxt.text = (Goods.gm.graphicCard.price + Goods.gm.graphicCard.price * Goods.gm.manipulation.value).ToString("N0");
        price = (ulong)(Goods.gm.graphicCard.price + Goods.gm.graphicCard.price * Goods.gm.manipulation.value);

        countSlider.onValueChanged.AddListener(SliderGraphic);
    }

    public void RingAmount()
    {
        i = 12;
        totalItemCount.text = "�� ���� : " + Goods.gm.ring.count;

        //                      �ǸŰ���                     ���׷��̵�
        priceTxt.text = (Goods.gm.ring.price + Goods.gm.ring.price * Goods.gm.manipulation.value).ToString("N0");
        price = (ulong)(Goods.gm.ring.price + Goods.gm.ring.price * Goods.gm.manipulation.value);

        countSlider.onValueChanged.AddListener(SliderRing);
    }

    public void PearlAmount()
    {
        i = 13;
        totalItemCount.text = "�� ���� : " + Goods.gm.pearl.count;

        //                      �ǸŰ���                     ���׷��̵�
        priceTxt.text = (Goods.gm.pearl.price + Goods.gm.pearl.price * Goods.gm.manipulation.value).ToString("N0");
        price = (ulong)(Goods.gm.pearl.price + Goods.gm.pearl.price * Goods.gm.manipulation.value);

        countSlider.onValueChanged.AddListener(SliderPearl);
    }

    public void RubyAmount()
    {
        i = 14;
        totalItemCount.text = "�� ���� : " + Goods.gm.ruby.count;

        //                      �ǸŰ���                     ���׷��̵�
        priceTxt.text = (Goods.gm.ruby.price + Goods.gm.ruby.price * Goods.gm.manipulation.value).ToString("N0");
        price = (ulong)(Goods.gm.ruby.price + Goods.gm.ruby.price * Goods.gm.manipulation.value);

        countSlider.onValueChanged.AddListener(SliderRuby);
    }

    public void DiaAmount()
    {
        i = 15;
        totalItemCount.text = "�� ���� : " + Goods.gm.diamond.count;

        //                      �ǸŰ���                     ���׷��̵�
        priceTxt.text = (Goods.gm.diamond.price + Goods.gm.diamond.price * Goods.gm.manipulation.value).ToString("N0");
        price = (ulong)(Goods.gm.diamond.price + Goods.gm.diamond.price * Goods.gm.manipulation.value);

        countSlider.onValueChanged.AddListener(SliderDiamond);
    }

    public void GoldbarAmount()
    {
        i = 16;
        totalItemCount.text = "�� ���� : " + Goods.gm.goldbar.count;

        //                      �ǸŰ���                     ���׷��̵�
        priceTxt.text = (Goods.gm.goldbar.price + Goods.gm.goldbar.price * Goods.gm.manipulation.value).ToString("N0");
        price = (ulong)(Goods.gm.goldbar.price + Goods.gm.goldbar.price * Goods.gm.manipulation.value);

        countSlider.onValueChanged.AddListener(SliderGold);
    }

    public void BitcoinAmount()
    {
        i = 17;
        totalItemCount.text = "�� ���� : " + Goods.gm.bitcoin.count;

        //                      �ǸŰ���                     ���׷��̵�
        priceTxt.text = (Goods.gm.bitcoin.price + Goods.gm.bitcoin.price * Goods.gm.manipulation.value).ToString("N0");
        price = (ulong)(Goods.gm.bitcoin.price + Goods.gm.bitcoin.price * Goods.gm.manipulation.value);

        countSlider.onValueChanged.AddListener(SliderBit);
    }

    // -------- �����̴� -----------
    void SliderGimbab(float val)
    {
        val = Goods.gm.gimbab.count;

        itemCountTxt.text =  Mathf.RoundToInt(val * countSlider.value).ToString("N0");
        itemCount = (ulong)Mathf.RoundToInt(val * countSlider.value);

        totalAmount.text = (price * itemCount).ToString("N0");
        total = price * itemCount;
    }

    void SliderRamen(float val)
    {
        val = Goods.gm.lamen.count;

        itemCountTxt.text = Mathf.RoundToInt(val * countSlider.value).ToString("N0");
        itemCount = (ulong)Mathf.RoundToInt(val * countSlider.value);

        totalAmount.text = (price * itemCount).ToString("N0");
        total = price * itemCount;
    }

    void SliderCola(float val)
    {
        val = Goods.gm.cola.count;

        itemCountTxt.text = Mathf.RoundToInt(val * countSlider.value).ToString("N0");
        itemCount = (ulong)Mathf.RoundToInt(val * countSlider.value);

        totalAmount.text = (price * itemCount).ToString("N0");
        total = price * itemCount;
    }

    void SliderVegetable(float val)
    {
        val = Goods.gm.vegetable.count;

        itemCountTxt.text = Mathf.RoundToInt(val * countSlider.value).ToString("N0");
        itemCount = (ulong)Mathf.RoundToInt(val * countSlider.value);

        totalAmount.text = (price * itemCount).ToString("N0");
        total = price * itemCount;
    }

    void SliderFish(float val)
    {
        val = Goods.gm.fish.count;

        itemCountTxt.text = Mathf.RoundToInt(val * countSlider.value).ToString("N0");
        itemCount = (ulong)Mathf.RoundToInt(val * countSlider.value);

        totalAmount.text = (price * itemCount).ToString("N0");
        total = price * itemCount;
    }

    void SliderMeet(float val)
    {
        val = Goods.gm.meat.count;

        itemCountTxt.text = Mathf.RoundToInt(val * countSlider.value).ToString("N0");
        itemCount = (ulong)Mathf.RoundToInt(val * countSlider.value);

        totalAmount.text = (price * itemCount).ToString("N0");
        total = price * itemCount;
    }

    void SliderCoin(float val)
    {
        val = Goods.gm.coin.count;

        itemCountTxt.text = Mathf.RoundToInt(val * countSlider.value).ToString("N0");
        itemCount = (ulong)Mathf.RoundToInt(val * countSlider.value);

        totalAmount.text = (price * itemCount).ToString("N0");
        total = price * itemCount;
    }

    void SliderCash(float val)
    {
        val = Goods.gm.cash.count;

        itemCountTxt.text = Mathf.RoundToInt(val * countSlider.value).ToString("N0");
        itemCount = (ulong)Mathf.RoundToInt(val * countSlider.value);

        totalAmount.text = (price * itemCount).ToString("N0");
        total = price * itemCount;
    }

    void SliderMouse(float val)
    {
        val = Goods.gm.mouse.count;

        itemCountTxt.text = Mathf.RoundToInt(val * countSlider.value).ToString("N0");
        itemCount = (ulong)Mathf.RoundToInt(val * countSlider.value);

        totalAmount.text = (price * itemCount).ToString("N0");
        total = price * itemCount;
    }

    void SliderHeadset(float val)
    {
        val = Goods.gm.headset.count;

        itemCountTxt.text = Mathf.RoundToInt(val * countSlider.value).ToString("N0");
        itemCount = (ulong)Mathf.RoundToInt(val * countSlider.value);

        totalAmount.text = (price * itemCount).ToString("N0");
        total = price * itemCount;
    }

    void SliderNintendo(float val)
    {
        val = Goods.gm.nintendo.count;

        itemCountTxt.text = Mathf.RoundToInt(val * countSlider.value).ToString("N0");
        itemCount = (ulong)Mathf.RoundToInt(val * countSlider.value);

        totalAmount.text = (price * itemCount).ToString("N0");
        total = price * itemCount;
    }

    void SliderGraphic(float val)
    {
        val = Goods.gm.graphicCard.count;

        itemCountTxt.text = Mathf.RoundToInt(val * countSlider.value).ToString("N0");
        itemCount = (ulong)Mathf.RoundToInt(val * countSlider.value);

        totalAmount.text = (price * itemCount).ToString("N0");
        total = price * itemCount;
    }

    void SliderRing(float val)
    {
        val = Goods.gm.ring.count;

        itemCountTxt.text = Mathf.RoundToInt(val * countSlider.value).ToString("N0");
        itemCount = (ulong)Mathf.RoundToInt(val * countSlider.value);

        totalAmount.text = (price * itemCount).ToString("N0");
        total = price * itemCount;
    }

    void SliderPearl(float val)
    {
        val = Goods.gm.pearl.count;

        itemCountTxt.text = Mathf.RoundToInt(val * countSlider.value).ToString("N0");
        itemCount = (ulong)Mathf.RoundToInt(val * countSlider.value);

        totalAmount.text = (price * itemCount).ToString("N0");
        total = price * itemCount;
    }

    void SliderRuby(float val)
    {
        val = Goods.gm.ruby.count;

        itemCountTxt.text = Mathf.RoundToInt(val * countSlider.value).ToString("N0");
        itemCount = (ulong)Mathf.RoundToInt(val * countSlider.value);

        totalAmount.text = (price * itemCount).ToString("N0");
        total = price * itemCount;
    }

    void SliderDiamond(float val)
    {
        val = Goods.gm.diamond.count;

        itemCountTxt.text = Mathf.RoundToInt(val * countSlider.value).ToString("N0");
        itemCount = (ulong)Mathf.RoundToInt(val * countSlider.value);

        totalAmount.text = (price * itemCount).ToString("N0");
        total = price * itemCount;
    }

    void SliderGold(float val)
    {
        val = Goods.gm.goldbar.count;

        itemCountTxt.text = Mathf.RoundToInt(val * countSlider.value).ToString("N0");
        itemCount = (ulong)Mathf.RoundToInt(val * countSlider.value);

        totalAmount.text = (price * itemCount).ToString("N0");
        total = price * itemCount;
    }

    void SliderBit(float val)
    {
        val = Goods.gm.bitcoin.count;

        itemCountTxt.text = Mathf.RoundToInt(val * countSlider.value).ToString("N0");
        itemCount = (ulong)Mathf.RoundToInt(val * countSlider.value);

        totalAmount.text = (price * itemCount).ToString("N0");
        total = price * itemCount;
    }

    // �̹��� Off
    void ImageOff()
    {
        for (int i = 0; i < imageOff.Length; i++)
        {
            imageOff[i].SetActive(false);
        }
    }
}
