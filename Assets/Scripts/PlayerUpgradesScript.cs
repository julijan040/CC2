using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerUpgradesScript : MonoBehaviour {

    GameManagerScript GameManagerScript;
    public int priceOfUpgClickPlusOne;
    public int priceOfUpgClickDouble;
    public int priceOfCriticalUpg;
    public int priceOfCriticalDamageUpg;
    public int priceOfallowedTouchCount;
    Text plusDoublePerClick;
    Text plusOneScorePerClick;
    Text priceOfCriticalPerClick;
    Text priceOfCriticalDamage;
    Text priceOfallowedTouch;

    void Awake ()
    {
        GameManagerScript = GetComponent<GameManagerScript>();
        priceOfCriticalPerClick = GameObject.FindGameObjectWithTag("criticalPerClick").GetComponent<Text>();
        plusDoublePerClick = GameObject.FindGameObjectWithTag("plusDoublePerClick").GetComponent<Text>();
        plusOneScorePerClick = GameObject.FindGameObjectWithTag("plusOneScorePerClick").GetComponent<Text>();
        priceOfCriticalDamage = GameObject.FindGameObjectWithTag("criticalDamagePerClick").GetComponent<Text>();
        priceOfallowedTouch = GameObject.FindGameObjectWithTag("priceOfallowedTouch").GetComponent<Text>();
        priceOfallowedTouch.text = priceOfallowedTouchCount.ToString();
        plusDoublePerClick.text = priceOfUpgClickDouble.ToString();
        plusOneScorePerClick.text = priceOfUpgClickPlusOne.ToString();
        priceOfCriticalPerClick.text = priceOfCriticalUpg.ToString();
        priceOfCriticalDamage.text = priceOfCriticalDamageUpg.ToString();
    }

    public void SetPrice()
    {
        plusDoublePerClick.text = priceOfUpgClickDouble.ToString();
        plusOneScorePerClick.text = priceOfUpgClickPlusOne.ToString();
        priceOfCriticalPerClick.text = priceOfCriticalUpg.ToString();
    }
	
	public void ClickedPlusOne()
    {
        if((GameManagerScript.money - priceOfUpgClickPlusOne) >= 0)
        {
            GameManagerScript.money -= priceOfUpgClickPlusOne;
            priceOfUpgClickPlusOne += 100;
            GameManagerScript.factorOfClick += 1;
            plusOneScorePerClick.text = priceOfUpgClickPlusOne.ToString();
        }
    }

    public void ClickedDoubleOne()
    {
        if ((GameManagerScript.money - priceOfUpgClickDouble) >= 0)
        {
            GameManagerScript.money -= priceOfUpgClickDouble;
            priceOfUpgClickDouble *= 3;
            GameManagerScript.factorOfClick *= 2;
            plusDoublePerClick.text = priceOfUpgClickDouble.ToString();
        }
    }

    public void clickedCritical()
    {
        if ((GameManagerScript.money - priceOfCriticalUpg) >= 0)
        {
            GameManagerScript.money -= priceOfCriticalUpg;
            priceOfCriticalUpg *= 3;
            GameManagerScript.critialChance += 0.05f;
            priceOfCriticalPerClick.text = priceOfCriticalUpg.ToString();
        }       
    }

    public void clickedCriticalDamage()
    {
        if ((GameManagerScript.money - priceOfCriticalDamageUpg) >= 0)
        {
            GameManagerScript.money -= priceOfCriticalDamageUpg;
            priceOfCriticalDamageUpg *= 3;
            GameManagerScript.criticalDamage += 1;
            priceOfCriticalDamage.text = priceOfCriticalDamageUpg.ToString();
        }
    }

    public void increseTouchCount()
    {
        if ((GameManagerScript.money - priceOfallowedTouchCount) >= 0)
        {
            GameManagerScript.money -= priceOfallowedTouchCount;
            priceOfallowedTouchCount *= 3;
            GameManagerScript.allowedTouchCount += 1;
            priceOfallowedTouch.text = priceOfallowedTouchCount.ToString();
        }
        
    }
}
