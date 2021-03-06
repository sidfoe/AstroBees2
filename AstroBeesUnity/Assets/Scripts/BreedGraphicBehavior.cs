﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class BreedGraphicBehavior : MonoBehaviour
{

    private Color32 chosen = new Color32(255, 0, 0, 100);
    public bool manualStart = false;
    private int counter = 0;
    //private bool start = false;
    public float moveTime;
    private int traitCounter = 0;
    //private bool traitsInPlace = false;
    //private bool traitsSplit = false;

    private BreedingTableBehavior btb;

    public GameObject tableTraits;
    public Text collectText;
    public GameObject graphicPanel;
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

    private CrossTraitMovement crossObj00Movement;
    private CrossTraitMovement crossObj01Movement;
    private CrossTraitMovement crossObj10Movement;
    private CrossTraitMovement crossObj11Movement;

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
    private int tableTrait1 = 0;
    private int tableTrait2 = 0;
    private int tableTrait3 = 0;
    private int tableTrait4 = 0;

    [Header("Table Trait Objects")]
    public GameObject tableTraitObj1;
    public GameObject tableTraitObj2;
    public GameObject tableTraitObj3;
    public GameObject tableTraitObj4;

    [Header("Table Cross Trait Objects")]
    public GameObject crossObj00;
    public GameObject crossObj01;
    public GameObject crossObj10;
    public GameObject crossObj11;

    [Header("Table Cross Trait Start/End Pos")]
    public Vector3 crossObj00Start1;
    public Vector3 crossObj00Start2;
    public Vector3 crossObj00Start3;
    public Vector3 crossObj00End;

    public Vector3 crossObj01Start1;
    public Vector3 crossObj01Start2;
    public Vector3 crossObj01Start3;
    public Vector3 crossObj01End;

    public Vector3 crossObj10Start1;
    public Vector3 crossObj10Start2;
    public Vector3 crossObj10Start3;
    public Vector3 crossObj10End;

    public Vector3 crossObj11Start1;
    public Vector3 crossObj11Start2;
    public Vector3 crossObj11Start3;
    public Vector3 crossObj11End;


    private int outputPetal;
    private int outputStem;
    private int outputThorn;
    private int currentTraitOutput;

    private int lastChosen = 0;
    private int finalTraitNum = -1;
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


        crossObj00Movement = crossObj00.GetComponent<CrossTraitMovement>();
        crossObj01Movement = crossObj01.GetComponent<CrossTraitMovement>();
        crossObj10Movement = crossObj10.GetComponent<CrossTraitMovement>();
        crossObj11Movement = crossObj11.GetComponent<CrossTraitMovement>();

        btb = GameObject.Find("Breeding Table").GetComponent<BreedingTableBehavior>();
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

    public void StartGraphic(int finalPetal, int finalStem, int finalThorn)
    {
        collectText.color = Color.clear;
        graphicPanel.SetActive(true);
        outputPetal = finalPetal;
        outputStem = finalStem;
        outputThorn = finalThorn;
        SplitTraits();
        gameObject.SetActive(true);
        graphicCounter = 0;
        //traitsInPlace = false;
        //traitsSplit = false;        
    }
    public void StartGraphic()
    {
        collectText.color = Color.clear;
        //graphicPanel.SetActive(true);
        SplitTraits();
        gameObject.SetActive(true);
        graphicCounter = 0;
        //traitsInPlace = false;
        //traitsSplit = false;
    }
    void StartCoreGraphic()
    {
        StartCoroutine(PlayGraphic());
    }

    IEnumerator PlayGraphic()
    {
        float waitTime = .5f;
        while (graphicCounter < 10)
        {
            graphicCounter++;
            ChangeSquare();
            waitTime -= graphicCounter * .006f;
            yield return new WaitForSeconds(waitTime);
        }
        if (graphicCounter == 10)
        {
            finalTraitNum = FindCorrectTrait();
            ShowFinalTrait(finalTraitNum);
            graphicCounter++;
            yield return new WaitForSeconds(3f);
        }
        traitCounter++;
        if (traitCounter < 3)
        {
            waitTime = .5f;
            graphicCounter = 0;
            CleanUp();
        }
        else
        {
            btb.SpawnFinalFlower();
            gameObject.SetActive(false);
            tableTraits.SetActive(false);
        }
        yield break;
    }

    void ChangeSquare()
    {
        int rand = Random.Range(1, 5);
        while (rand == lastChosen)
        {
            rand = Random.Range(1, 5);
        }
        switch (rand)
        {
            case 1:
                topLeftImage.color = chosen;
                topRightImage.color = Color.clear;
                botLeftImage.color = Color.clear;
                botRightImage.color = Color.clear;
                break;
            case 2:
                topLeftImage.color = Color.clear;
                topRightImage.color = chosen;
                botLeftImage.color = Color.clear;
                botRightImage.color = Color.clear;
                break;
            case 3:
                topLeftImage.color = Color.clear;
                topRightImage.color = Color.clear;
                botLeftImage.color = chosen;
                botRightImage.color = Color.clear;
                break;
            case 4:
                topLeftImage.color = Color.clear;
                topRightImage.color = Color.clear;
                botLeftImage.color = Color.clear;
                botRightImage.color = chosen;
                break;
        }
        //print("trait num: " +  traitCounter +"change number: " + graphicCounter);
        lastChosen = rand;
    }

    void ShowFinalTrait(int traitNum)
    {
        print("Showing Final");
        switch (traitNum)
        {
            case 1:
                topLeftImage.color = chosen;
                topRightImage.color = Color.clear;
                botLeftImage.color = Color.clear;
                botRightImage.color = Color.clear;
                break;
            case 2:
                topLeftImage.color = Color.clear;
                topRightImage.color = chosen;
                botLeftImage.color = Color.clear;
                botRightImage.color = Color.clear;
                break;
            case 3:
                topLeftImage.color = Color.clear;
                topRightImage.color = Color.clear;
                botLeftImage.color = chosen;
                botRightImage.color = Color.clear;
                break;
            case 4:
                topLeftImage.color = Color.clear;
                topRightImage.color = Color.clear;
                botLeftImage.color = Color.clear;
                botRightImage.color = chosen;
                break;
        }
    }
    void StartNextTrait()
    {
        print("Starting Next");
        graphicCounter++;
    }
    int FindCorrectTrait()
    {
        if (traitCounter == 0)
        {
            currentTraitOutput = outputPetal;
        }
        else if (traitCounter == 1)
        {
            currentTraitOutput = outputStem;
        }
        else if (traitCounter == 2)
        {
            currentTraitOutput = outputThorn;
        }
        if (tableTrait1 == currentTraitOutput)
        {
            return 1;
        }
        else if (tableTrait2 == currentTraitOutput)
        {
            return 2;
        }
        else if (tableTrait3 == currentTraitOutput)
        {
            return 3;
        }
        else if (tableTrait3 == currentTraitOutput)
        {
            return 4;
        }
        else
        {
            return -1;
        }
    }
    void ChangeTraits()
    {
        
    }
    void SplitTraits()
    {
        int trait1 = 0;
        int trait2 = 0;
        if (traitCounter == 0)
        {
            trait1 = pod1Behavior.trait;
            trait2 = pod2Behavior.trait;
            crossObj00.transform.position = crossObj00Start1;
            crossObj01.transform.position = crossObj01Start1;
            crossObj10.transform.position = crossObj10Start1;
            crossObj11.transform.position = crossObj11Start1;
        }
        else if (traitCounter == 1)
        {
            trait1 = pod3Behavior.trait;
            trait2 = pod4Behavior.trait;
            crossObj00.transform.position = crossObj00Start2;
            crossObj01.transform.position = crossObj01Start2;
            crossObj10.transform.position = crossObj10Start2;
            crossObj11.transform.position = crossObj11Start2;


        }
        else if (traitCounter == 2)
        {
            trait1 = pod5Behavior.trait;
            trait2 = pod6Behavior.trait;
            crossObj00.transform.position = crossObj00Start3;
            crossObj01.transform.position = crossObj01Start3;
            crossObj10.transform.position = crossObj10Start3;
            crossObj11.transform.position = crossObj11Start3;

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

        if (traitCounter == 0)
        {
            // CROSS TRAITS
            switch (crossTraits[0, 0])
            {
                case 1:
                    crossObj00.GetComponent<SpriteRenderer>().sprite = petal1;
                    break;
                case 2:
                    crossObj00.GetComponent<SpriteRenderer>().sprite = petal2;
                    break;
                case 3:
                    crossObj00.GetComponent<SpriteRenderer>().sprite = petal3;
                    break;
                case 4:
                    crossObj00.GetComponent<SpriteRenderer>().sprite = petal4;
                    break;
                case 5:
                    crossObj00.GetComponent<SpriteRenderer>().sprite = petal5;
                    break;
                case 6:
                    crossObj00.GetComponent<SpriteRenderer>().sprite = petal6;
                    break;

            }
            //print("Cross00 = " + crossTraits[0, 0]);
            crossObj00.SetActive(true);
            switch (crossTraits[0, 1])
            {
                case 1:
                    crossObj01.GetComponent<SpriteRenderer>().sprite = petal1;
                    break;
                case 2:
                    crossObj01.GetComponent<SpriteRenderer>().sprite = petal2;
                    break;
                case 3:
                    crossObj01.GetComponent<SpriteRenderer>().sprite = petal3;
                    break;
                case 4:
                    crossObj01.GetComponent<SpriteRenderer>().sprite = petal4;
                    break;
                case 5:
                    crossObj01.GetComponent<SpriteRenderer>().sprite = petal5;
                    break;
                case 6:
                    crossObj01.GetComponent<SpriteRenderer>().sprite = petal6;
                    break;

            }
            //print("Cross01 = " + crossTraits[0, 1]);
            crossObj01.SetActive(true);
            switch (crossTraits[1, 0])
            {
                case 1:
                    crossObj10.GetComponent<SpriteRenderer>().sprite = petal1;
                    break;
                case 2:
                    crossObj10.GetComponent<SpriteRenderer>().sprite = petal2;
                    break;
                case 3:
                    crossObj10.GetComponent<SpriteRenderer>().sprite = petal3;
                    break;
                case 4:
                    crossObj10.GetComponent<SpriteRenderer>().sprite = petal4;
                    break;
                case 5:
                    crossObj10.GetComponent<SpriteRenderer>().sprite = petal5;
                    break;
                case 6:
                    crossObj10.GetComponent<SpriteRenderer>().sprite = petal6;
                    break;

            }
            //print("Cross10 = " + crossTraits[1, 0]);
            crossObj10.SetActive(true);
            switch (crossTraits[1, 1])
            {
                case 1:
                    crossObj11.GetComponent<SpriteRenderer>().sprite = petal1;
                    break;
                case 2:
                    crossObj11.GetComponent<SpriteRenderer>().sprite = petal2;
                    break;
                case 3:
                    crossObj11.GetComponent<SpriteRenderer>().sprite = petal3;
                    break;
                case 4:
                    crossObj11.GetComponent<SpriteRenderer>().sprite = petal4;
                    break;
                case 5:
                    crossObj11.GetComponent<SpriteRenderer>().sprite = petal5;
                    break;
                case 6:
                    crossObj11.GetComponent<SpriteRenderer>().sprite = petal6;
                    break;

            }
            //print("Cross11 = " + crossTraits[1, 1]);
            crossObj11.SetActive(true);
        }
        else if (traitCounter == 1)
        {
            // CROSS TRAITS
            switch (crossTraits[0, 0])
            {
                case 1:
                    crossObj00.GetComponent<SpriteRenderer>().sprite = stem1;
                    break;
                case 2:
                    crossObj00.GetComponent<SpriteRenderer>().sprite = stem2;
                    break;
                case 3:
                    crossObj00.GetComponent<SpriteRenderer>().sprite = stem3;
                    break;
                case 4:
                    crossObj00.GetComponent<SpriteRenderer>().sprite = stem4;
                    break;
                case 5:
                    crossObj00.GetComponent<SpriteRenderer>().sprite = stem5;
                    break;
                case 6:
                    crossObj00.GetComponent<SpriteRenderer>().sprite = stem6;
                    break;

            }
            crossObj00.SetActive(true);
            switch (crossTraits[0, 1])
            {
                case 1:
                    crossObj01.GetComponent<SpriteRenderer>().sprite = stem1;
                    break;
                case 2:
                    crossObj01.GetComponent<SpriteRenderer>().sprite = stem2;
                    break;
                case 3:
                    crossObj01.GetComponent<SpriteRenderer>().sprite = stem3;
                    break;
                case 4:
                    crossObj01.GetComponent<SpriteRenderer>().sprite = stem4;
                    break;
                case 5:
                    crossObj01.GetComponent<SpriteRenderer>().sprite = stem5;
                    break;
                case 6:
                    crossObj01.GetComponent<SpriteRenderer>().sprite = stem6;
                    break;

            }
            crossObj01.SetActive(true);
            switch (crossTraits[1, 0])
            {
                case 1:
                    crossObj10.GetComponent<SpriteRenderer>().sprite = stem1;
                    break;
                case 2:
                    crossObj10.GetComponent<SpriteRenderer>().sprite = stem2;
                    break;
                case 3:
                    crossObj10.GetComponent<SpriteRenderer>().sprite = stem3;
                    break;
                case 4:
                    crossObj10.GetComponent<SpriteRenderer>().sprite = stem4;
                    break;
                case 5:
                    crossObj10.GetComponent<SpriteRenderer>().sprite = stem5;
                    break;
                case 6:
                    crossObj10.GetComponent<SpriteRenderer>().sprite = stem6;
                    break;

            }
            crossObj10.SetActive(true);
            switch (crossTraits[1, 1])
            {
                case 1:
                    crossObj11.GetComponent<SpriteRenderer>().sprite = stem1;
                    break;
                case 2:
                    crossObj11.GetComponent<SpriteRenderer>().sprite = stem2;
                    break;
                case 3:
                    crossObj11.GetComponent<SpriteRenderer>().sprite = stem3;
                    break;
                case 4:
                    crossObj11.GetComponent<SpriteRenderer>().sprite = stem4;
                    break;
                case 5:
                    crossObj11.GetComponent<SpriteRenderer>().sprite = stem5;
                    break;
                case 6:
                    crossObj11.GetComponent<SpriteRenderer>().sprite = stem6;
                    break;

            }
            crossObj11.SetActive(true);
        }
        else if (traitCounter == 2)
        {
            // CROSS TRAITS
            switch (crossTraits[0, 0])
            {
                case 1:
                    crossObj00.GetComponent<SpriteRenderer>().sprite = thorn1;
                    break;
                case 2:
                    crossObj00.GetComponent<SpriteRenderer>().sprite = thorn2;
                    break;
                case 3:
                    crossObj00.GetComponent<SpriteRenderer>().sprite = thorn3;
                    break;
                case 4:
                    crossObj00.GetComponent<SpriteRenderer>().sprite = thorn4;
                    break;
                case 5:
                    crossObj00.GetComponent<SpriteRenderer>().sprite = thorn5;
                    break;
                case 6:
                    crossObj00.GetComponent<SpriteRenderer>().sprite = thorn6;
                    break;

            }
            crossObj00.SetActive(true);
            switch (crossTraits[0, 1])
            {
                case 1:
                    crossObj01.GetComponent<SpriteRenderer>().sprite = thorn1;
                    break;
                case 2:
                    crossObj01.GetComponent<SpriteRenderer>().sprite = thorn2;
                    break;
                case 3:
                    crossObj01.GetComponent<SpriteRenderer>().sprite = thorn3;
                    break;
                case 4:
                    crossObj01.GetComponent<SpriteRenderer>().sprite = thorn4;
                    break;
                case 5:
                    crossObj01.GetComponent<SpriteRenderer>().sprite = thorn5;
                    break;
                case 6:
                    crossObj01.GetComponent<SpriteRenderer>().sprite = thorn6;
                    break;

            }
            crossObj01.SetActive(true);
            switch (crossTraits[1, 0])
            {
                case 1:
                    crossObj10.GetComponent<SpriteRenderer>().sprite = thorn1;
                    break;
                case 2:
                    crossObj10.GetComponent<SpriteRenderer>().sprite = thorn2;
                    break;
                case 3:
                    crossObj10.GetComponent<SpriteRenderer>().sprite = thorn3;
                    break;
                case 4:
                    crossObj10.GetComponent<SpriteRenderer>().sprite = thorn4;
                    break;
                case 5:
                    crossObj10.GetComponent<SpriteRenderer>().sprite = thorn5;
                    break;
                case 6:
                    crossObj10.GetComponent<SpriteRenderer>().sprite = thorn6;
                    break;

            }
            crossObj10.SetActive(true);
            switch (crossTraits[1, 1])
            {
                case 1:
                    crossObj11.GetComponent<SpriteRenderer>().sprite = thorn1;
                    break;
                case 2:
                    crossObj11.GetComponent<SpriteRenderer>().sprite = thorn2;
                    break;
                case 3:
                    crossObj11.GetComponent<SpriteRenderer>().sprite = thorn3;
                    break;
                case 4:
                    crossObj11.GetComponent<SpriteRenderer>().sprite = thorn4;
                    break;
                case 5:
                    crossObj11.GetComponent<SpriteRenderer>().sprite = thorn5;
                    break;
                case 6:
                    crossObj11.GetComponent<SpriteRenderer>().sprite = thorn6;
                    break;

            }
            crossObj11.SetActive(true);
        }
        StartLERP();
        //CreateTable();
    }

    void StartLERP()
    {
        // script to make cross objects move
        crossObj00Movement.StartMovement(crossObj00.transform.position, crossObj00End);
        crossObj01Movement.StartMovement(crossObj01.transform.position, crossObj01End);
        crossObj10Movement.StartMovement(crossObj10.transform.position, crossObj10End);
        crossObj11Movement.StartMovement(crossObj11.transform.position, crossObj11End);

        Invoke("CreateTable", moveTime);
    }
    void CreateTable()
    {
        graphicPanel.SetActive(true);
        // LEFT SIDE
        if (crossTraits[0, 0] == 1)
        {
            // top left
            if (crossTraits[0, 1] == 1)
            {
                tableTrait1 = 1;
            }
            else if (crossTraits[0, 1] == 2)
            {
                tableTrait1 = 4;
            }
            else if (crossTraits[0, 1] == 3)
            {
                tableTrait1 = 5;
            }

            // bot left
            if (crossTraits[1, 1] == 1)
            {
                tableTrait3 = 1;
            }
            else if (crossTraits[1, 1] == 2)
            {
                tableTrait3 = 4;
            }
            else if (crossTraits[1, 1] == 3)
            {
                tableTrait3 = 5;
            }
        }
        else if (crossTraits[0, 0] == 2)
        {
            // top left
            if (crossTraits[0, 1] == 1)
            {
                tableTrait1 = 4;
            }
            else if (crossTraits[0, 1] == 2)
            {
                tableTrait1 = 2;
            }
            else if (crossTraits[0, 1] == 3)
            {
                tableTrait1 = 6;
            }

            // bot left
            if (crossTraits[1, 1] == 1)
            {
                tableTrait3 = 4;
            }
            else if (crossTraits[1, 1] == 2)
            {
                tableTrait3 = 2;
            }
            else if (crossTraits[1, 1] == 3)
            {
                tableTrait3 = 6;
            }
        }
        else if (crossTraits[0, 0] == 3)
        {
            // top left
            if (crossTraits[0, 1] == 1)
            {
                tableTrait1 = 5;
            }
            else if (crossTraits[0, 1] == 2)
            {
                tableTrait1 = 6;
            }
            else if (crossTraits[0, 1] == 3)
            {
                tableTrait1 = 3;
            }

            // bot left
            if (crossTraits[1, 1] == 1)
            {
                tableTrait3 = 5;
            }
            else if (crossTraits[1, 1] == 2)
            {
                tableTrait3 = 6;
            }
            else if (crossTraits[1, 1] == 3)
            {
                tableTrait1 = 3;
            }
        }

        // RIGHT SIDE
        if (crossTraits[1, 0] == 1)
        {
            // top right
            if (crossTraits[0, 1] == 1)
            {
                tableTrait2 = 1;
            }
            else if (crossTraits[0, 1] == 2)
            {
                tableTrait2 = 4;
            }
            else if (crossTraits[0, 1] == 3)
            {
                tableTrait2 = 5;
            }

            // bot right
            if (crossTraits[1, 1] == 1)
            {
                tableTrait4 = 1;
            }
            else if (crossTraits[1, 1] == 2)
            {
                tableTrait4 = 4;
            }
            else if (crossTraits[1, 1] == 3)
            {
                tableTrait4 = 5;
            }
        }
        else if (crossTraits[1, 0] == 2)
        {
            // top right
            if (crossTraits[0, 1] == 1)
            {
                tableTrait2 = 4;
            }
            else if (crossTraits[0, 1] == 2)
            {
                tableTrait2 = 2;
            }
            else if (crossTraits[0, 1] == 3)
            {
                tableTrait2 = 6;
            }

            // bot right
            if (crossTraits[1, 1] == 1)
            {
                tableTrait4 = 4;
            }
            else if (crossTraits[1, 1] == 2)
            {
                tableTrait4 = 2;
            }
            else if (crossTraits[1, 1] == 3)
            {
                tableTrait4 = 6;
            }
        }
        else if (crossTraits[1, 0] == 3)
        {
            // top right
            if (crossTraits[0, 1] == 1)
            {
                tableTrait2 = 5;
            }
            else if (crossTraits[0, 1] == 2)
            {
                tableTrait2 = 6;
            }
            else if (crossTraits[0, 1] == 3)
            {
                tableTrait2 = 3;
            }

            // bot right
            if (crossTraits[1, 1] == 1)
            {
                tableTrait4 = 5;
            }
            else if (crossTraits[1, 1] == 2)
            {
                tableTrait4 = 6;
            }
            else if (crossTraits[1, 1] == 3)
            {
                tableTrait4 = 3;
            }
        }

        FillTable();
    }

    void FillTable()
    {
        if (traitCounter == 0)
        {
            // TABLE TRAITS
            switch (tableTrait1)
            {              
                case 1:
                    tableTraitObj1.GetComponent<SpriteRenderer>().sprite = petal1;
                    break;
                case 2:
                    tableTraitObj1.GetComponent<SpriteRenderer>().sprite = petal2;
                    break;
                case 3:
                    tableTraitObj1.GetComponent<SpriteRenderer>().sprite = petal3;
                    break;
                case 4:
                    tableTraitObj1.GetComponent<SpriteRenderer>().sprite = petal4;
                    break;
                case 5:
                    tableTraitObj1.GetComponent<SpriteRenderer>().sprite = petal5;
                    break;
                case 6:
                    tableTraitObj1.GetComponent<SpriteRenderer>().sprite = petal6;
                    break;

            }
            print("Table1 = " + tableTrait1);
            tableTraitObj1.SetActive(true);
            switch (tableTrait2)
            {
                case 1:
                    tableTraitObj2.GetComponent<SpriteRenderer>().sprite = petal1;
                    break;
                case 2:
                    tableTraitObj2.GetComponent<SpriteRenderer>().sprite = petal2;
                    break;
                case 3:
                    tableTraitObj2.GetComponent<SpriteRenderer>().sprite = petal3;
                    break;
                case 4:
                    tableTraitObj2.GetComponent<SpriteRenderer>().sprite = petal4;
                    break;
                case 5:
                    tableTraitObj2.GetComponent<SpriteRenderer>().sprite = petal5;
                    break;
                case 6:
                    tableTraitObj2.GetComponent<SpriteRenderer>().sprite = petal6;
                    break;

            }
            //print("Table2 = " + tableTrait2);
            tableTraitObj2.SetActive(true);
            switch (tableTrait3)
            {
                case 1:
                    tableTraitObj3.GetComponent<SpriteRenderer>().sprite = petal1;
                    break;
                case 2:
                    tableTraitObj3.GetComponent<SpriteRenderer>().sprite = petal2;
                    break;
                case 3:
                    tableTraitObj3.GetComponent<SpriteRenderer>().sprite = petal3;
                    break;
                case 4:
                    tableTraitObj3.GetComponent<SpriteRenderer>().sprite = petal4;
                    break;
                case 5:
                    tableTraitObj3.GetComponent<SpriteRenderer>().sprite = petal5;
                    break;
                case 6:
                    tableTraitObj3.GetComponent<SpriteRenderer>().sprite = petal6;
                    break;

            }
            //print("Table3 = " + tableTrait3);
            tableTraitObj3.SetActive(true);
            switch (tableTrait4)
            {
                case 1:
                    tableTraitObj4.GetComponent<SpriteRenderer>().sprite = petal1;
                    break;
                case 2:
                    tableTraitObj4.GetComponent<SpriteRenderer>().sprite = petal2;
                    break;
                case 3:
                    tableTraitObj4.GetComponent<SpriteRenderer>().sprite = petal3;
                    break;
                case 4:
                    tableTraitObj4.GetComponent<SpriteRenderer>().sprite = petal4;
                    break;
                case 5:
                    tableTraitObj4.GetComponent<SpriteRenderer>().sprite = petal5;
                    break;
                case 6:
                    tableTraitObj4.GetComponent<SpriteRenderer>().sprite = petal6;
                    break;

            }
            //print("Table4 = " + tableTrait4);
            tableTraitObj4.SetActive(true);

            
        }
        else if (traitCounter == 1)
        {
            // TABLE TRAITS
            switch (tableTrait1)
            {
                case 1:
                    tableTraitObj1.GetComponent<SpriteRenderer>().sprite = stem1;
                    break;
                case 2:
                    tableTraitObj1.GetComponent<SpriteRenderer>().sprite = stem2;
                    break;
                case 3:
                    tableTraitObj1.GetComponent<SpriteRenderer>().sprite = stem3;
                    break;
                case 4:
                    tableTraitObj1.GetComponent<SpriteRenderer>().sprite = stem4;
                    break;
                case 5:
                    tableTraitObj1.GetComponent<SpriteRenderer>().sprite = stem5;
                    break;
                case 6:
                    tableTraitObj1.GetComponent<SpriteRenderer>().sprite = stem6;
                    break;

            }
            tableTraitObj1.SetActive(true);
            switch (tableTrait2)
            {
                case 1:
                    tableTraitObj2.GetComponent<SpriteRenderer>().sprite = stem1;
                    break;
                case 2:
                    tableTraitObj2.GetComponent<SpriteRenderer>().sprite = stem2;
                    break;
                case 3:
                    tableTraitObj2.GetComponent<SpriteRenderer>().sprite = stem3;
                    break;
                case 4:
                    tableTraitObj2.GetComponent<SpriteRenderer>().sprite = stem4;
                    break;
                case 5:
                    tableTraitObj2.GetComponent<SpriteRenderer>().sprite = stem5;
                    break;
                case 6:
                    tableTraitObj2.GetComponent<SpriteRenderer>().sprite = stem6;
                    break;

            }
            tableTraitObj2.SetActive(true);
            switch (tableTrait3)
            {
                case 1:
                    tableTraitObj3.GetComponent<SpriteRenderer>().sprite = stem1;
                    break;
                case 2:
                    tableTraitObj3.GetComponent<SpriteRenderer>().sprite = stem2;
                    break;
                case 3:
                    tableTraitObj3.GetComponent<SpriteRenderer>().sprite = stem3;
                    break;
                case 4:
                    tableTraitObj3.GetComponent<SpriteRenderer>().sprite = stem4;
                    break;
                case 5:
                    tableTraitObj3.GetComponent<SpriteRenderer>().sprite = stem5;
                    break;
                case 6:
                    tableTraitObj3.GetComponent<SpriteRenderer>().sprite = stem6;
                    break;

            }
            tableTraitObj3.SetActive(true);
            switch (tableTrait4)
            {
                case 1:
                    tableTraitObj4.GetComponent<SpriteRenderer>().sprite = stem1;
                    break;
                case 2:
                    tableTraitObj4.GetComponent<SpriteRenderer>().sprite = stem2;
                    break;
                case 3:
                    tableTraitObj4.GetComponent<SpriteRenderer>().sprite = stem3;
                    break;
                case 4:
                    tableTraitObj4.GetComponent<SpriteRenderer>().sprite = stem4;
                    break;
                case 5:
                    tableTraitObj4.GetComponent<SpriteRenderer>().sprite = stem5;
                    break;
                case 6:
                    tableTraitObj4.GetComponent<SpriteRenderer>().sprite = stem6;
                    break;

            }
            tableTraitObj4.SetActive(true);


        }
        else if (traitCounter == 2)
        {
            // TABLE TRAITS
            switch (tableTrait1)
            {
                case 1:
                    tableTraitObj1.GetComponent<SpriteRenderer>().sprite = thorn1;
                    break;
                case 2:
                    tableTraitObj1.GetComponent<SpriteRenderer>().sprite = thorn2;
                    break;
                case 3:
                    tableTraitObj1.GetComponent<SpriteRenderer>().sprite = thorn3;
                    break;
                case 4:
                    tableTraitObj1.GetComponent<SpriteRenderer>().sprite = thorn4;
                    break;
                case 5:
                    tableTraitObj1.GetComponent<SpriteRenderer>().sprite = thorn5;
                    break;
                case 6:
                    tableTraitObj1.GetComponent<SpriteRenderer>().sprite = thorn6;
                    break;

            }
            tableTraitObj1.SetActive(true);
            switch (tableTrait2)
            {
                case 1:
                    tableTraitObj2.GetComponent<SpriteRenderer>().sprite = thorn1;
                    break;
                case 2:
                    tableTraitObj2.GetComponent<SpriteRenderer>().sprite = thorn2;
                    break;
                case 3:
                    tableTraitObj2.GetComponent<SpriteRenderer>().sprite = thorn3;
                    break;
                case 4:
                    tableTraitObj2.GetComponent<SpriteRenderer>().sprite = thorn4;
                    break;
                case 5:
                    tableTraitObj2.GetComponent<SpriteRenderer>().sprite = thorn5;
                    break;
                case 6:
                    tableTraitObj2.GetComponent<SpriteRenderer>().sprite = thorn6;
                    break;

            }
            tableTraitObj2.SetActive(true);
            switch (tableTrait3)
            {
                case 1:
                    tableTraitObj3.GetComponent<SpriteRenderer>().sprite = thorn1;
                    break;
                case 2:
                    tableTraitObj3.GetComponent<SpriteRenderer>().sprite = thorn2;
                    break;
                case 3:
                    tableTraitObj3.GetComponent<SpriteRenderer>().sprite = thorn3;
                    break;
                case 4:
                    tableTraitObj3.GetComponent<SpriteRenderer>().sprite = thorn4;
                    break;
                case 5:
                    tableTraitObj3.GetComponent<SpriteRenderer>().sprite = thorn5;
                    break;
                case 6:
                    tableTraitObj3.GetComponent<SpriteRenderer>().sprite = thorn6;
                    break;

            }
            tableTraitObj3.SetActive(true);
            switch (tableTrait4)
            {
                case 1:
                    tableTraitObj4.GetComponent<SpriteRenderer>().sprite = thorn1;
                    break;
                case 2:
                    tableTraitObj4.GetComponent<SpriteRenderer>().sprite = thorn2;
                    break;
                case 3:
                    tableTraitObj4.GetComponent<SpriteRenderer>().sprite = thorn3;
                    break;
                case 4:
                    tableTraitObj4.GetComponent<SpriteRenderer>().sprite = thorn4;
                    break;
                case 5:
                    tableTraitObj4.GetComponent<SpriteRenderer>().sprite = thorn5;
                    break;
                case 6:
                    tableTraitObj4.GetComponent<SpriteRenderer>().sprite = thorn6;
                    break;

            }
            tableTraitObj4.SetActive(true);


        }

        Invoke("StartCoreGraphic", 1f);
    }

    void CleanUp()
    {
        topLeftImage.color = Color.clear;
        topRightImage.color = Color.clear;
        botLeftImage.color = Color.clear;
        botRightImage.color = Color.clear;
        if (traitCounter == 1)
        {
            crossObj00.transform.localPosition = crossObj00Start2;
            crossObj01.transform.localPosition = crossObj01Start2;
            crossObj10.transform.localPosition = crossObj10Start2;
            crossObj11.transform.localPosition = crossObj11Start2;
        }
        else if (traitCounter == 2)
        {
            crossObj00.transform.localPosition = crossObj00Start3;
            crossObj01.transform.localPosition = crossObj01Start3;
            crossObj10.transform.localPosition = crossObj10Start3;
            crossObj11.transform.localPosition = crossObj11Start3;

        }
        graphicPanel.SetActive(false);
        tableTraitObj1.SetActive(false);
        tableTraitObj2.SetActive(false);
        tableTraitObj3.SetActive(false);
        tableTraitObj4.SetActive(false);
        crossObj00.SetActive(false);
        crossObj01.SetActive(false);
        crossObj10.SetActive(false);
        crossObj11.SetActive(false);


        if (traitCounter < 3)
        {
            Invoke("SplitTraits", 1f);
        }
    }
}
