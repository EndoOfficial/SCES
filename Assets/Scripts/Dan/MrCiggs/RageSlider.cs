using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RageSlider : MonoBehaviour
{
    public MrCiggs MrCiggs;
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }
    // Update is called once per frame
    void Update()
    {
        if (slider != null)
        {
            // update rage slider
            slider.value = CalculateRage();

        }
        float CalculateRage()
        {
            return MrCiggs.rage / 100;
        }
    }
}
