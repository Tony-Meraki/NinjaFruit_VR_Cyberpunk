using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSliceListener : MonoBehaviour
{
    public MainMenu slicer1;
    private void OnTriggerEnter(Collider other)
    {
        slicer1.isTouched = true;
    }
}
