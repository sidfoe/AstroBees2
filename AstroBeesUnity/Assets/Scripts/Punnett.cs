using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punnett : MonoBehaviour
{
    // 1 = two big
    //2 = two small
    //3 = one big one small
    public int RunSquare(int one, int two) //runs punnett square with two pairs of triats
    {
        int result = 0;

        if(one == 1 && two == 1) //two big pairs
        {
            result = 1;
        }

        if(one == 2 && two == 2) //two small pairs
        {
            result = 2;
        }

        if((one == 2 && two == 1) || (one == 1 && two == 2))//one small and one big pair
        {
            result = 3;
        }

        if((one == 3 && two == 1) || (one == 1 && two == 3)) //one big and one mixed pair
        {
            int rand = Random.Range(1, 3); //50 50 chance of a 1 or a 3

            if(rand == 1)
            {
                result = 1;
            }
            else
            {
                result = 3;
            }
        }

        if ((one == 3 && two == 2) || (one == 2 && two == 3)) //one small and one mixed pair
        {
            int rand = Random.Range(1, 3); //50 50 chance of a 2 or a 3

            if (rand == 1)
            {
                result = 2;
            }
            else
            {
                result = 3;
            }
        }

        if ((one == 3 && two == 3) || (one == 3 && two == 3)) //two mixed pairs
        {
            int rand = Random.Range(1, 5); //25% 1 50% 3 25% 2

            if(rand == 1)
            {
                result = 1;
            }

            else if(rand == 2 || rand == 3)
            {
                result = 3;
            }

            else
            {
                result = 2;
            }
            
        }
        return result;
    }
}
