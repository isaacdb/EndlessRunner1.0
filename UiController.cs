using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public static UiController instance;

    public Slider energySlider;

    public Text distanceTextValue;
    private float distanceValue = 0;

    private void Start()
    {
        instance = this;

        distanceTextValue.text = distanceValue.ToString();
    }
    public void SetDistanceValue(float distance) {
        distanceTextValue.text = distance.ToString();
    }

    public void SetEnergySlideValue(float currentEnergy, float totalEnergy) {

        energySlider.value = (currentEnergy / totalEnergy);

    }


}
