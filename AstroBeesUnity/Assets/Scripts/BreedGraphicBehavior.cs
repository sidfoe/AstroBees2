using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class BreedGraphicBehavior : MonoBehaviour
{
    public bool manualStart = false;
    private int counter = 0;
    private bool start = false;

    private int traitCounter = 0;
    private bool traitsInPlace = false;
    private bool traitsSplit = false;

    public Image topLeftImage;
    public Image topRightImage;
    public Image botLeftImage;
    public Image botRightImage;

    private PodBehavior pod1Behavior;
    private PodBehavior pod2Behavior;
    private PodBehavior pod3Behavior;
    private PodBehavior pod4Behavior;
    private PodBehavior pod5Behavior;
    private PodBehavior pod6Behavior;

    [Header("Petal Sprites")]
    public Sprite petal1;
    public Sprite petal2;
    public Sprite petal3;
    public Sprite petal4;
    public Sprite petal5;
    public Sprite petal6;

    [Header("Stem Sprites")]
    public Sprite stem1;
    public Sprite stem2;
    public Sprite stem3;
    public Sprite stem4;
    public Sprite stem5;
    public Sprite stem6;
    
    [Header("Thorn Sprites")]
    public Sprite thorn1;
    public Sprite thorn2;
    public Sprite thorn3;
    public Sprite thorn4;
    public Sprite thorn5;
    public Sprite thorn6;

    private int[,] crossTraits = new int [2,2];
    private int tabTrait1 = 0;
    private int tabTrait2 = 0;
    private int tabTrait3 = 0;
    private int tabTrait4 = 0;

    [Header("Table Trait Objects")]
    public GameObject tableTrait1;
    public GameObject tableTrait2;
    public GameObject tableTrait3;
    public GameObject tableTrait4;


    
    private int graphicCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        pod1Behavior = GameObject.Find("Pod1").GetComponent<PodBehavior>();
        pod2Behavior = GameObject.Find("Pod2").GetComponent<PodBehavior>();
        pod3Behavior = GameObject.Find("Pod3").GetComponent<PodBehavior>();
        pod4Behavior = GameObject.Find("Pod4").GetComponent<PodBehavior>();
        pod5Behavior = GameObject.Find("Pod5").GetComponent<PodBehavior>();
        pod6Behavior = GameObject.Find("Pod6").GetComponent<PodBehavior>();
        ChangeTraits();   
    }

    // Update is called once per frame
    void Update()
    {
        if (manualStart && counter == 0)
        {
            counter++;
            StartGraphic();
        }
        
    }

    public void StartGraphic()
    {
        SplitTraits();
        gameObject.SetActive(true);
        graphicCounter = 0;
        traitsInPlace = false;
        traitsSplit = false;        
    }

    void StartCoreGraphic()
    {
        StartCoroutine(PlayGraphic());
    }

    IEnumerator PlayGraphic()
    {
        //if (!traitsSplit)
       // {
         //   SplitTraits();
         //   traitsSplit = true;
        //}
        //while (!traitsInPlace)
        //{

        //    yield return 0;
        //}
        while (graphicCounter < 8)
        {
            graphicCounter++;
            ChangeSquare();
            yield return new WaitForSeconds(.25f);
        }
        ChangeTraits();
        traitCounter++;
        yield break;
    }

    void ChangeSquare()
    {
        int rand = Random.Range(0, 4);
        switch (rand)
        {
            case 0:
                topLeftImage.color = Color.red;
                topRightImage.color = Color.clear;
                botLeftImage.color = Color.clear;
                botRightImage.color = Color.clear;
                break;
            case 1:
                topLeftImage.color = Color.clear;
                topRightImage.color = Color.red;
                botLeftImage.color = Color.clear;
                botRightImage.color = Color.clear;
                break;
            case 2:
                topLeftImage.color = Color.clear;
                topRightImage.color = Color.clear;
                botLeftImage.color = Color.red;
                botRightImage.color = Color.clear;
                break;
            case 3:
                topLeftImage.color = Color.clear;
                topRightImage.color = Color.clear;
                botLeftImage.color = Color.clear;
                botRightImage.color = Color.red;
                break;
        }
    }
    void ChangeTraits()
    {
        //petals
        if (traitCounter == 0)
        {

        }
    }
    void SplitTraits()
    {
        print("Splitting traits");
        int trait1 = 0;
        int trait2 = 0;
        if (traitCounter == 0)
        {
            trait1 = pod1Behavior.trait;
            trait2 = pod2Behavior.trait;
        }
        else if (traitCounter == 1)
        {
            trait1 = pod3Behavior.trait;
            trait2 = pod4Behavior.trait;
        }
        else if (traitCounter == 2)
        {
            trait1 = pod5Behavior.trait;
            trait2 = pod6Behavior.trait;
        }

        // above graphic
        if (trait1 == 1)
        {
            crossTraits[0, 0] = 1;
            crossTraits[1, 0] = 1;
        }
        else if (trait1 == 2)
        {
            crossTraits[0, 0] = 2;
            crossTraits[1, 0] = 2;
        }
        else if (trait1 == 3)
        {
            crossTraits[0, 0] = 3;
            crossTraits[1, 0] = 3;
        }
        else if (trait1 == 4)
        {
            crossTraits[0, 0] = 1;
            crossTraits[1, 0] = 2;
        }
        else if (trait1 == 5)
        {
            crossTraits[0, 0] = 1;
            crossTraits[1, 0] = 3;
        }
        else if (trait1 == 6)
        {
            crossTraits[0, 0] = 2;
            crossTraits[1, 0] = 3;
        }

        // left side of graphic
        if (trait2 == 1)
        {
            crossTraits[0, 1] = 1;
            crossTraits[1, 1] = 1;
        }
        else if (trait2 == 2)
        {
            crossTraits[0, 1] = 2;
            crossTraits[1, 1] = 2;
        }
        else if (trait2 == 3)
        {
            crossTraits[0, 1] = 3;
            crossTraits[1, 1] = 3;
        }
        else if (trait2 == 4)
        {
            crossTraits[0, 1] = 1;
            crossTraits[1, 1] = 2;
        }
        else if (trait2 == 5)
        {
            crossTraits[0, 1] = 1;
            crossTraits[1, 1] = 3;
        }
        else if (trait2 == 6)
        {
            crossTraits[0, 1] = 2;
            crossTraits[1, 1] = 3;
        }

        CreateTable();
    }

    void CreateTable()
    {
        print("creating");
        // LEFT SIDE
        if (crossTraits[0, 0] == 1)
        {
            // top left
            if (crossTraits[0, 1] == 1)
            {
                tabTrait1 = 1;
            }
            else if (crossTraits[0, 1] == 2)
            {
                tabTrait1 = 4;
            }
            else if (crossTraits[0, 1] == 3)
            {
                tabTrait1 = 5;
            }

            // bot left
            if (crossTraits[1, 1] == 1)
            {
                tabTrait3 = 1;
            }
            else if (crossTraits[1, 1] == 2)
            {
                tabTrait3 = 4;
            }
            else if (crossTraits[1, 1] == 3)
            {
                tabTrait3 = 5;
            }
        }
        else if (crossTraits[0, 0] == 2)
        {
            // top left
            if (crossTraits[0, 1] == 1)
            {
                tabTrait1 = 4;
            }
            else if (crossTraits[0, 1] == 2)
            {
                tabTrait1 = 2;
            }
            else if (crossTraits[0, 1] == 3)
            {
                tabTrait1 = 6;
            }

            // bot left
            if (crossTraits[1, 1] == 1)
            {
                tabTrait3 = 4;
            }
            else if (crossTraits[1, 1] == 2)
            {
                tabTrait3 = 2;
            }
            else if (crossTraits[1, 1] == 3)
            {
                tabTrait3 = 6;
            }
        }
        else if (crossTraits[0, 0] == 3)
        {
            // top left
            if (crossTraits[0, 1] == 1)
            {
                tabTrait1 = 5;
            }
            else if (crossTraits[0, 1] == 2)
            {
                tabTrait1 = 6;
            }
            else if (crossTraits[0, 1] == 3)
            {
                tabTrait1 = 3;
            }

            // bot left
            if (crossTraits[1, 1] == 1)
            {
                tabTrait3 = 5;
            }
            else if (crossTraits[1, 1] == 2)
            {
                tabTrait3 = 6;
            }
            else if (crossTraits[1, 1] == 3)
            {
                tabTrait1 = 3;
            }
        }

        // RIGHT SIDE
        if (crossTraits[1, 0] == 1)
        {
            // top right
            if (crossTraits[0, 1] == 1)
            {
                tabTrait2 = 1;
            }
            else if (crossTraits[0, 1] == 2)
            {
                tabTrait2 = 4;
            }
            else if (crossTraits[0, 1] == 3)
            {
                tabTrait2 = 5;
            }

            // bot right
            if (crossTraits[1, 1] == 1)
            {
                tabTrait4 = 1;
            }
            else if (crossTraits[1, 1] == 2)
            {
                tabTrait4 = 4;
            }
            else if (crossTraits[1, 1] == 3)
            {
                tabTrait4 = 5;
            }
        }
        else if (crossTraits[1, 0] == 2)
        {
            // top right
            if (crossTraits[0, 1] == 1)
            {
                tabTrait2 = 4;
            }
            else if (crossTraits[0, 1] == 2)
            {
                tabTrait2 = 2;
            }
            else if (crossTraits[0, 1] == 3)
            {
                tabTrait2 = 6;
            }

            // bot right
            if (crossTraits[1, 1] == 1)
            {
                tabTrait4 = 4;
            }
            else if (crossTraits[1, 1] == 2)
            {
                tabTrait4 = 2;
            }
            else if (crossTraits[1, 1] == 3)
            {
                tabTrait4 = 6;
            }
        }
        else if (crossTraits[1, 0] == 3)
        {
            // top right
            if (crossTraits[0, 1] == 1)
            {
                tabTrait2 = 5;
            }
            else if (crossTraits[0, 1] == 2)
            {
                tabTrait2 = 6;
            }
            else if (crossTraits[0, 1] == 3)
            {
                tabTrait2 = 3;
            }

            // bot right
            if (crossTraits[1, 1] == 1)
            {
                tabTrait4 = 5;
            }
            else if (crossTraits[1, 1] == 2)
            {
                tabTrait4 = 6;
            }
            else if (crossTraits[1, 1] == 3)
            {
                tabTrait4 = 3;
            }
        }

        FillTable();
    }

    void FillTable()
    {
        if (traitCounter == 0)
        {
            switch (tabTrait1)
            {              
                case 1:
                    tableTrait1.GetComponent<SpriteRenderer>().sprite = petal1;
                    print("petal1");
                    break;
                case 2:
                    tableTrait1.GetComponent<SpriteRenderer>().sprite = petal2;
                    print("petal2");
                    break;
                case 3:
                    tableTrait1.GetComponent<SpriteRenderer>().sprite = petal3;
                    print("petal3");
                    break;
                case 4:
                    tableTrait1.GetComponent<SpriteRenderer>().sprite = petal4;
                    print("petal4");
                    break;
                case 5:
                    tableTrait1.GetComponent<SpriteRenderer>().sprite = petal5;
                    print("petal5");
                    break;
                case 6:
                    tableTrait1.GetComponent<SpriteRenderer>().sprite = petal6;
                    print("petal6");
                    break;

            }
            tableTrait1.SetActive(true);
            switch (tabTrait2)
            {
                case 1:
                    tableTrait2.GetComponent<SpriteRenderer>().sprite = petal1;
                    break;
                case 2:
                    tableTrait2.GetComponent<SpriteRenderer>().sprite = petal2;
                    break;
                case 3:
                    tableTrait2.GetComponent<SpriteRenderer>().sprite = petal3;
                    break;
                case 4:
                    tableTrait2.GetComponent<SpriteRenderer>().sprite = petal4;
                    break;
                case 5:
                    tableTrait2.GetComponent<SpriteRenderer>().sprite = petal5;
                    break;
                case 6:
                    tableTrait2.GetComponent<SpriteRenderer>().sprite = petal6;
                    break;

            }
            tableTrait2.SetActive(true);
            switch (tabTrait3)
            {
                case 1:
                    tableTrait3.GetComponent<SpriteRenderer>().sprite = petal1;
                    break;
                case 2:
                    tableTrait3.GetComponent<SpriteRenderer>().sprite = petal2;
                    break;
                case 3:
                    tableTrait3.GetComponent<SpriteRenderer>().sprite = petal3;
                    break;
                case 4:
                    tableTrait3.GetComponent<SpriteRenderer>().sprite = petal4;
                    break;
                case 5:
                    tableTrait3.GetComponent<SpriteRenderer>().sprite = petal5;
                    break;
                case 6:
                    tableTrait3.GetComponent<SpriteRenderer>().sprite = petal6;
                    break;

            }
            tableTrait3.SetActive(true);
            switch (tabTrait4)
            {
                case 1:
                    tableTrait4.GetComponent<SpriteRenderer>().sprite = petal1;
                    break;
                case 2:
                    tableTrait4.GetComponent<SpriteRenderer>().sprite = petal2;
                    break;
                case 3:
                    tableTrait4.GetComponent<SpriteRenderer>().sprite = petal3;
                    break;
                case 4:
                    tableTrait4.GetComponent<SpriteRenderer>().sprite = petal4;
                    break;
                case 5:
                    tableTrait4.GetComponent<SpriteRenderer>().sprite = petal5;
                    break;
                case 6:
                    tableTrait4.GetComponent<SpriteRenderer>().sprite = petal6;
                    break;

            }
            tableTrait4.SetActive(true);
        }
        else if (traitCounter == 1)
        {
            switch (tabTrait1)
            {
                case 1:
                    tableTrait1.GetComponent<SpriteRenderer>().sprite = stem1;
                    break;
                case 2:
                    tableTrait1.GetComponent<SpriteRenderer>().sprite = stem2;
                    break;
                case 3:
                    tableTrait1.GetComponent<SpriteRenderer>().sprite = stem3;
                    break;
                case 4:
                    tableTrait1.GetComponent<SpriteRenderer>().sprite = stem4;
                    break;
                case 5:
                    tableTrait1.GetComponent<SpriteRenderer>().sprite = stem5;
                    break;
                case 6:
                    tableTrait1.GetComponent<SpriteRenderer>().sprite = stem6;
                    break;

            }
            switch (tabTrait2)
            {
                case 1:
                    tableTrait2.GetComponent<SpriteRenderer>().sprite = stem1;
                    break;
                case 2:
                    tableTrait2.GetComponent<SpriteRenderer>().sprite = stem2;
                    break;
                case 3:
                    tableTrait2.GetComponent<SpriteRenderer>().sprite = stem3;
                    break;
                case 4:
                    tableTrait2.GetComponent<SpriteRenderer>().sprite = stem4;
                    break;
                case 5:
                    tableTrait2.GetComponent<SpriteRenderer>().sprite = stem5;
                    break;
                case 6:
                    tableTrait2.GetComponent<SpriteRenderer>().sprite = stem6;
                    break;

            }
            switch (tabTrait3)
            {
                case 1:
                    tableTrait3.GetComponent<SpriteRenderer>().sprite = stem1;
                    break;
                case 2:
                    tableTrait3.GetComponent<SpriteRenderer>().sprite = stem2;
                    break;
                case 3:
                    tableTrait3.GetComponent<SpriteRenderer>().sprite = stem3;
                    break;
                case 4:
                    tableTrait3.GetComponent<SpriteRenderer>().sprite = stem4;
                    break;
                case 5:
                    tableTrait3.GetComponent<SpriteRenderer>().sprite = stem5;
                    break;
                case 6:
                    tableTrait3.GetComponent<SpriteRenderer>().sprite = stem6;
                    break;

            }
            switch (tabTrait4)
            {
                case 1:
                    tableTrait4.GetComponent<SpriteRenderer>().sprite = stem1;
                    break;
                case 2:
                    tableTrait4.GetComponent<SpriteRenderer>().sprite = stem2;
                    break;
                case 3:
                    tableTrait4.GetComponent<SpriteRenderer>().sprite = stem3;
                    break;
                case 4:
                    tableTrait4.GetComponent<SpriteRenderer>().sprite = stem4;
                    break;
                case 5:
                    tableTrait4.GetComponent<SpriteRenderer>().sprite = stem5;
                    break;
                case 6:
                    tableTrait4.GetComponent<SpriteRenderer>().sprite = stem6;
                    break;

            }
        }
        else if (traitCounter == 2)
        {
            switch (tabTrait1)
            {
                case 1:
                    tableTrait1.GetComponent<SpriteRenderer>().sprite = thorn1;
                    break;
                case 2:
                    tableTrait1.GetComponent<SpriteRenderer>().sprite = thorn2;
                    break;
                case 3:
                    tableTrait1.GetComponent<SpriteRenderer>().sprite = thorn3;
                    break;
                case 4:
                    tableTrait1.GetComponent<SpriteRenderer>().sprite = thorn4;
                    break;
                case 5:
                    tableTrait1.GetComponent<SpriteRenderer>().sprite = thorn5;
                    break;
                case 6:
                    tableTrait1.GetComponent<SpriteRenderer>().sprite = thorn6;
                    break;

            }
            switch (tabTrait2)
            {
                case 1:
                    tableTrait2.GetComponent<SpriteRenderer>().sprite = thorn1;
                    break;
                case 2:
                    tableTrait2.GetComponent<SpriteRenderer>().sprite = thorn2;
                    break;
                case 3:
                    tableTrait2.GetComponent<SpriteRenderer>().sprite = thorn3;
                    break;
                case 4:
                    tableTrait2.GetComponent<SpriteRenderer>().sprite = thorn4;
                    break;
                case 5:
                    tableTrait2.GetComponent<SpriteRenderer>().sprite = thorn5;
                    break;
                case 6:
                    tableTrait2.GetComponent<SpriteRenderer>().sprite = thorn6;
                    break;

            }
            switch (tabTrait3)
            {
                case 1:
                    tableTrait3.GetComponent<SpriteRenderer>().sprite = thorn1;
                    break;
                case 2:
                    tableTrait3.GetComponent<SpriteRenderer>().sprite = thorn2;
                    break;
                case 3:
                    tableTrait3.GetComponent<SpriteRenderer>().sprite = thorn3;
                    break;
                case 4:
                    tableTrait3.GetComponent<SpriteRenderer>().sprite = thorn4;
                    break;
                case 5:
                    tableTrait3.GetComponent<SpriteRenderer>().sprite = thorn5;
                    break;
                case 6:
                    tableTrait3.GetComponent<SpriteRenderer>().sprite = thorn6;
                    break;

            }
            switch (tabTrait4)
            {
                case 1:
                    tableTrait4.GetComponent<SpriteRenderer>().sprite = thorn1;
                    break;
                case 2:
                    tableTrait4.GetComponent<SpriteRenderer>().sprite = thorn2;
                    break;
                case 3:
                    tableTrait4.GetComponent<SpriteRenderer>().sprite = thorn3;
                    break;
                case 4:
                    tableTrait4.GetComponent<SpriteRenderer>().sprite = thorn4;
                    break;
                case 5:
                    tableTrait4.GetComponent<SpriteRenderer>().sprite = thorn5;
                    break;
                case 6:
                    tableTrait4.GetComponent<SpriteRenderer>().sprite = thorn6;
                    break;

            }
            
        }

        StartCoreGraphic();
    }
}
