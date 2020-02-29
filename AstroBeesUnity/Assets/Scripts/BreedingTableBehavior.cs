using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreedingTableBehavior : MonoBehaviour
{
    //public int colorTraits;
    public int stemTraits;
    public int petalTraits;
    public int thornsTraits;

    //public int colorTraits2;
    public int stemTraits2;
    public int petalTraits2;
    public int thornsTraits2;

    public GameObject flowerPrefab;

    private Punnett square;

    //private GameObject pod1;
    //private GameObject pod2;

    // Start is called before the first frame update
    void Start()
    {
        square = GameObject.FindGameObjectWithTag("punnett").GetComponent<Punnett>();
        //pod1 = GameObject.Find("Pod1");
        //pod2 = GameObject.Find("Pod2");
    }

    public void StartSquare()
    {
        //int color = square.RunSquare(colorTraits, colorTraits2);
        int stem = square.RunSquare(stemTraits, stemTraits2);
        int thorns = square.RunSquare(thornsTraits, thornsTraits2);
        int petal = square.RunSquare(petalTraits, petalTraits2);

        GameObject flower = Instantiate(flowerPrefab, transform);
        //flower.transform.localPosition = Vector3.zero;

        //flower.GetComponent<FlowerBehaviour>().colorTraits = color;
        flower.GetComponent<FlowerBehaviour>().stemTraits = stem;
        flower.GetComponent<FlowerBehaviour>().thornsTraits = thorns;
        flower.GetComponent<FlowerBehaviour>().petalTraits = petal;
        flower.GetComponent<FlowerBehaviour>().SpawnedInPot();
    }


    public void GetTraits(int podNum, int traitType, int trait)
    {
        if (podNum == 1)
        {
            if (traitType == 1)
            {
                petalTraits = trait;
            }
            else if (traitType == 2)
            {
                stemTraits = trait;
            }
            else
            {
                thornsTraits = trait;
            }
        }
        else
        {
            if (traitType == 1)
            {
                petalTraits2 = trait;
            }
            else if (traitType == 2)
            {
                stemTraits2 = trait;
            }
            else
            {
                thornsTraits2 = trait;
            }
        }
        if (petalTraits != 0 && petalTraits2 != 0 && GameManager.tracker == 1)
        {
            GameManager.tracker++;
        }
        else if (stemTraits != 0 && stemTraits2 != 0 && GameManager.tracker == 2)
        {
            GameManager.tracker++;
        }
        else if (thornsTraits != 0 && thornsTraits2 != 0 && GameManager.tracker == 3)
        {
            GameManager.tracker++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
