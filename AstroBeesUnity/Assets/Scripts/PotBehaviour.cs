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


    // Start is called before the first frame update
    void Start()
    {
        if (potNum == 1)
        {
            GameManager.MyRandom rand = new GameManager.MyRandom();
            int trait;

            //find more efficent way of assigning random traits
            //COLOR
            trait = rand.Next(1, 4);

            //if (trait == 1) // two big
            //{
            //    prevColor[0, 0] = "C";
            //    prevColor[0, 1] = "C";
            //}

            //else if (trait == 2) // one big one small
            //{
            //    prevColor[0, 0] = "C";
            //    prevColor[0, 1] = "c";
            //}

            //else if (trait == 3) // two small
            //{
            //    prevColor[0, 0] = "c";
            //    prevColor[0, 1] = "c";
            //}
            //rand.Reset();


            ////STEM
            //trait = rand.Next(1, 4);

            //if (trait == 1) // two big
            //{
            //    prevStem[0, 0] = "S";
            //    prevStem[0, 1] = "S";
            //}

            //else if (trait == 2) // one big one small
            //{
            //    prevStem[0, 0] = "S";
            //    prevStem[0, 1] = "s";
            //}

            //else if (trait == 3) // two small
            //{
            //    prevStem[0, 0] = "s";
            //    prevStem[0, 1] = "s";
            //}
            //rand.Reset();


            ////PETAL
            //trait = rand.Next(1, 4);

            //if (trait == 1) // two big
            //{
            //    prevPetal[0, 0] = "P";
            //    prevPetal[0, 1] = "P";
            //}

            //else if (trait == 2) // one big one small
            //{
            //    prevPetal[0, 0] = "P";
            //    prevPetal[0, 1] = "p";
            //}

            //else if (trait == 3) // two small
            //{
            //    prevPetal[0, 0] = "p";
            //    prevPetal[0, 1] = "p";
            //}
            //rand.Reset();


            ////THORNS
            //trait = rand.Next(1, 4);

            //if (trait == 1) // two big
            //{
            //    prevThorns[0, 0] = "T";
            //    prevThorns[0, 1] = "T";
            //}

            //else if (trait == 2) // one big one small
            //{
            //    prevThorns[0, 0] = "T";
            //    prevThorns[0, 1] = "t";
            //}

            //else if (trait == 3) // two small
            //{
            //    prevThorns[0, 0] = "t";
            //    prevThorns[0, 1] = "t";
            //}

            //GameObject flower = Instantiate(flowerPrefab, transform);
            //flower.transform.localPosition = Vector3.zero;
            
            //flower.GetComponent<FlowerBehaviour>().colorTraits[0,0] = prevColor[0, 0];
            //flower.GetComponent<FlowerBehaviour>().colorTraits[0, 1] = prevColor[0, 1];
            //flower.GetComponent<FlowerBehaviour>().stemTraits[0, 0] = prevStem[0, 0];
            //flower.GetComponent<FlowerBehaviour>().stemTraits[0, 1] = prevStem[0, 1];
            //flower.GetComponent<FlowerBehaviour>().petalTraits[0, 0] = prevPetal[0, 0];
            //flower.GetComponent<FlowerBehaviour>().petalTraits[0, 1] = prevPetal[0, 1];
            //flower.GetComponent<FlowerBehaviour>().thornsTraits[0, 0] = prevThorns[0, 0];
            //flower.GetComponent<FlowerBehaviour>().thornsTraits[0, 1] = prevThorns[0, 1];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSquare()
    {
        
        int color = gameObject.GetComponent<Punnett>().RunSquare(prevColor, colorTraits);
        int stem = gameObject.GetComponent<Punnett>().RunSquare(prevStem, stemTraits);
        int thorns = gameObject.GetComponent<Punnett>().RunSquare(prevThorns, thornsTraits);
        int petal = gameObject.GetComponent<Punnett>().RunSquare(prevPetal, petalTraits);

        GameObject flower = Instantiate(flowerPrefab, transform);
        flower.transform.localPosition = Vector3.zero;

        //flower.GetComponent<FlowerBehaviour>.
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