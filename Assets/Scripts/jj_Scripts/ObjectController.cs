using System.Collections;
using System.Collections.Generic;
using Gvr.Internal;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectController : MonoBehaviour, IPointerEnterHandler
{

	public bool gazedAt = false;

	bool gazzing;
    
    void Start(){
    	
    }


    void Update()
    {
        if(gazzing){

        }
    }

    public void GazeStart(){
    	bool gazzing = true;

    }

    public void GazeEnd(){
    	bool gazzing = false;

    }

    public void OnPointerEnter(PointerEventData eventData){
    	Debug.Log("I have this.");
    }

}
