﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] flowerSpawns;
    public int numFlowers = 4; //amount of flowers to spawn
    public GameObject flowerPrefab;

    public static int tracker;

    //target flower traits
    public int colorTarget;
    public int stemTarget;
    public int petalTarget;
    public int thornsTarget;


    MyRandom rand = new MyRandom();
    private Punnett square;

    public GameObject targetFlowerPanel;
    private Sprite tarFlower;

    public GameObject winText;
    public TextMeshProUGUI objectiveText;

    // Start is called before the first frame update
    void Start()
    {
        tracker = 1;
        //finds the punnentt gameobject that holds the punnett script that calculates the punnett square
        square = GameObject.FindGameObjectWithTag("punnett").GetComponent<Punnett>();
        //GenerateTargetFlower();
        FlowerSpawning();
        //objectiveText.text = "Find two flowers petals you like";
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Function that generates the target flower and spawns it on the first pot
    //void GenerateTargetFlower()
    //{
    //    int trait;
    //    MyRandom rand = new MyRandom();

    //    //find more efficent way of assigning random traits
    //    //COLOR
    //    trait = rand.Next(1, 4);

    //    if (trait == 1) // two big
    //    {
    //        colorTarget = 1;
    //    }

    //    else if (trait == 2) // two small
    //    {
    //        colorTarget = 2;
    //    }

    //    else if (trait == 3) // one big one small 
    //    {
    //        colorTarget = 3;
    //    }
    //    rand.Reset();

    //    //STEM
    //    trait = rand.Next(1, 4);

    //    if (trait == 1) // two big
    //    {
    //        stemTarget = 1;
    //    }

    //    else if (trait == 2) // two small
    //    {
    //        stemTarget = 2;
    //    }

    //    else if (trait == 3) // one big one small 
    //    {
    //        stemTarget = 3;
    //    }
    //    rand.Reset();

    //    //PETAL
    //    trait = rand.Next(1, 4);

    //    if (trait == 1) // two big
    //    {
    //        petalTarget = 1;
    //    }

    //    else if (trait == 2) // two small
    //    {
    //        petalTarget = 2;
    //    }

    //    else if (trait == 3) // one big one small 
    //    {
    //        petalTarget = 3;
    //    }
    //    rand.Reset();

    //    //THORNS
    //    trait = rand.Next(1, 4);

    //    if (trait == 1) // two big
    //    {
    //        thornsTarget = 1;
    //    }

    //    else if (trait == 2) // two small
    //    {
    //        thornsTarget = 2;
    //    }

    //    else if (trait == 3) // one big one small 
    //    {
    //        thornsTarget = 3;
    //    }
    //    rand.Reset();

    //    GameObject flower = Instantiate(flowerPrefab, targetFlowerPanel.transform);
    //    flower.GetComponent<FlowerBehaviour>().isTarget = true;
    //    flower.transform.localPosition = new Vector3(0, 1.25f, 0);

    //    flower.GetComponent<FlowerBehaviour>().colorTraits = colorTarget;
    //    flower.GetComponent<FlowerBehaviour>().stemTraits = stemTarget;
    //    flower.GetComponent<FlowerBehaviour>().petalTraits = petalTarget;
    //    flower.GetComponent<FlowerBehaviour>().thornsTraits = thornsTarget;
    //}

    //public void CheckFlowerMatch(FlowerBehaviour fb)
    //{
    //    if(fb.colorTraits == colorTarget && fb.stemTraits == stemTarget && fb.petalTraits == petalTarget && fb.thornsTraits == thornsTarget)
    //    {
    //        winText.SetActive(true);
    //    }
    //}

    //Spawns the flowers in the outside envioronment
    void FlowerSpawning()
    {
        int[] numCheck = new int[numFlowers]; //numFlowers is the amount of flowers that should be spawned
        MyRandom randLoc = new MyRandom();

        for(int i = 0; i < numFlowers; i++)
        {
            rand.Reset();
            CreateFlower(randLoc.Next(0, flowerSpawns.Length));
        }
    }

    void CreateFlower(int loc)
    {
        //MyRandom rand = new MyRandom();
        int trait;

        GameObject flower = Instantiate(flowerPrefab, flowerSpawns[loc].transform.position, Quaternion.identity);

        //find more efficent way of assigning random traits
        //COLOR
        rand.Reset();
        //trait = rand.Next(1, 4);

        //if (trait == 1) // two big
        //{
        //    flower.GetComponent<FlowerBehaviour>().colorTraits = 1;
        //}

        //else if (trait == 2) // two small
        //{
        //    flower.GetComponent<FlowerBehaviour>().colorTraits = 2;
        //}

        //else if (trait == 3) //one big one small 
        //{
        //    flower.GetComponent<FlowerBehaviour>().colorTraits = 3;
        //}

        //else if (trait == 4) //one big one small 
        //{
        //    flower.GetComponent<FlowerBehaviour>().colorTraits = 4;
        //}

        //else if (trait == 5) //one big one small 
        //{
        //    flower.GetComponent<FlowerBehaviour>().colorTraits = 5;
        //}

        //else if (trait == 6) //one big one small 
        //{
        //    flower.GetComponent<FlowerBehaviour>().colorTraits = 6;
        //}
        //rand.Reset();


        //STEM
        trait = rand.Next(1, 7);

        if (trait == 1) // two big
        {
            flower.GetComponent<FlowerBehaviour>().stemTraits = 1;
        }

        else if (trait == 2) // one big one small
        {
            flower.GetComponent<FlowerBehaviour>().stemTraits = 2;
        }

        else if (trait == 3) // two small
        {
            flower.GetComponent<FlowerBehaviour>().stemTraits = 3;
        }

        else if (trait == 4) // two small
        {
            flower.GetComponent<FlowerBehaviour>().stemTraits = 4;
        }

        else if (trait == 5) // two small
        {
            flower.GetComponent<FlowerBehaviour>().stemTraits = 5;
        }

        else if (trait == 6) // two small
        {
            flower.GetComponent<FlowerBehaviour>().stemTraits = 6;
        }
        rand.Reset();


        //PETAL
        trait = rand.Next(1, 7);

        if (trait == 1) // two big
        {
            flower.GetComponent<FlowerBehaviour>().petalTraits = 1;
        }

        else if (trait == 2) // one big one small
        {
            flower.GetComponent<FlowerBehaviour>().petalTraits = 2;
        }

        else if (trait == 3) // two small
        {
            flower.GetComponent<FlowerBehaviour>().petalTraits = 3;
        }

        else if (trait == 4) // two small
        {
            flower.GetComponent<FlowerBehaviour>().petalTraits = 4;
        }

        else if (trait == 5) // two small
        {
            flower.GetComponent<FlowerBehaviour>().petalTraits = 5;
        }

        else if (trait == 6) // two small
        {
            flower.GetComponent<FlowerBehaviour>().petalTraits = 6;
        }

        rand.Reset();


        //THORNS
        trait = rand.Next(1, 7);

        if (trait == 1) // two big
        {
            flower.GetComponent<FlowerBehaviour>().thornsTraits = 1;
        }

        else if (trait == 2) // one big one small
        {
            flower.GetComponent<FlowerBehaviour>().thornsTraits = 2;
        }

        else if (trait == 3) // two small
        {
            flower.GetComponent<FlowerBehaviour>().thornsTraits = 3;
        }

        else if (trait == 4) // two small
        {
            flower.GetComponent<FlowerBehaviour>().thornsTraits = 4;
        }

        else if (trait == 5) // two small
        {
            flower.GetComponent<FlowerBehaviour>().thornsTraits = 5;
        }

        else if (trait == 6) // two small
        {
            flower.GetComponent<FlowerBehaviour>().thornsTraits = 6;
        }
        rand.Reset();
        StartCoroutine("WaitTime");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("StartingMenu");
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(.1f);
    }

    //Random function that handles random but also allows for random numbers that are not the same
    public class MyRandom : System.Random
    {
        List<int> returnedNumbers = new List<int>();

        public void Reset()
        {
            returnedNumbers.Clear();
        }

        private bool IsUnique(int number)
        {
            lock (returnedNumbers)
            {
                if (returnedNumbers.Contains(number))
                {
                    return false;
                }
                else
                {
                    returnedNumbers.Add(number);
                    return true;
                }
            }
        }

        public override int Next()
        {
            int number = base.Next();
            while (!IsUnique(number))
            {
                number = base.Next();
            }
            return number;
        }

        public override int Next(int maxValue)
        {
            int number = base.Next(maxValue);

            while (!IsUnique(number))
            {
                number = base.Next();
            }
            return number;
        }

        public override int Next(int minValue, int maxValue)
        {
            int number = base.Next(minValue, maxValue);
            while (!IsUnique(number))
            {
                number = base.Next(minValue, maxValue);
            }
            return number;
        }
    }
}
