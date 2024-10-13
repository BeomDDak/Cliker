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
    public string[] lvName; // ������ �̸�
    public int[] lv; // ����

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
        // �� UI

        if (Goods.gm.money <= 0)
        {
            moneyTxt.text = "0 ��";
        }
        else
        {
            moneyTxt.text = Goods.gm.money.ToString("###,###") + " ��";
        }

        // ���� UI

        levelJudgmentTxt.text = "Lv. " + Goods.gm.judgment.level.ToString();
        priceJugmentTxt.text = Goods.gm.judgment.price.ToString("###,###") + "��";

        levelQuickfeetTxt.text = "Lv. " + Goods.gm.quickfeet.level.ToString();
        priceQuickfeetTxt.text = Goods.gm.quickfeet.price.ToString("###,###") + "��";

        levelBiggerbagTxt.text = "Lv. " + Goods.gm.biggerbag.level.ToString();
        priceBiggerbagTxt.text = Goods.gm.biggerbag.price.ToString("###,###") + "��";

        levelBribeTxt.text = "Lv. " + Goods.gm.bribe.level.ToString();
        priceBribeTxt.text = Goods.gm.bribe.price.ToString("###,###") + "��";

        levelManipulationTxt.text = "Lv. " + Goods.gm.manipulation.level.ToString();
        priceManipulationTxt.text = Goods.gm.manipulation.price.ToString("###,###") + "��";

        // ���� ���� UI     => ���� ������Ʈ ����

        levelAgileTxt.text = "Lv. " + Goods.gm.agile.level.ToString();
        priceAgileTxt.text = Goods.gm.agile.price.ToString("###,###") + "��";

        levelSolidarityTxt.text = "Lv. " + Goods.gm.solidarity.level.ToString();
        priceSolidarityTxt.text = Goods.gm.solidarity.price.ToString("###,###") + "��";

        // ������ UI

        //gimbabPriceTxt.text = Goods.gm.gimbabPrice.ToString("###,###") + "��";
        gimbabCountTxt.text = Goods.gm.gimbab.count.ToString() + "��";

        //lamenPriceTxt.text = Goods.gm.lamenPrice.ToString("###,###") + "��";
        lamenCountTxt.text = Goods.gm.lamen.count.ToString() + "��";

        //colaPriceTxt.text = Goods.gm.colaPrice.ToString("###,###") + "��";
        colaCountTxt.text = Goods.gm.cola.count.ToString() + "��";

        //vegetablePriceTxt.text = Goods.gm.vegetablePrice.ToString("###,###") + "��";
        vegetableCountTxt.text = Goods.gm.vegetable.count.ToString() + "��";

        //fishPriceTxt.text = Goods.gm.fishPrice.ToString("###,###") + "��";
        fishCountTxt.text = Goods.gm.fish.count.ToString() + "��";

        //meetPriceTxt.text = Goods.gm.meetPrice.ToString("###,###") + "��";
        meetCountTxt.text = Goods.gm.meat.count.ToString() + "��";

        //coinPriceTxt.text = Goods.gm.coinPrice.ToString("###,###") + "��";
        coinCountTxt.text = Goods.gm.coin.count.ToString() + "��";

        //cashPriceTxt.text = Goods.gm.cashPrice.ToString("###,###") + "��";
        cashCountTxt.text = Goods.gm.cash.count.ToString() + "��";

        //mousePriceTxt.text = Goods.gm.mousePrice.ToString("###,###") + "��";
        mouseCountTxt.text = Goods.gm.mouse.count.ToString() + "��";

        //headsetPriceTxt.text = Goods.gm.headsetPrice.ToString("###,###") + "��";
        headsetCountTxt.text = Goods.gm.headset.count.ToString() + "��";

        //nintendoPriceTxt.text = Goods.gm.nintendoPrice.ToString("###,###") + "��";
        nintendoCountTxt.text = Goods.gm.nintendo.count.ToString() + "��";

        //graphicCardPriceTxt.text = Goods.gm.graphicCardPrice.ToString("###,###") + "��";
        graphicCardCountTxt.text = Goods.gm.graphicCard.count.ToString() + "��";

        //ringPriceTxt.text = Goods.gm.ringPrice.ToString("###,###") + "��";
        ringCountTxt.text = Goods.gm.ring.count.ToString() + "��";

        //pearlPriceTxt.text = Goods.gm.pearlPrice.ToString("###,###") + "��";
        pearlCountTxt.text = Goods.gm.pearl.count.ToString() + "��";

        //rubyPriceTxt.text = Goods.gm.rubyPrice.ToString("###,###") + "��";
        rubyCountTxt.text = Goods.gm.ruby.count.ToString() + "��";

        //diamondPriceTxt.text = Goods.gm.diamondPrice.ToString("###,###") + "��";
        diamondCountTxt.text = Goods.gm.diamond.count.ToString() + "��";

        //goldbarPriceTxt.text = Goods.gm.goldbarPrice.ToString("###,###") + "��";
        goldbarCountTxt.text = Goods.gm.goldbar.count.ToString() + "��";

        //bitcoinPriceTxt.text = Goods.gm.bitcoinPrice.ToString("###,###") + "��";
        bitcoinCountTxt.text = Goods.gm.bitcoin.count.ToString() + "��";

        // ����ġ UI

        // ����ġ�� �ִ� ����ġ�� ���� ��
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
                LevelUp(); // ���� �� �Լ� ȣ��
            }
            else
            {
                UpdateUI();
            }
        }
    }

    void LevelUp()
    {
        Goods.gm.level_Index++; // ���� �� ȣĪ �迭 �ε��� ����
        Goods.gm.characterLevel = 0; // ����ġ �ʱ�ȭ
        Goods.gm.characterMaxExp += (Goods.gm.level_Index * 1.2f); // �ִ� ����ġ ����

        UpdateUI();
    }

    void UpdateUI()
    {
        expSlider.maxValue = Goods.gm.characterMaxExp;
        expSlider.value = Goods.gm.characterLevel;
        characterLevelTxt.text = "Lv. " + lv[Goods.gm.level_Index].ToString() +" "+lvName[Goods.gm.level_Index];
    }
}
