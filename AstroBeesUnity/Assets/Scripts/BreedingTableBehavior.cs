using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreedingTableBehavior : MonoBehaviour
{
    public int colorTraits;
    public int stemTraits;
    public int petalTraits;
    public int thornsTraits;

    public int colorTraits2;
    public int stemTraits2;
    public int petalTraits2;
    public int thornsTraits2;

    public GameObject flowerPrefab;

    private Punnett square;

    private GameObject pod1;
    private GameObject pod2;

    // Start is called before the first frame update
    void Start()
    {
        square = GameObject.FindGameObjectWithTag("punnett").GetComponent<Punnett>();
        pod1 = GameObject.Find("Pod1");
        pod2 = GameObject.Find("Pod2");
    }

    public void StartSquare()
    {
        int color = square.RunSquare(colorTraits, colorTraits2);
        int stem = square.RunSquare(stemTraits, stemTraits2);
        int thorns = square.RunSquare(thornsTraits, thornsTraits2);
        int petal = square.RunSquare(petalTraits, petalTraits2);

        GameObject flower = Instantiate(flowerPrefab, transform);
        flower.transform.localPosition = Vector3.zero;

        flower.GetComponent<FlowerBehaviour>().colorTraits = color;
        flower.GetComponent<FlowerBehaviour>().stemTraits = stem;
        flower.GetComponent<FlowerBehaviour>().thornsTraits = thorns;
        flower.GetComponent<FlowerBehaviour>().petalTraits = petal;
        flower.GetComponent<FlowerBehaviour>().SpawnedInPot();
    }

    bool CheckForGenes()
    {
        if (pod1.GetComponent<PodBehavior>().hasTraits && pod2.GetComponent<PodBehavior>().hasTraits)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void GetTraits(int podNum, int color, int stem, int petal, int thorns)
    {
        if (podNum == 1)
        {
            colorTraits = color;
            stemTraits = stem;
            petalTraits = petal;
            thornsTraits = thorns;
        }
        else
        {
            colorTraits2 = color;
            stemTraits2 = stem;
            petalTraits2 = petal;
            thornsTraits2 = thorns;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
