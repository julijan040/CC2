using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Level1PerSecond : MonoBehaviour
{
    public GameObject autoClickGenerator;
    float startTime;
    public float interval;
    GameManagerScript GameManagerScript;
    public int factorOfMakersOfMoney;
    public int price;
    public int priceOfUpgrade;
    public float LowerIntervalFactor;
    public Text Level1AutoClick;
    public Text Level1AutoClickUpgrade;
    RectTransform crystal;
    GameObject canvas;
    public float deviation;
    public int numOfMakers;
    public List<GameObject> MakersOfMoney = new List<GameObject>();
    public List<List<float>> positionsMakersOfMoney = new List<List<float>>();
    public GameObject UpgradeButton;


    void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        crystal = GameObject.FindGameObjectWithTag("Crystal").GetComponent<RectTransform>();
        GameManagerScript = GetComponent<GameManagerScript>();
        Level1AutoClick.text = price.ToString();
        Level1AutoClickUpgrade.text = priceOfUpgrade.ToString();
    }

    public void RefreshPositions()
    {
        for(int i=0; i<MakersOfMoney.Count; i++)
        {
            positionsMakersOfMoney[i][0] = MakersOfMoney[i].GetComponent<RectTransform>().anchoredPosition.x;
            positionsMakersOfMoney[i][1] = MakersOfMoney[i].GetComponent<RectTransform>().anchoredPosition.y;
        }
    }

    public void makeVisualMarkers(float x, float y)
    {
        GameObject gameObj = (GameObject)Instantiate(autoClickGenerator, Vector3.zero, Quaternion.identity);
        gameObj.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
        gameObj.transform.SetParent(canvas.transform, false);
        gameObj.transform.SetAsFirstSibling();
        MakersOfMoney.Add(gameObj);
        List<float> pos = new List<float>();
        pos.Add(gameObj.GetComponent<RectTransform>().anchoredPosition.x);
        pos.Add(gameObj.GetComponent<RectTransform>().anchoredPosition.y);
        positionsMakersOfMoney.Add(pos);
    }

    public void setPrice()
    {
        Level1AutoClick.text = price.ToString();
        Level1AutoClickUpgrade.text = priceOfUpgrade.ToString();
    }
    
    public void Level1Click()
    {
        if ((GameManagerScript.money - price) >= 0)
        {
            numOfMakers++;
            GameManagerScript.money -= price;
            price += price/10;
            Level1AutoClick.text = price.ToString();
            StartCoroutine(makerOfMoney());
            GameObject gameObj = (GameObject) Instantiate(autoClickGenerator, Vector3.zero, Quaternion.identity);

            float pozicija = UnityEngine.Random.Range(0F, 1F);
            pozicija = pozicija * 2 * Mathf.PI;
            float y = deviation * Mathf.Sin(pozicija) + crystal.anchoredPosition.y;
            float x = deviation * Mathf.Cos(pozicija) + crystal.anchoredPosition.x;

            gameObj.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
            gameObj.transform.SetParent(canvas.transform, false);
            gameObj.transform.SetAsFirstSibling();
            MakersOfMoney.Add(gameObj);
            List<float> pos = new List<float>();
            pos.Add(gameObj.GetComponent<RectTransform>().anchoredPosition.x);
            pos.Add(gameObj.GetComponent<RectTransform>().anchoredPosition.y);
            positionsMakersOfMoney.Add(pos);
        }
    }

    public void MakeMaker()
    {
        StartCoroutine(makerOfMoney());
    }

    IEnumerator makerOfMoney()
    {
        GameManagerScript.money += factorOfMakersOfMoney;
        GameManagerScript.score += factorOfMakersOfMoney;
        yield return new WaitForSeconds(interval);
        StartCoroutine(makerOfMoney());
    }

    public void UpgradeLevel1AutoUpgrade()
    {
        if ((GameManagerScript.money - priceOfUpgrade) >= 0 )
        {
            if(interval - LowerIntervalFactor <= 0)
            {
                UpgradeButton.GetComponent<Button>().interactable = false;
                UpgradeButton.transform.GetChild(0).GetComponent<Text>().text = "MAX";
            }
            else
            {
                interval -= LowerIntervalFactor;
                GameManagerScript.money -= priceOfUpgrade;
                priceOfUpgrade *= 2;
                Level1AutoClickUpgrade.text = priceOfUpgrade.ToString();
            }
            
        }

    }

}
