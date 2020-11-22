using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Ingredient")]
    public class Ingredient : ScriptableObject
    {
        public string IngredientName;
        public Sprite Sprite;
        public GameObject Model;
    }
}
