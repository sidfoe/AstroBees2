using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Text collectText;
    public GameObject flowerPrefab;
    public GameObject breedGraphic;

    private BreedGraphicBehavior bgb;

    public GameObject pod1;

    private Punnett square;
    private FlowerBehaviour fb;
    public GameObject returnButton;

    private bool runOnce = false;

    private int finalPetal;
    private int finalStem;
    private int finalThorns;

    //private GameObject pod1;
    //private GameObject pod2;

    // Start is called before the first frame update
    void Start()
    {
        bgb = breedGraphic.GetComponent<BreedGraphicBehavior>();
        square = GameObject.FindGameObjectWithTag("punnett").GetComponent<Punnett>();
        collectText.text = "Go Outside to the Left and Collect traits!";
        
        //pod1 = GameObject.Find("Pod1");
        //pod2 = GameObject.Find("Pod2");
    }

    public void StartSquare()
    {
        //int color = square.RunSquare(colorTraits, colorTraits2);
        finalStem = square.RunSquare(stemTraits, stemTraits2);
        finalThorns = square.RunSquare(thornsTraits, thornsTraits2);
        finalPetal = square.RunSquare(petalTraits, petalTraits2);

        breedGraphic.SetActive(true);
        bgb.StartGraphic(finalPetal, finalStem, finalThorns);



        //breedGraphic.SetActive(true);
        //breedGraphic.GetComponent<BreedGraphicBehavior>().start = true;

        //pod1.GetComponent<PodBehavior>().BreedGraphic();

        //returnButton.SetActive(true);
    }


    public void SpawnFinalFlower()
    {
        GameObject flower = Instantiate(flowerPrefab, transform);
        flower.transform.localPosition = Vector3.down * 2;
        fb = flower.GetComponent<FlowerBehaviour>();
        //flower.GetComponent<FlowerBehaviour>().colorTraits = color;
        fb.stemTraits = finalStem;
        fb.thornsTraits = finalThorns;
        fb.petalTraits = finalPetal;
        fb.SpawnedInPot();
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
        if (petalTraits != 0 && petalTraits2 == 0 && GameManager.tracker == 1)
        {
            collectText.text = "Collect your second petal gene!";
        }
        else if (petalTraits != 0 && petalTraits2 != 0 && GameManager.tracker == 1)
        {
            GameManager.tracker++;
            collectText.text = "Collect your first stem gene!";
        }
        if (stemTraits != 0 && stemTraits2 == 0 && GameManager.tracker == 2)
        {
            collectText.text = "Collect your second stem gene!";
        }
        else if (stemTraits != 0 && stemTraits2 != 0 && GameManager.tracker == 2)
        {
            GameManager.tracker++;
            collectText.text = "Collect your first thorn gene!";
        }
        if (thornsTraits != 0 && thornsTraits2 == 0 && GameManager.tracker == 3)
        {
            collectText.text = "Collect your second thorn gene!";
        }
        else if (thornsTraits != 0 && thornsTraits2 != 0 && GameManager.tracker == 3)
        {
            GameManager.tracker++;
            collectText.text = "Go back Inside and Breed your flower!";
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<PlayerBehaviour>().goneOutside == true && runOnce == false)
        {
            runOnce = true;
            collectText.text = "Collect your first petal gene!";
        }
    }

}
