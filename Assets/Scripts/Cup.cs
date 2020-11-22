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
        public Ingredient currentDrink;
        private Vector3 cupSpawnLocation;
        public float cupSpawnVerticalOffset = .00115f;
        void Awake() 
        {
            cupSpawnLocation = new Vector3(transform.position.x,transform.position.y,transform.position.z + cupSpawnVerticalOffset);
        }
        void Start()
        {
            currentDrink = RecipeList.detectRecipe(inCup);
            DisplayedDrink = Instantiate(StartCupPrefab, cupSpawnLocation, transform.rotation) as GameObject;
            DisplayedDrink.transform.parent = transform;
        }
        public void ResetCup()
        {
            Destroy(DisplayedDrink);
            inCup = new HashSet<Ingredient>();
            currentDrink = RecipeList.detectRecipe(inCup);
            DisplayedDrink = Instantiate(StartCupPrefab, cupSpawnLocation, Quaternion.identity) as GameObject;
            DisplayedDrink.transform.parent = transform;
        }
        public bool CanPutIngredient(Ingredient newIngredient)
        {
            if(inCup.Contains(newIngredient)){
                return false;
            } else{
                PutIngredient(newIngredient);
                return true;
            }
        }

        public void PutIngredient(Ingredient newIngredient)
        {
            inCup.Add(newIngredient);
            ChangeCup();
        }

        private void ChangeCup()
        {
            Ingredient drink = RecipeList.detectRecipe(inCup);
            if(drink != null){
                Destroy(DisplayedDrink);
                currentDrink = drink;
                DisplayedDrink = Instantiate(drink.Model, cupSpawnLocation, Quaternion.identity) as GameObject;
                DisplayedDrink.transform.parent = transform;
            }
        }
    }
}
