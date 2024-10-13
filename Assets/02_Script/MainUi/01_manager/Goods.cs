using UnityEngine;
using System.Xml.Serialization;
using System.IO;

public class Goods : MonoBehaviour
{
    public static Goods gm;

    private void Awake()
    {
        if (gm == null)
        {
            gm = this;
            DontDestroyOnLoad(gm);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // 돈,레벨,무게, 시간
    public ulong money;
    public float characterLevel;
    public float characterMaxExp;
    public int level_Index;
    public int bagWeight;
    public int waitingTime;

    // 업그레이드 -> 레벨,올려주는 수치,업글 가격
    [Header("Upgrade")]

    public UpgradeData judgment;
    public UpgradeData quickfeet;
    public UpgradeData biggerbag;
    public UpgradeData bribe;
    public UpgradeData manipulation;

    // 부하 업그레이드  -> 추후 업데이트 예정
    [Header("Employee_Upgrade")]

    public UpgradeData agile;
    public UpgradeData solidarity;

    // 아이템 -> 가격, 수량, 
    [Header("Item")]

    public ItemData gimbab;
    public ItemData lamen;
    public ItemData cola;
    public ItemData vegetable;
    public ItemData fish;
    public ItemData meat;
    public ItemData coin;
    public ItemData cash;
    public ItemData mouse;
    public ItemData headset;
    public ItemData nintendo;
    public ItemData graphicCard;
    public ItemData ring;
    public ItemData pearl;
    public ItemData ruby;
    public ItemData diamond;
    public ItemData goldbar;
    public ItemData bitcoin;

    private void Start()
    {
        LoadData();
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }

    public void SaveData()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(GoodsData));
        using (StreamWriter stream = new StreamWriter("data.xml"))
        {
            GoodsData data = new GoodsData();
            data.money = money;
            data.characterLevel = characterLevel;
            data.characterMaxExp = characterMaxExp;
            data.level_Index = level_Index;
            data.bagWeight = bagWeight;
            data.waitingTime = waitingTime;
            data.judgment = judgment;
            data.quickfeet = quickfeet;
            data.biggerbag = biggerbag;
            data.bribe = bribe;
            data.manipulation = manipulation;
            data.agile = agile;
            data.solidarity = solidarity;
            data.gimbab = gimbab;
            data.lamen = lamen;
            data.cola = cola;
            data.vegetable = vegetable;
            data.fish = fish;
            data.meat = meat;
            data.coin = coin;
            data.cash = cash;
            data.mouse = mouse;
            data.headset = headset;
            data.nintendo = nintendo;
            data.graphicCard = graphicCard;
            data.ring = ring;
            data.pearl = pearl;
            data.ruby = ruby;
            data.diamond = diamond;
            data.goldbar = goldbar;
            data.bitcoin = bitcoin;
            serializer.Serialize(stream, data);
        }
    }

    public void LoadData()
    {
        if (File.Exists("data.xml"))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(GoodsData));
            using (StreamReader stream = new StreamReader("data.xml"))
            {
                GoodsData data = (GoodsData)serializer.Deserialize(stream);
                money = data.money;
                characterLevel = data.characterLevel;
                characterMaxExp = data.characterMaxExp;
                level_Index = data.level_Index;
                bagWeight = data.bagWeight;
                waitingTime = data.waitingTime;
                judgment = data.judgment;
                quickfeet = data.quickfeet;
                biggerbag = data.biggerbag;
                bribe = data.bribe;
                manipulation = data.manipulation;
                agile = data.agile;
                solidarity = data.solidarity;
                gimbab = data.gimbab;
                lamen = data.lamen;
                cola = data.cola;
                vegetable = data.vegetable;
                fish = data.fish;
                meat = data.meat;
                coin = data.coin;
                cash = data.cash;
                mouse = data.mouse;
                headset = data.headset;
                nintendo = data.nintendo;
                graphicCard = data.graphicCard;
                ring = data.ring;
                pearl = data.pearl;
                ruby = data.ruby;
                diamond = data.diamond;
                goldbar = data.goldbar;
                bitcoin = data.bitcoin;
            }
        }
    }
}

[System.Serializable]
public class UpgradeData
{
    public int level;
    public float value;
    public uint price;
}

[System.Serializable]
public class ItemData
{
    public uint price;
    public uint count;
}

[System.Serializable]
public class GoodsData
{
    public ulong money;
    public float characterLevel;
    public float characterMaxExp;
    public int level_Index;
    public int bagWeight;
    public int waitingTime;
    public UpgradeData judgment;
    public UpgradeData quickfeet;
    public UpgradeData biggerbag;
    public UpgradeData bribe;
    public UpgradeData manipulation;
    public UpgradeData agile;
    public UpgradeData solidarity;
    public ItemData gimbab;
    public ItemData lamen;
    public ItemData cola;
    public ItemData vegetable;
    public ItemData fish;
    public ItemData meat;
    public ItemData coin;
    public ItemData cash;
    public ItemData mouse;
    public ItemData headset;
    public ItemData nintendo;
    public ItemData graphicCard;
    public ItemData ring;
    public ItemData pearl;
    public ItemData ruby;
    public ItemData diamond;
    public ItemData goldbar;
    public ItemData bitcoin;
}
