using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class IngredientSource : MonoBehaviour
    {
        public Animator m_Animator;
        public Ingredient ingredientToDispense;
        
        public Cup cup;

        public void TryToDispense()
        {
            if(cup.CanPutIngredient(ingredientToDispense)){
                m_Animator.SetTrigger("play");
            }
        }

        public void Dispense(){
            cup.PutIngredient(ingredientToDispense);
        }
    }
}
