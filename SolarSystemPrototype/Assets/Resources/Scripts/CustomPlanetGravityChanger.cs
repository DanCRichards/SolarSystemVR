using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class CustomPlanetGravityChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hammer;
    public GameObject slider;
    void Start()
    {
        
    }

    public void ChangeGravity(SliderEventData eventData)
    {
        float value = eventData.NewValue;
        float force = 0f;
        if(value != 0)
        {
            // To Stop DivideByZero Error
            force = (0.5f / value) * -1;
            force = force *  10f;
        }

        hammer.GetComponent<ConstantForce>().force = new Vector3(0f, force, 0f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
} 