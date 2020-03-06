using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punnett : MonoBehaviour
{
    //1 = LL
    //2 = MM
    //3 = SS
    //4 = LS
    //5 = LM
    //6 = MS

    public int RunSquare(int one, int two) //runs punnett square with two pairs of triats
    {
        string[] square = new string[4];
        string[,] squareResults = new string[4, 2];
        string[] results = new string[2];

        int rand = Random.Range(0, 2);

        switch (one)
        {
            case 1:
                square[0] = "L";
                square[1] = "L";
                results[0] = square[rand];
                break;
            case 2:
                square[0] = "M";
                square[1] = "M";
                results[0] = square[rand];
                break;
            case 3:
                square[0] = "S";
                square[1] = "S";
                results[0] = square[rand];
                break;
            case 4:
                square[0] = "L";
                square[1] = "M";
                results[0] = square[rand];
                break;
            case 5:
                square[0] = "L";
                square[1] = "S";
                results[0] = square[rand];
                break;
            case 6:
                square[0] = "M";
                square[1] = "S";
                results[0] = square[rand];
                break;
        }

        rand = Random.Range(2, 4);

        switch (two)
        {
            case 1:
                square[2] = "L";
                square[3] = "L";
                results[1] = square[rand];
                break;
            case 2:
                square[2] = "M";
                square[3] = "M";
                results[1] = square[rand];
                break;
            case 3:
                square[2] = "S";
                square[3] = "S";
                results[1] = square[rand];
                break;
            case 4:
                square[2] = "L";
                square[3] = "M";
                results[1] = square[rand];
                break;
            case 5:
                square[2] = "L";
                square[3] = "S";
                results[1] = square[rand];
                break;
            case 6:
                square[2] = "M";
                square[3] = "S";
                results[1] = square[rand];
                break;
        }

        if(results[0] == "L" && results[1] == "L")
        {
            return 1;
        }

        if (results[0] == "M" && results[1] == "M")
        {
            return 2;
        }

        if (results[0] == "S" && results[1] == "S")
        {
            return 3;
        }

        if (results[0] == "L" && results[1] == "M")
        {
            return 4;
        }

        if (results[0] == "L" && results[1] == "s")
        {
            return 5;
        }

        if (results[0] == "M" && results[1] == "S")
        {
            return 6;
        }

        return 0;
    }
}




//int result = 0;

//if(one == 1 && two == 1) //two big pairs
//{
//    result = 1;
//}

//if(one == 2 && two == 2) //two small pairs
//{
//    result = 2;
//}

//if((one == 2 && two == 1) || (one == 1 && two == 2))//one small and one big pair
//{
//    result = 3;
//}

//if((one == 3 && two == 1) || (one == 1 && two == 3)) //one big and one mixed pair
//{
//    int rand = Random.Range(1, 3); //50 50 chance of a 1 or a 3

//    if(rand == 1)
//    {
//        result = 1;
//    }
//    else
//    {
//        result = 3;
//    }
//}

//if ((one == 3 && two == 2) || (one == 2 && two == 3)) //one small and one mixed pair
//{
//    int rand = Random.Range(1, 3); //50 50 chance of a 2 or a 3

//    if (rand == 1)
//    {
//        result = 2;
//    }
//    else
//    {
//        result = 3;
//    }
//}

//if ((one == 3 && two == 3) || (one == 3 && two == 3)) //two mixed pairs
//{
//    int rand = Random.Range(1, 5); //25% 1 50% 3 25% 2

//    if(rand == 1)
//    {
//        result = 1;
//    }

//    else if(rand == 2 || rand == 3)
//    {
//        result = 3;
//    }

//    else
//    {
//        result = 2;
//    }

//}
//return result;