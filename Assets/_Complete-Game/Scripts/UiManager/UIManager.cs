using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace RogueTest
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] Text FoodCount;
        [SerializeField] Slider foodSlider;
        // public static Action OnFoodValueChanged;
        private void OnEnable()
        {
            Global.UpdateUI += OnFoodValueChanged;
        }
        private void OnDisable()
        {
            Global.UpdateUI -= OnFoodValueChanged;

        }
        public void OnFoodValueChanged()
        {
            FoodCount.text = Global.Instance.Food + "/" + Global.maxFoodValue;
            foodSlider.value = (float)Global.Instance.Food / (float)Global.maxFoodValue;
        }

    }
}