using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_CashierManager : MonoBehaviour
{
    
    public int playerMoney;
    public GameObject[] storeObjects;
    public Scrollbar scroll;
    public float scrollRate;



    public void BuyThisItem(DecorItem item){
    	if( playerMoney >= item.cost && item.render.enabled != true)
    	{
    		playerMoney -= item.cost;
    		item.render.enabled = true;
    		Debug.Log("item bought");
    	}
    	Debug.Log("money Left: " + playerMoney);
    }

    public void PayPlayer(int _pay){
    	playerMoney += _pay;
    }

    public void Buy(int _cost){
    	playerMoney -= _cost;
    }

    public void ScrollUp(){
    	scroll.value += scrollRate;
    }

    public void ScrollDown(){
    	scroll.value -= scrollRate;
    }

}
