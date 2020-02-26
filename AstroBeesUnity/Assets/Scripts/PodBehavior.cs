using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PodBehavior : MonoBehaviour
{
    public int podNumber;

    public int colorTraits;
    public int stemTraits;
    public int petalTraits;
    public int thornsTraits;

    public bool hasTraits = false;

    private GameObject breedingTable;
    // Start is called before the first frame update
    void Start()
    {
        breedingTable = GameObject.Find("Breeding Table");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TakeTraits()
    {
        hasTraits = true;
    }

    public void SendTraits()
    {
        breedingTable.GetComponent<BreedingTableBehavior>().GetTraits(podNumber, colorTraits, stemTraits, petalTraits, thornsTraits);
    }

}
