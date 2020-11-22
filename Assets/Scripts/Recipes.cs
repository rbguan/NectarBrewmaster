using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Recipes", order = 1)]
    public class Recipes : ScriptableObject
    {
        [SerializeField]
        private List<Recipe> _AvailableRecipes;

        public Ingredient detectRecipe(HashSet<Ingredient> inCup){
            if(_AvailableRecipes == null || _AvailableRecipes.Count <= 0){
                return null;
            }
            foreach(Recipe r  in _AvailableRecipes)
            {
                if(r.doIngredientsMatch(inCup)){
                    Debug.Log(r.EndIngredient.IngredientName);
                    return r.EndIngredient;
                }
            }
            return null;

        }

        public List<Ingredient> getEndIngredients()
        {
            List<Ingredient> endIngredients = new List<Ingredient>();
            foreach(Recipe r  in _AvailableRecipes){
                endIngredients.Add(r.EndIngredient);
            }
            return endIngredients;
        }
    }

    [System.Serializable]
    public class Recipe : ISerializationCallbackReceiver
    {
        [SerializeField]
        public List<Ingredient> _ingredients;
        // public string DrinkName;
        public HashSet<Ingredient> Ingredients = new HashSet<Ingredient>();
        
        public Ingredient EndIngredient;

        public bool doIngredientsMatch(HashSet<Ingredient> inCup){
            return inCup.SetEquals(Ingredients);
        }
        public void OnBeforeSerialize()
        {
            _ingredients = new List<Ingredient>();
            // int i = 0;
            foreach(Ingredient ingredient in Ingredients)
            {
                _ingredients.Add(ingredient);
                // i++;
            }
        }

        public void OnAfterDeserialize()
        {
            Ingredients.Clear();
            foreach(Ingredient ingredient in _ingredients)
            {
                Ingredients.Add(ingredient);
            }
            _ingredients = null;
        }
    }
}