using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public bool testiranjeIGRE;
    public int criticalDamage;
    public float critialChance;
    public float timeTillEnd;
    public int score;
    public int money;
    Text scoreText;
    Text timeText;
    Text moneyText;
    GameObject baseTab;
    GameObject clickingUpTab;
    GameObject autoUpTab;
    GameObject specialUpTab;
    GameObject mainTab;
    RectTransform crystal;
    GameObject canvas;
    public GameObject clickedText;
    public int factorOfClick;
    PlayerUpgradesScript pupg;
    Level1PerSecond L1;
    Level2PerSecond L2;
    Level3PerSecond L3;
    bool highest;

    GameObject ScrollTab;
    Vector2 dragStart;
    float UpperScrollLimit;
    float LowerScrollLimit;
    public bool canScroll;

    public bool load;
    public int allowedTouchCount;

    

    void Awake()
    {
        //Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");
        //Input.multiTouchEnabled = false ;
    }

    void Start ()
    {
        initGame();        
        if (load) Load();
        if (!load) StartCoroutine(Timer());
        if (allowedTouchCount == 0) allowedTouchCount = 1;
    } 

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        timeTillEnd--;
        StartCoroutine(Timer());
    }

    void initGame()
    {
        mainTab = GameObject.FindGameObjectWithTag("MainTab");
        ScrollTab = GameObject.FindGameObjectWithTag("ScrollTab");
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        crystal = GameObject.FindGameObjectWithTag("Crystal").GetComponent<RectTransform>();
        scoreText = GameObject.FindGameObjectWithTag("scoreText").GetComponent<Text>();
        timeText = GameObject.FindGameObjectWithTag("timeText").GetComponent<Text>();
        moneyText = GameObject.FindGameObjectWithTag("moneyText").GetComponent<Text>();
        baseTab = GameObject.FindGameObjectWithTag("baseTab");
        clickingUpTab = GameObject.FindGameObjectWithTag("clickingUpTab");
        autoUpTab = GameObject.FindGameObjectWithTag("autoUpTab");
        specialUpTab = GameObject.FindGameObjectWithTag("specialUpTab");
        pupg = GetComponent<PlayerUpgradesScript>();
        L1 = GetComponent<Level1PerSecond>();
        L2 = GetComponent<Level2PerSecond>();
        L3 = GetComponent<Level3PerSecond>();

        criticalDamage = 0;
        factorOfClick = 1;
        UpperScrollLimit = 1000f;
        LowerScrollLimit = ScrollTab.GetComponent<RectTransform>().anchoredPosition.y;

        clickingUpTab.SetActive(false);
        autoUpTab.SetActive(false);
        specialUpTab.SetActive(false);

        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        canScroll = false;
    }

    public void AGAINBUTTON()
    {
        File.Delete(Application.persistentDataPath + "/savedGame.xx");
        SceneManager.LoadScene("level1");
    }

    void Update()
    {
        //Debug.Log();

        //Debug.Log(1 / Time.deltaTime);
        //if(!highest) mainTab.transform.position = new Vector2(mainTab.transform.position.x, ScrollTab.transform.position.y - 150f);
    }

	void FixedUpdate ()
    {
        scoreText.text = score.ToString();
        moneyText.text = money.ToString();
        timeText.text = timeTillEnd.ToString("0");

        if (timeTillEnd <= 0f) endGame();
    }

    void endGame()
    {

    }

    void makeEffect(bool crit)
    {
        
        GameObject copyOfText = (GameObject)Instantiate(clickedText, new Vector3(0f, 0f, 0f), Quaternion.identity);
        copyOfText.gameObject.GetComponent<RectTransform>().anchoredPosition = crystal.anchoredPosition;
        copyOfText.transform.SetParent(canvas.transform, false);
        copyOfText.transform.SetAsFirstSibling();

        Text copyOfText2 = copyOfText.GetComponentsInChildren<Transform>()[1].GetComponent<Text>();       
        
        if (crit)
        {
            copyOfText2.text = "+" + (factorOfClick * 2 + criticalDamage).ToString();
            copyOfText2.color = new Color32(218, 114, 126, 255);
        } 
        else copyOfText2.text = "+" + factorOfClick.ToString();


        copyOfText.gameObject.transform.SetAsLastSibling();
        copyOfText.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(UnityEngine.Random.RandomRange(-300f, 300f) * canvas.GetComponent<RectTransform>().localScale.x, 400f * canvas.GetComponent<RectTransform>().localScale.y) , ForceMode2D.Impulse);
        StartCoroutine(destroyThisGameObject(copyOfText.gameObject));
        copyOfText.GetComponent<MakeTransparent>().Fade = true;
    }

    IEnumerator destroyThisGameObject(GameObject gameObjecti)
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObjecti);
    }

    public void clickedCrystal()
    {
        if(Input.touchCount <= allowedTouchCount || testiranjeIGRE)
        {
            float critRatio = critialChance * 100;
            float randNum = UnityEngine.Random.Range(1, 100);

            if (randNum <= critRatio)
            {
                score += ((factorOfClick * 2) + criticalDamage);
                money += ((factorOfClick * 2) + criticalDamage);

                makeEffect(true);
            }
            else
            {
                score += factorOfClick;
                money += factorOfClick;
                makeEffect(false);
            }
        }    

        
    }

    public void exitToMainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }

    public void clickingUpgrades()
    {
        baseTab.SetActive(false);
        clickingUpTab.SetActive(true);
        autoUpTab.SetActive(false);
        specialUpTab.SetActive(false);
        pupg.SetPrice();
    }

    public void autoUpgrades()
    {
        baseTab.SetActive(false);
        clickingUpTab.SetActive(false);
        autoUpTab.SetActive(true);
        specialUpTab.SetActive(false);
        L1.setPrice();
        L2.setPrice();
        L3.setPrice();
    }

    public void specialUpgrades()
    {
        baseTab.SetActive(false);
        clickingUpTab.SetActive(false);
        autoUpTab.SetActive(false);
        specialUpTab.SetActive(true);
    }

    public void saveAndExit()
    {
        Save();
          
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void back()
    {
        clickingUpTab.SetActive(false);
        autoUpTab.SetActive(false);
        specialUpTab.SetActive(false);
        baseTab.SetActive(true);
    }

    void OnApplicationQuit()
    {
        
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGame.xx");
        saveData data = new saveData();
        saveToData(data);        
        bf.Serialize(file, data);
        file.Close();
    }

    void saveToData(saveData data)
    {
        data.criticalDamage = criticalDamage;
        data.critialChance = critialChance;
        data.timeTillEnd = timeTillEnd;
        data.score = score;
        data.money = money;
        data.factorOfClick = factorOfClick;

        data.priceOfUpgClickPlusOne = pupg.priceOfUpgClickPlusOne;
        data.priceOfUpgClickDouble = pupg.priceOfUpgClickDouble;
        data.priceOfCriticalUpg = pupg.priceOfCriticalUpg;

        data.priceL1 = L1.price;
        data.priceL2 = L2.price;
        data.priceL3 = L3.price;

        data.numOfMakersL1 = L1.numOfMakers;
        data.numOfMakersL2 = L2.numOfMakers;
        data.numOfMakersL3 = L3.numOfMakers;

        L1.RefreshPositions();
        L2.RefreshPositions();
        L3.RefreshPositions();

        data.PosMakersOfMoneyL1 = L1.positionsMakersOfMoney;
        data.PosMakersOfMoneyL2 = L2.positionsMakersOfMoney;
        data.PosMakersOfMoneyL3 = L3.positionsMakersOfMoney;        

        data.intervalL1 = L1.interval;
        data.intervalL2 = L2.interval;
        data.intervalL3 = L3.interval;

        data.priceSpeedUpgradeL1 = L1.priceOfUpgrade;
        data.priceSpeedUpgradeL2 = L2.priceOfUpgrade;
        data.priceSpeedUpgradeL3 = L3.priceOfUpgrade;

        data.allowedTouchCount = allowedTouchCount;


    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGame.xx"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGame.xx", FileMode.Open);
            saveData data = (saveData) bf.Deserialize(file);
            file.Close();
            loadFromData(data);            
        }
    }

    void loadFromData(saveData data)
    {
        criticalDamage = data.criticalDamage;
        critialChance = data.critialChance;
        timeTillEnd = data.timeTillEnd;
        score = data.score;
        money = data.money;
        factorOfClick = data.factorOfClick;
        allowedTouchCount = data.allowedTouchCount;

        pupg.priceOfUpgClickPlusOne = data.priceOfUpgClickPlusOne;
        pupg.priceOfUpgClickDouble = data.priceOfUpgClickDouble;
        pupg.priceOfCriticalUpg = data.priceOfCriticalUpg;

        L1.price = data.priceL1;
        L2.price = data.priceL2;
        L3.price = data.priceL3;

        L1.numOfMakers = data.numOfMakersL1;
        L2.numOfMakers = data.numOfMakersL2;
        L3.numOfMakers = data.numOfMakersL3;

        L1.positionsMakersOfMoney = data.PosMakersOfMoneyL1;
        L2.positionsMakersOfMoney = data.PosMakersOfMoneyL2;
        L3.positionsMakersOfMoney = data.PosMakersOfMoneyL3;

        L1.interval = data.intervalL1;
        L2.interval = data.intervalL2;
        L3.interval = data.intervalL3;

        L1.priceOfUpgrade = data.priceSpeedUpgradeL1;
        L2.priceOfUpgrade = data.priceSpeedUpgradeL2;
        L3.priceOfUpgrade = data.priceSpeedUpgradeL3;

        L1.setPrice();
        L2.setPrice();
        L3.setPrice();

        createMakers();

        createVisualMarkers();

    }

    void createVisualMarkers()
    {
        for (int i = 0; i < L1.numOfMakers; i++)
        {
            L1.makeVisualMarkers(L1.positionsMakersOfMoney[i][0], L1.positionsMakersOfMoney[i][1]);
        }
        for (int i = 0; i < L2.numOfMakers; i++)
        {
            L2.makeVisualMarkers(L2.positionsMakersOfMoney[i][0], L2.positionsMakersOfMoney[i][1]);
        }
        for (int i = 0; i < L3.numOfMakers; i++)
        {
            L3.makeVisualMarkers(L3.positionsMakersOfMoney[i][0], L3.positionsMakersOfMoney[i][1]);
        }
    }

    void createMakers()
    {
        for(int i=0; i< L1.numOfMakers; i++)
        {
            L1.MakeMaker();
        }
        for (int i = 0; i < L2.numOfMakers; i++)
        {
            L2.MakeMaker();
        }
        for (int i = 0; i < L3.numOfMakers; i++)
        {
            L3.MakeMaker();
        }

    }

    public void deleteSave()
    {
        File.Delete(Application.persistentDataPath + "/savedGame.xx");
        Application.Quit();
    }

    public void StartDrag()
    {      
        if(canScroll)
        {
            ScrollTab.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            dragStart = ScrollTab.transform.position;
            ScrollTab.transform.SetAsLastSibling();
        }       
    }

    public void Drag()
    {
        if (canScroll)
        {
            if (!(ScrollTab.GetComponent<RectTransform>().anchoredPosition.y > UpperScrollLimit - Mathf.Epsilon))
            {
                ScrollTab.transform.position = new Vector2(ScrollTab.transform.position.x, Input.mousePosition.y);

            }
            else
            {
                highest = true;
            }
        }
    }

    public void EndDrag()
    {
        
            Vector2 distance = new Vector2(0f, ScrollTab.transform.position.y) - new Vector2(0f, dragStart.y);
            distance = distance.normalized;
            ScrollTab.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            ScrollTab.gameObject.GetComponent<Rigidbody2D>().AddForce(distance * 1000, ForceMode2D.Impulse);
         
    }

    
}

[Serializable]
class saveData
{
    public int criticalDamage;
    public float critialChance;
    public float timeTillEnd;
    public int score;
    public int money;
    public int factorOfClick;

    public int priceOfUpgClickPlusOne;
    public int priceOfUpgClickDouble;
    public int priceOfCriticalUpg;

    public int priceL1;
    public int priceL2;
    public int priceL3;
    public int priceSpeedUpgradeL1;
    public int priceSpeedUpgradeL2;
    public int priceSpeedUpgradeL3;

    public int numOfMakersL1;
    public int numOfMakersL2;
    public int numOfMakersL3;

    public float intervalL1;
    public float intervalL2;
    public float intervalL3;

    public List<List<float>> PosMakersOfMoneyL1;
    public List<List<float>> PosMakersOfMoneyL2;
    public List<List<float>> PosMakersOfMoneyL3;

    public int allowedTouchCount;
}

