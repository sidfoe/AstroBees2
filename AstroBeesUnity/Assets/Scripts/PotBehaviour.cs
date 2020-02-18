using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotBehaviour : MonoBehaviour
{
    public int potNum = 0;
    public GameObject nextPot;
    public GameObject flowerPrefab;

    //these traits are the ones given by the bee
    public int colorTraits;
    public int stemTraits;
    public int petalTraits;
    public int thornsTraits;

    //prev traits are the the traits of the flower in the pot
    public int prevColor;
    public int prevStem;
    public int prevPetal;
    public int prevThorns;

    private Punnett square;

    // Start is called before the first frame update
    void Start()
    {
        square = GameObject.FindGameObjectWithTag("punnett").GetComponent<Punnett>();

        if (potNum == 1)
        {
            int rand;

            //find more efficent way of assigning random traits
            //COLOR
            rand = Random.Range(1, 4);

            if (rand == 1) // two big
            {
                prevColor = 1;
            }

            else if (rand == 2) // two small
            {
                prevColor = 2;
            }

            else if (rand == 3) // one big one small 
            {
                prevColor = 3;
            }


            //STEM
            rand = Random.Range(1, 4);

            if (rand == 1) // two big
            {
                prevStem = 1;
            }

            else if (rand == 2) // two small
            {
                prevStem = 2;
            }

            else if (rand == 3) // one big one small 
            {
                prevStem = 3;
            }


            //PETAL
            rand = Random.Range(1, 4);

            if (rand == 1) // two big
            {
                prevPetal = 1;
            }

            else if (rand == 2) // two small
            {
                prevPetal = 2;
            }

            else if (rand == 3) // one big one small 
            {
                prevPetal = 3;
            }


            //THORNS
            rand = Random.Range(1, 4);

            if (rand == 1) // two big
            {
                prevThorns = 1;
            }

            else if (rand == 2) // two small
            {
                prevThorns = 2;
            }

            else if (rand == 3) // one big one small 
            {
                prevThorns = 3;
            }

            GameObject flower = Instantiate(flowerPrefab, transform);
            flower.transform.localPosition = Vector3.zero;

            flower.GetComponent<FlowerBehaviour>().colorTraits = prevColor;
            flower.GetComponent<FlowerBehaviour>().stemTraits = prevStem;
            flower.GetComponent<FlowerBehaviour>().petalTraits = prevPetal;
            flower.GetComponent<FlowerBehaviour>().thornsTraits = prevThorns;
            flower.GetComponent<FlowerBehaviour>().SpawnedInPot();

        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartSquare()
    {
        int color = square.RunSquare(prevColor, colorTraits);
        int stem = square.RunSquare(prevStem, stemTraits);
        int thorns = square.RunSquare(prevThorns, thornsTraits);
        int petal = square.RunSquare(prevPetal, petalTraits);

        GameObject flower = Instantiate(flowerPrefab, nextPot.transform);
        flower.transform.localPosition = Vector3.zero;

        flower.GetComponent<FlowerBehaviour>().colorTraits = color;
        flower.GetComponent<FlowerBehaviour>().stemTraits = stem;
        flower.GetComponent<FlowerBehaviour>().thornsTraits = thorns;
        flower.GetComponent<FlowerBehaviour>().petalTraits = petal;
        flower.GetComponent<FlowerBehaviour>().SpawnedInPot();
    }
}






//public void PunnettSquare()
//{
//    string[,] square = new string[2, 2];
//    string[,] squareResults = new string[4, 2];
//    //string[,] finalResults = new string[4, 2];

//    //COLOR

//    //first set of traits
//    square[0, 0] = colorTraits[0, 0];
//    square[0, 1] = colorTraits[0, 1];
//    //second set of traits
//    square[1, 0] = prevColor[0, 0];
//    square[1, 1] = prevColor[0, 1];

//    //result 1
//    squareResults[0, 0] = square[0, 0];
//    squareResults[0, 1] = square[1, 0];
//    //result 2
//    squareResults[1, 0] = square[0, 1];
//    squareResults[1, 1] = square[1, 0];
//    //result 3
//    squareResults[2, 0] = square[0, 0];
//    squareResults[2, 1] = square[1, 1];
//    //result 4
//    squareResults[3, 0] = square[0, 1];
//    squareResults[3, 1] = square[1, 1];

//    int winner = Random.Range(0, 100);

//    if (winner <= 25) //result 1
//    {
//        prevColor[0, 0] = squareResults[0, 0];
//        prevColor[0, 1] = squareResults[0, 1];
//    }

//    else if (winner <= 50 && winner > 25) //result 2
//    {
//        prevColor[0, 0] = squareResults[1, 0];
//        prevColor[0, 1] = squareResults[1, 1];
//    }

//    else if (winner <= 75 && winner > 50) //result 3
//    {
//        prevColor[0, 0] = squareResults[2, 0];
//        prevColor[0, 1] = squareResults[2, 1];
//    }

//    else if (winner <= 100 && winner > 75) //result 4
//    {
//        prevColor[0, 0] = squareResults[3, 0];
//        prevColor[0, 1] = squareResults[3, 1];
//    }

//    //STEM

//    //first set of traits
//    square[0, 0] = stemTraits[0, 0];
//    square[0, 1] = stemTraits[0, 1];
//    //second set of traits
//    square[1, 0] = prevStem[0, 0];
//    square[1, 1] = prevStem[0, 1];

//    //result 1
//    squareResults[0, 0] = square[0, 0];
//    squareResults[0, 1] = square[1, 0];
//    //result 2
//    squareResults[1, 0] = square[0, 1];
//    squareResults[1, 1] = square[1, 0];
//    //result 3
//    squareResults[2, 0] = square[0, 0];
//    squareResults[2, 1] = square[1, 1];
//    //result 4
//    squareResults[3, 0] = square[0, 1];
//    squareResults[3, 1] = square[1, 1];

//    winner = Random.Range(0, 100);

//    if (winner <= 25) //result 1
//    {
//        prevStem[0, 0] = squareResults[0, 0];
//        prevStem[0, 1] = squareResults[0, 1];
//    }

//    else if (winner <= 50 && winner > 25) //result 2
//    {
//        prevStem[0, 0] = squareResults[1, 0];
//        prevStem[0, 1] = squareResults[1, 1];
//    }

//    else if (winner <= 75 && winner > 50) //result 3
//    {
//        prevStem[0, 0] = squareResults[2, 0];
//        prevStem[0, 1] = squareResults[2, 1];
//    }

//    else if (winner <= 100 && winner > 75) //result 4
//    {
//        prevStem[0, 0] = squareResults[3, 0];
//        prevStem[0, 1] = squareResults[3, 1];
//    }

//    //PETAL

//    //first set of traits
//    square[0, 0] = petalTraits[0, 0];
//    square[0, 1] = petalTraits[0, 1];
//    //second set of traits
//    square[1, 0] = prevPetal[0, 0];
//    square[1, 1] = prevPetal[0, 1];

//    //result 1
//    squareResults[0, 0] = square[0, 0];
//    squareResults[0, 1] = square[1, 0];
//    //result 2
//    squareResults[1, 0] = square[0, 1];
//    squareResults[1, 1] = square[1, 0];
//    //result 3
//    squareResults[2, 0] = square[0, 0];
//    squareResults[2, 1] = square[1, 1];
//    //result 4
//    squareResults[3, 0] = square[0, 1];
//    squareResults[3, 1] = square[1, 1];

//    winner = Random.Range(0, 100);

//    if (winner <= 25) //result 1
//    {
//        prevPetal[0, 0] = squareResults[0, 0];
//        prevPetal[0, 1] = squareResults[0, 1];
//    }

//    else if (winner <= 50 && winner > 25) //result 2
//    {
//        prevPetal[0, 0] = squareResults[1, 0];
//        prevPetal[0, 1] = squareResults[1, 1];
//    }

//    else if (winner <= 75 && winner > 50) //result 3
//    {
//        prevPetal[0, 0] = squareResults[2, 0];
//        prevPetal[0, 1] = squareResults[2, 1];
//    }

//    else if (winner <= 100 && winner > 75) //result 4
//    {
//        prevPetal[0, 0] = squareResults[3, 0];
//        prevPetal[0, 1] = squareResults[3, 1];
//    }

//    //THORN

//    //first set of traits
//    square[0, 0] = thornsTraits[0, 0];
//    square[0, 1] = thornsTraits[0, 1];
//    Debug.Log(thornsTraits[0, 0]);
//    //second set of traits
//    square[1, 0] = prevThorns[0, 0];
//    square[1, 1] = prevThorns[0, 1];

//    //result 1
//    squareResults[0, 0] = square[0, 0];
//    squareResults[0, 1] = square[1, 0];
//    //result 2
//    squareResults[1, 0] = square[0, 1];
//    squareResults[1, 1] = square[1, 0];
//    //result 3
//    squareResults[2, 0] = square[0, 0];
//    squareResults[2, 1] = square[1, 1];
//    //result 4
//    squareResults[3, 0] = square[0, 1];
//    squareResults[3, 1] = square[1, 1];


//    winner = Random.Range(0, 100);

//    if (winner <= 25) //result 1
//    {
//        prevThorns[0, 0] = squareResults[0, 0];
//        prevThorns[0, 1] = squareResults[0, 1];
//    }

//    if (winner <= 50 && winner > 25) //result 2
//    {
//        prevThorns[0, 0] = squareResults[1, 0];
//        prevThorns[0, 1] = squareResults[1, 1];
//    }

//    if (winner <= 75 && winner > 50) //result 3
//    {
//        prevThorns[0, 0] = squareResults[2, 0];
//        prevThorns[0, 1] = squareResults[2, 1];
//    }

//    if (winner <= 100 && winner > 75) //result 4
//    {
//        prevThorns[0, 0] = squareResults[3, 0];
//        prevThorns[0, 1] = squareResults[3, 1];
//    }

//    //use prev traits to create the new flower in the next pot
//    GameObject flower = Instantiate(flowerPrefab, nextPot.transform);
//    flower.transform.localPosition = Vector3.zero;

//    flower.GetComponent<FlowerBehaviour>().colorTraits[0, 0] = prevColor[0, 0];
//    flower.GetComponent<FlowerBehaviour>().colorTraits[0, 1] = prevColor[0, 1];
//    flower.GetComponent<FlowerBehaviour>().stemTraits[0, 0] = prevStem[0, 0];
//    flower.GetComponent<FlowerBehaviour>().stemTraits[0, 1] = prevStem[0, 1];
//    flower.GetComponent<FlowerBehaviour>().petalTraits[0, 0] = prevPetal[0, 0];
//    flower.GetComponent<FlowerBehaviour>().petalTraits[0, 1] = prevPetal[0, 1];
//    flower.GetComponent<FlowerBehaviour>().thornsTraits[0, 0] = prevThorns[0, 0];
//    flower.GetComponent<FlowerBehaviour>().thornsTraits[0, 1] = prevThorns[0, 1];
//}