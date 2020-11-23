using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public enum BeeState
    {
        MovingToSeat,
        Ordering,
        Waiting,
        Drinking
    }
    public class DrinkCoaster : MonoBehaviour
    {   
        public GameObject drinkHeld;
        public GameObject beePrefab;
        public Cup cup;
        private Vector3 cupSpawnLocation;
        public float cupSpawnVerticalOffset = .00115f;
        public Ingredient curIngredient;
        private bool beeSpawned;
        public Recipes menu;
        public Recipes allrecipes;
        private List<Ingredient> menuItems;
        private Ingredient beesOrder;
        private GameObject currentBee;
        private BeeState curState;
        public GameObject beeSpawn;
        public Vector3 beeSpawnPos;
        public GameObject seat;
        private Vector3 seatPos;
        public Vector3 moveVelocity = new Vector3(1,1,1);
        public float dampTime = 2f;
        void Awake() {
            cupSpawnLocation = new Vector3(transform.position.x,transform.position.y,transform.position.z + cupSpawnVerticalOffset);
        }
        void Start()
        {
            menuItems = menu.getEndIngredients();
            seatPos = seat.transform.position;
            beeSpawnPos = beeSpawn.transform.position;
            StartCoroutine(beeLife());
        }
        public void deliverDrink()
        {
            curIngredient = cup.currentDrink;
            drinkHeld = Instantiate(curIngredient.Model, cupSpawnLocation, transform.rotation) as GameObject;
            drinkHeld.transform.parent = transform;
            cup.ResetCup();
            
            
        }

        private Ingredient randomMenuItem()
        {
            return menuItems[Random.Range(0,menuItems.Count - 1)];
        }
        private IEnumerator beeLife()
        {
            yield return spawnBee();
            if(!beeSpawned){
                StartCoroutine(beeLife());
            }
        }
        

        private IEnumerator spawnBee()
        {
            beeSpawned = true;
            yield return new WaitForSeconds(Random.Range(0,2f));
            currentBee = Instantiate(beePrefab, beeSpawnPos, beeSpawn.transform.rotation) as GameObject;
            currentBee.transform.parent = transform;
            curState = BeeState.MovingToSeat;
            yield return moveBeeToSeat();
        }

        private IEnumerator moveBeeToSeat()
        {
            while(Vector3.Distance(currentBee.transform.position, seatPos) > .1f){
                currentBee.transform.position = Vector3.SmoothDamp(currentBee.transform.position, seatPos, ref moveVelocity, dampTime);
                yield return null;
            }
            yield return beeOrder();
        }
        private IEnumerator beeOrder()
        {
            curState = BeeState.Ordering;
            beesOrder = randomMenuItem();
            Recipe beeOrderRecipe = allrecipes.getRecipeFromEndIngredient(beesOrder);
            currentBee.GetComponent<Bee>().setRecipeInfo(beeOrderRecipe);
            currentBee.GetComponent<Bee>().ShowBasicOrder();
            Debug.Log("orderin " + beesOrder.IngredientName);
            yield return null;
        }

        private IEnumerator beeWait()
        {
            curState = BeeState.Waiting;
            while(curState == BeeState.Waiting){
                yield return null;
            }
        }
    }

}
