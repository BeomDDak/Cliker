using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Main_UI")]
    public TextMeshProUGUI moneyTxt;
    public TextMeshProUGUI characterLevelTxt;
    public Slider expSlider;
    public string[] lvName; // 레벨별 이름
    public int[] lv; // 레벨

    [Header("Upgrade_UI")]
    public TextMeshProUGUI levelJudgmentTxt;
    public TextMeshProUGUI priceJugmentTxt;
    public TextMeshProUGUI levelQuickfeetTxt;
    public TextMeshProUGUI priceQuickfeetTxt;
    public TextMeshProUGUI levelBiggerbagTxt;
    public TextMeshProUGUI priceBiggerbagTxt;
    public TextMeshProUGUI levelBribeTxt;
    public TextMeshProUGUI priceBribeTxt;
    public TextMeshProUGUI levelManipulationTxt;
    public TextMeshProUGUI priceManipulationTxt;

    [Header("Employee_Upgrade_UI")]
    public TextMeshProUGUI levelAgileTxt;
    public TextMeshProUGUI priceAgileTxt;
    public TextMeshProUGUI levelSolidarityTxt;
    public TextMeshProUGUI priceSolidarityTxt;

    [Header("Item_UI")]
    //public TextMeshProUGUI gimbabPriceTxt;
    public TextMeshProUGUI gimbabCountTxt;
    //public TextMeshProUGUI lamenPriceTxt;
    public TextMeshProUGUI lamenCountTxt;
    //public TextMeshProUGUI colaPriceTxt;
    public TextMeshProUGUI colaCountTxt;
    //public TextMeshProUGUI vegetablePriceTxt;
    public TextMeshProUGUI vegetableCountTxt;
    //public TextMeshProUGUI fishPriceTxt;
    public TextMeshProUGUI fishCountTxt;
    //public TextMeshProUGUI meetPriceTxt;
    public TextMeshProUGUI meetCountTxt;
    //public TextMeshProUGUI coinPriceTxt;
    public TextMeshProUGUI coinCountTxt;
    //public TextMeshProUGUI cashPriceTxt;
    public TextMeshProUGUI cashCountTxt;
    //public TextMeshProUGUI mousePriceTxt;
    public TextMeshProUGUI mouseCountTxt;
    //public TextMeshProUGUI headsetPriceTxt;
    public TextMeshProUGUI headsetCountTxt;
    //public TextMeshProUGUI nintendoPriceTxt;
    public TextMeshProUGUI nintendoCountTxt;
    //public TextMeshProUGUI graphicCardPriceTxt;
    public TextMeshProUGUI graphicCardCountTxt;
    //public TextMeshProUGUI ringPriceTxt;
    public TextMeshProUGUI ringCountTxt;
    //public TextMeshProUGUI pearlPriceTxt;
    public TextMeshProUGUI pearlCountTxt;
    //public TextMeshProUGUI rubyPriceTxt;
    public TextMeshProUGUI rubyCountTxt;
    //public TextMeshProUGUI diamondPriceTxt;
    public TextMeshProUGUI diamondCountTxt;
    //public TextMeshProUGUI goldbarPriceTxt;
    public TextMeshProUGUI goldbarCountTxt;
    //public TextMeshProUGUI bitcoinPriceTxt;
    public TextMeshProUGUI bitcoinCountTxt;


    void Start()
    {
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        // 돈 UI

        if (Goods.gm.money <= 0)
        {
            moneyTxt.text = "0 원";
        }
        else
        {
            moneyTxt.text = Goods.gm.money.ToString("###,###") + " 원";
        }

        // 업글 UI

        levelJudgmentTxt.text = "Lv. " + Goods.gm.judgment.level.ToString();
        priceJugmentTxt.text = Goods.gm.judgment.price.ToString("###,###") + "원";

        levelQuickfeetTxt.text = "Lv. " + Goods.gm.quickfeet.level.ToString();
        priceQuickfeetTxt.text = Goods.gm.quickfeet.price.ToString("###,###") + "원";

        levelBiggerbagTxt.text = "Lv. " + Goods.gm.biggerbag.level.ToString();
        priceBiggerbagTxt.text = Goods.gm.biggerbag.price.ToString("###,###") + "원";

        levelBribeTxt.text = "Lv. " + Goods.gm.bribe.level.ToString();
        priceBribeTxt.text = Goods.gm.bribe.price.ToString("###,###") + "원";

        levelManipulationTxt.text = "Lv. " + Goods.gm.manipulation.level.ToString();
        priceManipulationTxt.text = Goods.gm.manipulation.price.ToString("###,###") + "원";

        // 부하 업글 UI     => 추후 업데이트 예정

        levelAgileTxt.text = "Lv. " + Goods.gm.agile.level.ToString();
        priceAgileTxt.text = Goods.gm.agile.price.ToString("###,###") + "원";

        levelSolidarityTxt.text = "Lv. " + Goods.gm.solidarity.level.ToString();
        priceSolidarityTxt.text = Goods.gm.solidarity.price.ToString("###,###") + "원";

        // 아이템 UI

        //gimbabPriceTxt.text = Goods.gm.gimbabPrice.ToString("###,###") + "원";
        gimbabCountTxt.text = Goods.gm.gimbab.count.ToString() + "개";

        //lamenPriceTxt.text = Goods.gm.lamenPrice.ToString("###,###") + "원";
        lamenCountTxt.text = Goods.gm.lamen.count.ToString() + "개";

        //colaPriceTxt.text = Goods.gm.colaPrice.ToString("###,###") + "원";
        colaCountTxt.text = Goods.gm.cola.count.ToString() + "개";

        //vegetablePriceTxt.text = Goods.gm.vegetablePrice.ToString("###,###") + "원";
        vegetableCountTxt.text = Goods.gm.vegetable.count.ToString() + "개";

        //fishPriceTxt.text = Goods.gm.fishPrice.ToString("###,###") + "원";
        fishCountTxt.text = Goods.gm.fish.count.ToString() + "개";

        //meetPriceTxt.text = Goods.gm.meetPrice.ToString("###,###") + "원";
        meetCountTxt.text = Goods.gm.meat.count.ToString() + "개";

        //coinPriceTxt.text = Goods.gm.coinPrice.ToString("###,###") + "원";
        coinCountTxt.text = Goods.gm.coin.count.ToString() + "개";

        //cashPriceTxt.text = Goods.gm.cashPrice.ToString("###,###") + "원";
        cashCountTxt.text = Goods.gm.cash.count.ToString() + "개";

        //mousePriceTxt.text = Goods.gm.mousePrice.ToString("###,###") + "원";
        mouseCountTxt.text = Goods.gm.mouse.count.ToString() + "개";

        //headsetPriceTxt.text = Goods.gm.headsetPrice.ToString("###,###") + "원";
        headsetCountTxt.text = Goods.gm.headset.count.ToString() + "개";

        //nintendoPriceTxt.text = Goods.gm.nintendoPrice.ToString("###,###") + "원";
        nintendoCountTxt.text = Goods.gm.nintendo.count.ToString() + "개";

        //graphicCardPriceTxt.text = Goods.gm.graphicCardPrice.ToString("###,###") + "원";
        graphicCardCountTxt.text = Goods.gm.graphicCard.count.ToString() + "개";

        //ringPriceTxt.text = Goods.gm.ringPrice.ToString("###,###") + "원";
        ringCountTxt.text = Goods.gm.ring.count.ToString() + "개";

        //pearlPriceTxt.text = Goods.gm.pearlPrice.ToString("###,###") + "원";
        pearlCountTxt.text = Goods.gm.pearl.count.ToString() + "개";

        //rubyPriceTxt.text = Goods.gm.rubyPrice.ToString("###,###") + "원";
        rubyCountTxt.text = Goods.gm.ruby.count.ToString() + "개";

        //diamondPriceTxt.text = Goods.gm.diamondPrice.ToString("###,###") + "원";
        diamondCountTxt.text = Goods.gm.diamond.count.ToString() + "개";

        //goldbarPriceTxt.text = Goods.gm.goldbarPrice.ToString("###,###") + "원";
        goldbarCountTxt.text = Goods.gm.goldbar.count.ToString() + "개";

        //bitcoinPriceTxt.text = Goods.gm.bitcoinPrice.ToString("###,###") + "원";
        bitcoinCountTxt.text = Goods.gm.bitcoin.count.ToString() + "개";

        // 경험치 UI

        // 경험치가 최대 경험치를 넘을 때
        if(Goods.gm.level_Index >= 9)
        {
            Goods.gm.level_Index = 9;
            expSlider.maxValue = 1;
            expSlider.value = 0;
        }
        else
        {
            if (Goods.gm.characterLevel >= Goods.gm.characterMaxExp)
            {
                LevelUp(); // 레벨 업 함수 호출
            }
            else
            {
                UpdateUI();
            }
        }
    }

    void LevelUp()
    {
        Goods.gm.level_Index++; // 레벨 및 호칭 배열 인덱스 증가
        Goods.gm.characterLevel = 0; // 경험치 초기화
        Goods.gm.characterMaxExp += (Goods.gm.level_Index * 1.2f); // 최대 경험치 증가

        UpdateUI();
    }

    void UpdateUI()
    {
        expSlider.maxValue = Goods.gm.characterMaxExp;
        expSlider.value = Goods.gm.characterLevel;
        characterLevelTxt.text = "Lv. " + lv[Goods.gm.level_Index].ToString() +" "+lvName[Goods.gm.level_Index];
    }
}
