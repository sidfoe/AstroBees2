using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PodBehavior : MonoBehaviour
{
    public int podNumber;
    public int traitType;

    public Sprite traitSprite;
    public GameObject traitObj;

    public int trait;
    public GameObject nextPod;
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


    public void SendTraits()
    {
        traitObj.GetComponent<SpriteRenderer>().sprite = traitSprite;
        traitObj.GetComponent<SpriteRenderer>().color = Color.white;
        breedingTable.GetComponent<BreedingTableBehavior>().GetTraits(podNumber, traitType, trait);
    }

}
