using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlowerBehaviour : MonoBehaviour
{
    // 1 = two big
    //2 = two small
    //3 = one big one small

    public int colorTraits; //1 red 2 blue 3 purple
    public int stemTraits; //1 & 3 thick 2 skinny
    public int petalTraits; //1 & 3 
    public int thornsTraits;

    public bool updateLook = false;

    private void Start()
    {

    }

    private void LateUpdate()
    {
        if(updateLook == false)
        {
            updateLook = true;

            
        }
    }

    public void Grow()
    {
        Vector3 newSize = new Vector3(1.5f, 1.5f);
        transform.localScale = newSize;
    }

    public void Shrink()
    {
        Vector3 newSize = new Vector3(1, 1);
        transform.localScale = newSize;
    }
}
