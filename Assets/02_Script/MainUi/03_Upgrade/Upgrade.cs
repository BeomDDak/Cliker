using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Upgrade : MonoBehaviour
{
    public Button upgrade_Judgment_Btn;
    public Button upgrade_Quickfeet_Btn;
    public Button upgrade_Biggerbag_Btn;
    public Button upgrade_Bribe_Btn;
    public Button upgrade_Manipulation_Btn;

    void Start()
    {
        // 업그레이드 버튼 눌렀을때
        upgrade_Judgment_Btn.onClick.AddListener(UpgradeJudgment);
        upgrade_Quickfeet_Btn.onClick.AddListener(UpgradeQuickfeet);
        upgrade_Biggerbag_Btn.onClick.AddListener(UpgradeBiggerbag);
        upgrade_Bribe_Btn.onClick.AddListener(UpgradeBribe);
        upgrade_Manipulation_Btn.onClick.AddListener(UpgradeManpulation);
    }


    void Update()
    {
        // 업그레이드 버튼 활성화, 비활성화

        if(Goods.gm.money < Goods.gm.judgment.price)
        {
            upgrade_Judgment_Btn.interactable = false;
        }
        else
        {
            if(Goods.gm.judgment.level >= 10)
            {
                upgrade_Judgment_Btn.interactable = false;
            }
            else
            {
                upgrade_Judgment_Btn.interactable = true;
            }
        }


        if(Goods.gm.money < Goods.gm.quickfeet.price)
        {
            upgrade_Quickfeet_Btn.interactable = false;
        }
        else
        {
            if (Goods.gm.judgment.level >= 10)
            {
                upgrade_Judgment_Btn.interactable = false;
            }
            else
            {
                upgrade_Quickfeet_Btn.interactable = true;
            }
        }


        if (Goods.gm.money < Goods.gm.biggerbag.price)
        {
            upgrade_Biggerbag_Btn.interactable = false;
        }
        else
        {
            if (Goods.gm.biggerbag.level >= 10)
            {
                upgrade_Judgment_Btn.interactable = false;
            }
            else
            {
                upgrade_Biggerbag_Btn.interactable = true;
            }
        }

        if(Goods.gm.money < Goods.gm.bribe.price)
        {
            upgrade_Bribe_Btn.interactable = false;
        }
        else
        {
            if (Goods.gm.bribe.level >= 10)
            {
                upgrade_Judgment_Btn.interactable = false;
            }
            else
            {
                upgrade_Bribe_Btn.interactable = true;
            }
        }

        if (Goods.gm.money < Goods.gm.manipulation.price)
        {
            upgrade_Manipulation_Btn.interactable = false;
        }
        else
        {
            if (Goods.gm.manipulation.level >= 10)
            {
                upgrade_Judgment_Btn.interactable = false;
            }
            else
            {
                upgrade_Manipulation_Btn.interactable = true;
            }
        }

    }

    // 업그레이드 함수
    void UpgradeJudgment()
    {
        Goods.gm.money -= Goods.gm.judgment.price;
        Goods.gm.judgment.level ++;
        Goods.gm.judgment.value += 15 * Goods.gm.judgment.level;
        Goods.gm.judgment.price += 1000 * (uint)Goods.gm.judgment.level;
    }

    void UpgradeQuickfeet()
    {
        Goods.gm.money -= Goods.gm.quickfeet.price;
        Goods.gm.quickfeet.level ++;
        Goods.gm.quickfeet.value += 3f * Goods.gm.quickfeet.level;
        Goods.gm.quickfeet.price += 1500 * (uint)Goods.gm.quickfeet.level;
    }

    void UpgradeBiggerbag()
    {
        Goods.gm.money -= Goods.gm.biggerbag.price;
        Goods.gm.biggerbag.level++;
        Goods.gm.biggerbag.value += 10 * Goods.gm.biggerbag.level;
        Goods.gm.biggerbag.price += 3000 * (uint)Goods.gm.biggerbag.level;
    }

    void UpgradeBribe()
    {
        Goods.gm.money -= Goods.gm.bribe.price;
        Goods.gm.bribe.level++;
        Goods.gm.bribe.value += 10 * Goods.gm.bribe.level;
        Goods.gm.bribe.price += 6000 * (uint)Goods.gm.bribe.level;
    }

    void UpgradeManpulation()
    {
        Goods.gm.money -= Goods.gm.manipulation.price;
        Goods.gm.manipulation.level++;
        Goods.gm.manipulation.value += 0.1f * Goods.gm.manipulation.level;
        Goods.gm.manipulation.price += 10000 * (uint)Goods.gm.manipulation.level;
    }
}
