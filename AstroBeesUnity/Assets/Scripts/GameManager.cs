using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] flowerSpawns;
    public int numFlowers = 4; //amount of flowers to spawn
    public GameObject flowerPrefab;

    public string[,] colorTarget = new string[1, 2];
    public string[,] stemTarget = new string[1, 2];
    public string[,] petalTarget = new string[1, 2];
    public string[,] thornsTarget = new string[1, 2];

    MyRandom rand = new MyRandom();

    // Start is called before the first frame update
    void Start()
    {
        FlowerSpawning();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GenerateTargetFlower()
    {
        //MyRandom rand = new MyRandom();
        int trait;

        //find more efficent way of assigning random traits
        //COLOR
        rand.Reset();
        trait = rand.Next(1, 4);

        if (trait == 1) // two big
        {
            colorTarget[0, 0] = "C";
            colorTarget[0, 1] = "C";
        }

        else if (trait == 2) // one big one small
        {
            colorTarget[0, 0] = "C";
            colorTarget[0, 1] = "c";
        }

        else if (trait == 3) // two small
        {
            colorTarget[0, 0] = "c";
            colorTarget[0, 1] = "c";
        }
        rand.Reset();


        //STEM
        trait = rand.Next(1, 4);

        if (trait == 1) // two big
        {
            stemTarget[0, 0] = "S";
            stemTarget[0, 1] = "S";
        }

        else if (trait == 2) // one big one small
        {
            stemTarget[0, 0] = "S";
            stemTarget[0, 1] = "s";
        }

        else if (trait == 3) // two small
        {
            stemTarget[0, 0] = "s";
            stemTarget[0, 1] = "s";
        }
        rand.Reset();


        //PETAL
        trait = rand.Next(1, 4);

        if (trait == 1) // two big
        {
            petalTarget[0, 0] = "P";
            petalTarget[0, 1] = "P";
        }

        else if (trait == 2) // one big one small
        {
            petalTarget[0, 0] = "P";
            petalTarget[0, 1] = "p";
        }

        else if (trait == 3) // two small
        {
            petalTarget[0, 0] = "p";
            petalTarget[0, 1] = "p";
        }
        rand.Reset();


        //THORNS
        trait = rand.Next(1, 4);

        if (trait == 1) // two big
        {
            thornsTarget[0, 0] = "T";
            thornsTarget[0, 1] = "T";
        }

        else if (trait == 2) // one big one small
        {
            thornsTarget[0, 0] = "T";
            thornsTarget[0, 1] = "t";
        }

        else if (trait == 3) // two small
        {
            thornsTarget[0, 0] = "t";
            thornsTarget[0, 1] = "t";
        }
        rand.Reset();
    }

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
        trait = rand.Next(1, 4);

        if (trait == 1) // two big
        {
            //flower.GetComponent<FlowerBehaviour>().colorTraits[0, 0] = "C";
            //flower.GetComponent<FlowerBehaviour>().colorTraits[0, 1] = "C";
            flower.GetComponent<FlowerBehaviour>().color = 1;
        }

        else if (trait == 2) // one big one small
        {
            //flower.GetComponent<FlowerBehaviour>().colorTraits[0, 0] = "C";
            //flower.GetComponent<FlowerBehaviour>().colorTraits[0, 1] = "c";
            flower.GetComponent<FlowerBehaviour>().color = 2;
        }

        else if (trait == 3) // two small
        {
            //flower.GetComponent<FlowerBehaviour>().colorTraits[0, 0] = "c";
            //flower.GetComponent<FlowerBehaviour>().colorTraits[0, 1] = "c";
            flower.GetComponent<FlowerBehaviour>().color = 2;
        }
        rand.Reset();


        //STEM
        trait = rand.Next(1, 4);

        if (trait == 1) // two big
        {
            flower.GetComponent<FlowerBehaviour>().stemTraits[0, 0] = "S";
            flower.GetComponent<FlowerBehaviour>().stemTraits[0, 1] = "S";
        }

        else if (trait == 2) // one big one small
        {
            flower.GetComponent<FlowerBehaviour>().stemTraits[0, 0] = "S";
            flower.GetComponent<FlowerBehaviour>().stemTraits[0, 1] = "s";
        }

        else if (trait == 3) // two small
        {
            flower.GetComponent<FlowerBehaviour>().stemTraits[0, 0] = "s";
            flower.GetComponent<FlowerBehaviour>().stemTraits[0, 1] = "s";
        }
        rand.Reset();


        //PETAL
        trait = rand.Next(1, 4);

        if (trait == 1) // two big
        {
            flower.GetComponent<FlowerBehaviour>().petalTraits[0, 0] = "P";
            flower.GetComponent<FlowerBehaviour>().petalTraits[0, 1] = "P";
        }

        else if (trait == 2) // one big one small
        {
            flower.GetComponent<FlowerBehaviour>().petalTraits[0, 0] = "P";
            flower.GetComponent<FlowerBehaviour>().petalTraits[0, 1] = "p";
        }

        else if (trait == 3) // two small
        {
            flower.GetComponent<FlowerBehaviour>().petalTraits[0, 0] = "p";
            flower.GetComponent<FlowerBehaviour>().petalTraits[0, 1] = "p";
        }
        rand.Reset();


        //THORNS
        trait = rand.Next(1, 4);

        if (trait == 1) // two big
        {
            flower.GetComponent<FlowerBehaviour>().thornsTraits[0, 0] = "T";
            flower.GetComponent<FlowerBehaviour>().thornsTraits[0, 1] = "T";
        }

        else if (trait == 2) // one big one small
        {
            flower.GetComponent<FlowerBehaviour>().thornsTraits[0, 0] = "T";
            flower.GetComponent<FlowerBehaviour>().thornsTraits[0, 1] = "t";
        }

        else if (trait == 3) // two small
        {
            flower.GetComponent<FlowerBehaviour>().thornsTraits[0, 0] = "t";
            flower.GetComponent<FlowerBehaviour>().thornsTraits[0, 1] = "t";
        }
        rand.Reset();
        StartCoroutine("WaitTime");
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(.1f);
    }

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
