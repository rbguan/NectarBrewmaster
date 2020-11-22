using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Trashcan : MonoBehaviour
    {
        public Cup cup;
        public void EmptyCup()
        {
            if(cup.inCup.Count > 0){ 
                cup.ResetCup();
            }
        }
    }
}
