using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Bee : MonoBehaviour
    {
        // Start is called before the first frame update
        public Ingredient order;
        public Recipe orderRecipe;
        public float patience;
        public Image SmallSpeechBubble;
        public Image SmallSpeechBubbleImage;
        public Image LargeSpeechBubble;
        public Image LargeSpeechBubbleImageL;
        public Image LargeSpeechBubbleImageM;
        public Image LargeSpeechBubbleImageR;
        public Recipes recipesList;
        public float extendedBubbleUptime = 4f;

        void Awake() 
        {
            SmallSpeechBubble.enabled = false;
            SmallSpeechBubbleImage.enabled = false;
            LargeSpeechBubble.enabled = false;
            LargeSpeechBubbleImageL.enabled = false;
            LargeSpeechBubbleImageM.enabled = false;
            LargeSpeechBubbleImageR.enabled = false;
        }
        public void setRecipeInfo(Recipe r)
        {
            Sprite endProduct = r.EndIngredient.Sprite;
            List<Sprite> orderIngredients = new List<Sprite>();
            foreach(Ingredient i in r.Ingredients) {
                orderIngredients.Add(i.Sprite);
            }
            SmallSpeechBubbleImage.sprite = endProduct;
            LargeSpeechBubbleImageL.sprite = orderIngredients[0];
            LargeSpeechBubbleImageM.sprite = orderIngredients[1];
            LargeSpeechBubbleImageR.sprite = endProduct;
        }
        public void ShowBasicOrder()
        {
            SmallSpeechBubble.enabled = true;
            SmallSpeechBubbleImage.enabled = true;
            LargeSpeechBubble.enabled = false;
            LargeSpeechBubbleImageL.enabled = false;
            LargeSpeechBubbleImageM.enabled = false;
            LargeSpeechBubbleImageR.enabled = false;
        }

        public void ShowExtendedOrder(){
            SmallSpeechBubble.enabled = false;
            SmallSpeechBubbleImage.enabled = false;
            LargeSpeechBubble.enabled = true;
            LargeSpeechBubbleImageL.enabled = true;
            LargeSpeechBubbleImageM.enabled = true;
            LargeSpeechBubbleImageR.enabled = true;
            StartCoroutine(returnToSmallBubble());
        }
        
        private IEnumerator returnToSmallBubble(){
            yield return new WaitForSeconds(extendedBubbleUptime);
            ShowBasicOrder();
        }
        
    }
}
