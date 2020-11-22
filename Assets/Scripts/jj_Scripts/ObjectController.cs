using System.Collections;
using System.Collections.Generic;
using Gvr.Internal;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ObjectController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public UnityEvent objectGazedAt;

	private bool gazzing;

	public float gazeTimer;
	private float currentTime;
    
    void Awake(){
    	currentTime = gazeTimer;
    }

    void Update()
    {
    	//Debug.Log(gazzing);
        if(gazzing){
        	currentTime -= Time.deltaTime;

        	if(currentTime <= 0f){
        		objectGazedAt.Invoke();
        		currentTime = gazeTimer;
        	}
        }
    }

  

    public void OnPointerEnter(PointerEventData eventData){
    	gazzing = true;
    	//Debug.Log("I have this.");
    }

    public void OnPointerExit(PointerEventData eventData){
    	//Debug.Log("I LOST this.");
    	gazzing = false;
    	currentTime = gazeTimer;
    }

    public void TestME(){
    	Debug.Log("I bwork!");
    }

}
