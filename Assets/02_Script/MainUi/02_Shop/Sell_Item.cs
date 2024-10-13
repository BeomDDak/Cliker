using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Sell_Item : MonoBehaviour
{
    // 연결은 버튼에 onClick으로 직접 해줬음

    // 판매 버튼, 물건가격, 수량, 수량 선택 슬라이드, 판매 할 총금액
    public Button sellBtn;
    public TextMeshProUGUI totalItemCount;
    public TextMeshProUGUI priceTxt;
    public TextMeshProUGUI itemCountTxt;
    public Slider countSlider;
    public TextMeshProUGUI totalAmount;

    // 판매버튼 스위치문
    public int[] sellItemes;
    int i;

    // 이미지 off
    public GameObject[] imageOff;
    public Button backBtn;

    // 숫자만 계산하려고 만든 변수 ( 판매가격, 총 금액 )
    ulong price;
    ulong itemCount;
    ulong total;

    // 슬라이더 초기화 하기 위해서 
    public GameObject sellPanel;

    void Start()
    {
        sellBtn.onClick.AddListener(SellItem);
        backBtn.onClick.AddListener(ImageOff);
    }

    // Update is called once per frame
    void Update()
    {
        // 화면 껐을때, 슬라이더 초기화
        if(sellPanel.activeSelf == false)
        {
            countSlider.value = 0f;
        }
    }

    // 판매 버튼
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

        // 이미지 오프
        for (int i = 0;i < imageOff.Length; i++)
        {
            imageOff[i].SetActive(false);
        }
        // 화면 끄기
        sellPanel.SetActive(false);
    }

    // 버튼 눌렀을때 나오는 판매 UI
    public void GimbabAmount()
    {
        i = 0;
       
        totalItemCount.text = "총 수량 : " + Goods.gm.gimbab.count;

        //                      판매가격                     업그레이드
        priceTxt.text = (Goods.gm.gimbab.price + Goods.gm.gimbab.price * Goods.gm.manipulation.value).ToString("N0");
        price = (ulong)(Goods.gm.gimbab.price + Goods.gm.gimbab.price * Goods.gm.manipulation.value);

        countSlider.onValueChanged.AddListener(SliderGimbab);
    }

    public void RamenAmount()
    {
        i = 1;
        totalItemCount.text = "총 수량 : " + Goods.gm.lamen.count;

        //                      판매가격                     업그레이드
        priceTxt.text = (Goods.gm.lamen.price + Goods.gm.lamen.price * Goods.gm.manipulation.value).ToString("N0");
        price = (ulong)(Goods.gm.lamen.price + Goods.gm.lamen.price * Goods.gm.manipulation.value);

        countSlider.onValueChanged.AddListener(SliderRamen);
    }

    public void ColaAmount()
    {
        i = 2;
        totalItemCount.text = "총 수량 : " + Goods.gm.cola.count;

        //                      판매가격                     업그레이드
        priceTxt.text = (Goods.gm.cola.price + Goods.gm.cola.price * Goods.gm.manipulation.value).ToString("N0");
        price = (ulong)(Goods.gm.cola.price + Goods.gm.cola.price * Goods.gm.manipulation.value);

        countSlider.onValueChanged.AddListener(SliderCola);
    }

    public void VegetableAmount()
    {
        i = 3;
        totalItemCount.text = "총 수량 : " + Goods.gm.vegetable.count;

        //                      판매가격                     업그레이드
        priceTxt.text = (Goods.gm.vegetable.price + Goods.gm.vegetable.price * Goods.gm.manipulation.value).ToString("N0");
        price = (ulong)(Goods.gm.vegetable.price + Goods.gm.vegetable.price * Goods.gm.manipulation.value);

        countSlider.onValueChanged.AddListener(SliderVegetable);
    }

    public void FishAmount()
    {
        i = 4;
        totalItemCount.text = "총 수량 : " + Goods.gm.fish.count;

        //                      판매가격                     업그레이드
        priceTxt.text = (Goods.gm.fish.price + Goods.gm.fish.price * Goods.gm.manipulation.value).ToString("N0");
        price = (ulong)(Goods.gm.fish.price + Goods.gm.fish.price * Goods.gm.manipulation.value);

        countSlider.onValueChanged.AddListener(SliderFish);
    }
    public void MeetAmount()
    {
        i = 5;
        totalItemCount.text = "총 수량 : " + Goods.gm.meat.count;

        //                      판매가격                     업그레이드
        priceTxt.text = (Goods.gm.meat.price + Goods.gm.meat.price * Goods.gm.manipulation.value).ToString("N0");
        price = (ulong)(Goods.gm.meat.price + Goods.gm.meat.price * Goods.gm.manipulation.value);

        countSlider.onValueChanged.AddListener(SliderMeet);
    }

    public void CoinAmount()
    {
        i = 6;
        totalItemCount.text = "총 수량 : " + Goods.gm.coin.count;

        //                      판매가격                     업그레이드
        priceTxt.text = (Goods.gm.coin.price + Goods.gm.coin.price * Goods.gm.manipulation.value).ToString("N0");
        price = (ulong)(Goods.gm.coin.price + Goods.gm.coin.price * Goods.gm.manipulation.value);

        countSlider.onValueChanged.AddListener(SliderCoin);
    }

    public void CashAmount()
    {
        i = 7;
        totalItemCount.text = "총 수량 : " + Goods.gm.cash.count;

        //                      판매가격                     업그레이드
        priceTxt.text = (Goods.gm.cash.price + Goods.gm.cash.price * Goods.gm.manipulation.value).ToString("N0");
        price = (ulong)(Goods.gm.cash.price + Goods.gm.cash.price * Goods.gm.manipulation.value);

        countSlider.onValueChanged.AddListener(SliderCash);
    }

    public void MouseAmount()
    {
        i = 8;
        totalItemCount.text = "총 수량 : " + Goods.gm.mouse.count;

        //                      판매가격                     업그레이드
        priceTxt.text = (Goods.gm.mouse.price + Goods.gm.mouse.price * Goods.gm.manipulation.value).ToString("N0");
        price = (ulong)(Goods.gm.mouse.price + Goods.gm.mouse.price * Goods.gm.manipulation.value);

        countSlider.onValueChanged.AddListener(SliderMouse);
    }

    public void HeadsetAmount()
    {
        i = 9;
        totalItemCount.text = "총 수량 : " + Goods.gm.headset.count;

        //                      판매가격                     업그레이드
        priceTxt.text = (Goods.gm.headset.price + Goods.gm.headset.price * Goods.gm.manipulation.value).ToString("N0");
        price = (ulong)(Goods.gm.headset.price + Goods.gm.headset.price * Goods.gm.manipulation.value);

        countSlider.onValueChanged.AddListener(SliderHeadset);
    }

    public void NintendoAmount()
    {
        i = 10;
        totalItemCount.text = "총 수량 : " + Goods.gm.nintendo.count;

        //                      판매가격                     업그레이드
        priceTxt.text = (Goods.gm.nintendo.price + Goods.gm.nintendo.price * Goods.gm.manipulation.value).ToString("N0");
        price = (ulong)(Goods.gm.nintendo.price + Goods.gm.nintendo.price * Goods.gm.manipulation.value);

        countSlider.onValueChanged.AddListener(SliderNintendo);
    }

    public void GraphicAmount()
    {
        i = 11;
        totalItemCount.text = "총 수량 : " + Goods.gm.graphicCard.count;

        //                      판매가격                     업그레이드
        priceTxt.text = (Goods.gm.graphicCard.price + Goods.gm.graphicCard.price * Goods.gm.manipulation.value).ToString("N0");
        price = (ulong)(Goods.gm.graphicCard.price + Goods.gm.graphicCard.price * Goods.gm.manipulation.value);

        countSlider.onValueChanged.AddListener(SliderGraphic);
    }

    public void RingAmount()
    {
        i = 12;
        totalItemCount.text = "총 수량 : " + Goods.gm.ring.count;

        //                      판매가격                     업그레이드
        priceTxt.text = (Goods.gm.ring.price + Goods.gm.ring.price * Goods.gm.manipulation.value).ToString("N0");
        price = (ulong)(Goods.gm.ring.price + Goods.gm.ring.price * Goods.gm.manipulation.value);

        countSlider.onValueChanged.AddListener(SliderRing);
    }

    public void PearlAmount()
    {
        i = 13;
        totalItemCount.text = "총 수량 : " + Goods.gm.pearl.count;

        //                      판매가격                     업그레이드
        priceTxt.text = (Goods.gm.pearl.price + Goods.gm.pearl.price * Goods.gm.manipulation.value).ToString("N0");
        price = (ulong)(Goods.gm.pearl.price + Goods.gm.pearl.price * Goods.gm.manipulation.value);

        countSlider.onValueChanged.AddListener(SliderPearl);
    }

    public void RubyAmount()
    {
        i = 14;
        totalItemCount.text = "총 수량 : " + Goods.gm.ruby.count;

        //                      판매가격                     업그레이드
        priceTxt.text = (Goods.gm.ruby.price + Goods.gm.ruby.price * Goods.gm.manipulation.value).ToString("N0");
        price = (ulong)(Goods.gm.ruby.price + Goods.gm.ruby.price * Goods.gm.manipulation.value);

        countSlider.onValueChanged.AddListener(SliderRuby);
    }

    public void DiaAmount()
    {
        i = 15;
        totalItemCount.text = "총 수량 : " + Goods.gm.diamond.count;

        //                      판매가격                     업그레이드
        priceTxt.text = (Goods.gm.diamond.price + Goods.gm.diamond.price * Goods.gm.manipulation.value).ToString("N0");
        price = (ulong)(Goods.gm.diamond.price + Goods.gm.diamond.price * Goods.gm.manipulation.value);

        countSlider.onValueChanged.AddListener(SliderDiamond);
    }

    public void GoldbarAmount()
    {
        i = 16;
        totalItemCount.text = "총 수량 : " + Goods.gm.goldbar.count;

        //                      판매가격                     업그레이드
        priceTxt.text = (Goods.gm.goldbar.price + Goods.gm.goldbar.price * Goods.gm.manipulation.value).ToString("N0");
        price = (ulong)(Goods.gm.goldbar.price + Goods.gm.goldbar.price * Goods.gm.manipulation.value);

        countSlider.onValueChanged.AddListener(SliderGold);
    }

    public void BitcoinAmount()
    {
        i = 17;
        totalItemCount.text = "총 수량 : " + Goods.gm.bitcoin.count;

        //                      판매가격                     업그레이드
        priceTxt.text = (Goods.gm.bitcoin.price + Goods.gm.bitcoin.price * Goods.gm.manipulation.value).ToString("N0");
        price = (ulong)(Goods.gm.bitcoin.price + Goods.gm.bitcoin.price * Goods.gm.manipulation.value);

        countSlider.onValueChanged.AddListener(SliderBit);
    }

    // -------- 슬라이더 -----------
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

    // 이미지 Off
    void ImageOff()
    {
        for (int i = 0; i < imageOff.Length; i++)
        {
            imageOff[i].SetActive(false);
        }
    }
}
