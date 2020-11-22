using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Cup : MonoBehaviour
    {
        public Recipes RecipeList;
        public HashSet<Ingredient> inCup = new HashSet<Ingredient>();
        public GameObject StartCupPrefab;
        public GameObject DisplayedDrink;
        void Start()
        {
            DisplayedDrink = Instantiate(StartCupPrefab, transform.position, Quaternion.identity) as GameObject;
        }
        public void ResetCup()
        {
            Destroy(DisplayedDrink);
            DisplayedDrink = Instantiate(StartCupPrefab, transform.position, Quaternion.identity) as GameObject;
        }
        public bool TryToPutIngredient(Ingredient newIngredient)
        {
            if(inCup.Contains(newIngredient)){
                return false;
            } else{
                PutIngredient(newIngredient);
                return true;
            }
        }

        private void PutIngredient(Ingredient newIngredient)
        {
            inCup.Add(newIngredient);
            ChangeCup();
        }

        private void ChangeCup()
        {
            Ingredient drink = RecipeList.detectRecipe(inCup);
            if(drink != null){
                Destroy(DisplayedDrink);
                DisplayedDrink = Instantiate(drink.Model, transform.position, Quaternion.identity) as GameObject;
            }
        }
    }
}
