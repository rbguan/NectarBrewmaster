using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
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
                    return r.EndIngredient;
                }
            }
            return null;

        }
    }

    [System.Serializable]
    public class Recipe : ISerializationCallbackReceiver
    {
        [SerializeField]
        private Ingredient[] _ingredients;
        // public string DrinkName;
        public HashSet<Ingredient> Ingredients = new HashSet<Ingredient>();
        public Ingredient EndIngredient;

        public bool doIngredientsMatch(HashSet<Ingredient> inCup){
            return inCup.Equals(Ingredients);
        }
        public void OnBeforeSerialize()
        {
            _ingredients = new Ingredient[Ingredients.Count];
            int i = 0;
            foreach(Ingredient ingredient in Ingredients)
            {
                _ingredients[i] = ingredient;
                i++;
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