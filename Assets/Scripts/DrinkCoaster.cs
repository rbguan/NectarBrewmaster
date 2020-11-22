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
        void Start()
        {
            menuItems = menu.getEndIngredients();
            seatPos = seat.transform.position;
            beeSpawnPos = beeSpawn.transform.position;
        }
        public void deliverDrink()
        {
            curIngredient = cup.currentDrink;
            cup.ResetCup();
            
            drinkHeld = Instantiate(curIngredient.Model, cupSpawnLocation, transform.rotation) as GameObject;
            drinkHeld.transform.parent = transform;
        }

        private Ingredient randomMenuItem()
        {
            return menuItems[Random.Range(0,menuItems.Count - 1)];
        }
        private IEnumerator beeLife()
        {
            yield return spawnBee();
            yield return beeOrder();
            if(!beeSpawned){
                StartCoroutine(beeLife());
            }
            
        }
        private IEnumerator beeOrder()
        {
            beesOrder = randomMenuItem();
            yield return null;
        }

        private IEnumerator spawnBee()
        {
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
    }
}
