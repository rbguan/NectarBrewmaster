using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorItem : MonoBehaviour
{
    public MeshRenderer render;
    public int cost;
    
    void Start(){
    	render = GetComponent<MeshRenderer>();
    	render.enabled = false;
    }

}
