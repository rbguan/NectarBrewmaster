using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public enum BeeState
    {
        Ordering,
        Waiting,
        Drinking
    }
    public class DrinkCoaster : MonoBehaviour
    {   
        public GameObject drinkHeld;
        public GameObject beePrefab;
        public GameObject beeSpawn;
        public Cup cup;
        private Vector3 cupSpawnLocation;
        public float cupSpawnVerticalOffset = .00115f;
        public Ingredient curIngredient;
        private bool beeSpawned;

        public void deliverDrink()
        {
            curIngredient = cup.currentDrink;
            cup.ResetCup();
            drinkHeld = Instantiate(curIngredient.Model, cupSpawnLocation, transform.rotation) as GameObject;
            drinkHeld.transform.parent = transform;
        }

        private IEnumerator beeLife()
        {
            SpawnBee();
            yield return null;
            StartCoroutine(beeLife());
        }
        private IEnumerator beeOrder()
        {
            yield return null;
        }

        private void SpawnBee()
        {
            
        }
    }
}
