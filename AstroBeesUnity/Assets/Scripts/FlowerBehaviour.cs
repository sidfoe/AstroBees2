using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FlowerBehaviour : MonoBehaviour
{
    //1 = LL
    //2 = MM
    //3 = SS
    //4 = LM
    //5 = LS
    //6 = MS

    public int colorTraits; //1 red 2 blue 3 purple
    public int stemTraits; //1 & 3 yes 2 no on the leaves
    public int petalTraits; //1 & 3 bubbly boy 3 skinny
    public int thornsTraits; //1 & 3 thorns 2 no

    public bool updateLook = false;

    public Sprite[] petal;
    public Sprite[] stem;
    public Sprite[] thorn;

    public GameObject tar;
    public bool isTarget = false;

    private void Awake()
    {
        //tar = GameObject.FindGameObjectWithTag("tarImg");
    }

    private void Start()
    {
        
    }

    private void LateUpdate()
    {
        if(updateLook == false)
        {
            updateLook = true;

            switch (petalTraits)
            {
                case 1:
                    gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = petal[0];
                    break;
                case 2:
                    gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = petal[1];
                    break;
                case 3:
                    gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = petal[2];
                    break;
                case 4:
                    gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = petal[3];
                    break;
                case 5:
                    gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = petal[4];
                    break;
                case 6:
                    gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = petal[5];
                    break;
            }

            switch (stemTraits)
            {
                case 1:
                    gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stem[0];
                    break;
                case 2:
                    gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stem[1];
                    break;
                case 3:
                    gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stem[2];
                    break;
                case 4:
                    gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stem[3];
                    break;
                case 5:
                    gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stem[4];
                    break;
                case 6:
                    gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stem[5];
                    break;
            }

            switch (stemTraits)
            {
                case 1:
                    gameObject.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = thorn[0];
                    break;
                case 2:
                    gameObject.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = thorn[1];
                    break;
                case 3:
                    gameObject.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = thorn[2];
                    break;
                case 4:
                    gameObject.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = thorn[3];
                    break;
                case 5:
                    gameObject.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = thorn[4];
                    break;
                case 6:
                    gameObject.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = thorn[5];
                    break;
            }
        }

        //if(isTarget == true)
        //{
        //    TargetFlowerImage();
        //}
    }

    public void Grow()
    {
        Vector3 newSize = new Vector3(1.5f, 1.5f);
        transform.localScale = newSize;
    }

    public void Shrink()
    {
        Vector3 newSize = new Vector3(1, 1);
        transform.localScale = newSize;
    }

    public void SpawnedInPot()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }

    //public void TargetFlowerImage()
    //{
    //    tar.GetComponent<Image>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;

    //    if(colorTraits == 3)
    //    {
    //        tar.GetComponent<Image>().color = new Color(.4f, .2f, 1, 1);
    //    }
    //}
}


//if(colorTraits == 1)
//            {
//                if(stemTraits == 1 || stemTraits == 3)
//                {
//                    if(petalTraits == 1 || petalTraits == 3)
//                    {
//                        if(thornsTraits == 1 || thornsTraits == 3)
//                        {
//                            //red, leaves, bubbly, thorns
//                            gameObject.GetComponent<SpriteRenderer>().sprite = arr[0];
//                        }

//                        else
//                        {
//                            //red, leaves, bubbly, no thorns
//                            gameObject.GetComponent<SpriteRenderer>().sprite = arr[1];
//                        }
//                    }

//                    else
//                    {
//                        if (thornsTraits == 1 || thornsTraits == 3)
//                        {
//                            //red, leaves, skinny, thorns
//                            gameObject.GetComponent<SpriteRenderer>().sprite = arr[2];
//                        }

//                        else
//                        {
//                            //red, leaves, skinny, no thorns
//                            gameObject.GetComponent<SpriteRenderer>().sprite = arr[3];
//                        }
//                    }
//                }

//                else
//                {
//                    if (petalTraits == 1 || petalTraits == 3)
//                    {
//                        if (thornsTraits == 1 || thornsTraits == 3)
//                        {
//                            //red, no leaves, bubby, thorns
//                            gameObject.GetComponent<SpriteRenderer>().sprite = arr[4];
//                        }

//                        else
//                        {
//                            //red, no leaves, bubby. no thrns
//                            gameObject.GetComponent<SpriteRenderer>().sprite = arr[5];
//                        }
//                    }

//                    else
//                    {
//                        if (thornsTraits == 1 || thornsTraits == 3)
//                        {
//                            //red, no leaves, skinny, thorns
//                            gameObject.GetComponent<SpriteRenderer>().sprite = arr[6];
//                        }

//                        else
//                        {
//                            //red, no leaves, skinny, no thorns
//                            gameObject.GetComponent<SpriteRenderer>().sprite = arr[7];
//                        }
//                    }
//                }
//            }

//            if(colorTraits == 2)
//            {
//                if (stemTraits == 1 || stemTraits == 3)
//                {
//                    if (petalTraits == 1 || petalTraits == 3)
//                    {
//                        if (thornsTraits == 1 || thornsTraits == 3)
//                        {
//                            //blue, leaves, bubbly, thorns
//                            gameObject.GetComponent<SpriteRenderer>().sprite = arr[8];
//                        }

//                        else
//                        {
//                            //blue, leaves, bubbly, no thorns
//                            gameObject.GetComponent<SpriteRenderer>().sprite = arr[9];
//                        }
//                    }

//                    else
//                    {
//                        if (thornsTraits == 1 || thornsTraits == 3)
//                        {
//                            //blue, leaves, skinny, thorns
//                            gameObject.GetComponent<SpriteRenderer>().sprite = arr[10];
//                        }

//                        else
//                        {
//                            //blue, leaves, skinny, no thorns
//                            gameObject.GetComponent<SpriteRenderer>().sprite = arr[11];
//                        }
//                    }
//                }

//                else
//                {
//                    if (petalTraits == 1 || petalTraits == 3)
//                    {
//                        if (thornsTraits == 1 || thornsTraits == 3)
//                        {
//                            //blue, no leaves, bubby, thorns
//                            gameObject.GetComponent<SpriteRenderer>().sprite = arr[12];
//                        }

//                        else
//                        {
//                            //blue, no leaves, bubby. no thrns
//                            gameObject.GetComponent<SpriteRenderer>().sprite = arr[13];
//                        }
//                    }

//                    else
//                    {
//                        if (thornsTraits == 1 || thornsTraits == 3)
//                        {
//                            //blue, no leaves, skinny, thorns 
//                            gameObject.GetComponent<SpriteRenderer>().sprite = arr[14];
//                        }

//                        else
//                        {
//                            //blue, no leaves, skinny, no thorns
//                            gameObject.GetComponent<SpriteRenderer>().sprite = arr[15];
//                        }
//                    }
//                }
//            }

//            if(colorTraits == 3)
//            {
//                if (stemTraits == 1 || stemTraits == 3)
//                {
//                    if (petalTraits == 1 || petalTraits == 3)
//                    {
//                        if (thornsTraits == 1 || thornsTraits == 3)
//                        {
//                            //purple, leaves, bubbly, thorns
//                            gameObject.GetComponent<SpriteRenderer>().sprite = arr[0];
//                            gameObject.GetComponent<SpriteRenderer>().color = new Color(.4f, .2f, 1, 1);
//                        }

//                        else
//                        {
//                            //purple, leaves, bubbly, no thorns
//                            gameObject.GetComponent<SpriteRenderer>().sprite = arr[1];
//                            gameObject.GetComponent<SpriteRenderer>().color = new Color(.4f, .2f, 1, 1);
//                        }
//                    }

//                    else
//                    {
//                        if (thornsTraits == 1 || thornsTraits == 3)
//                        {
//                            //purple, leaves, skinny, thorns
//                            gameObject.GetComponent<SpriteRenderer>().sprite = arr[2];
//                            gameObject.GetComponent<SpriteRenderer>().color = new Color(.4f, .2f, 1, 1);
//                        }

//                        else
//                        {
//                            //purple, leaves, skinny, no thorns
//                            gameObject.GetComponent<SpriteRenderer>().sprite = arr[3];
//                            gameObject.GetComponent<SpriteRenderer>().color = new Color(.4f, .2f, 1, 1);
//                        }
//                    }
//                }

//                else
//                {
//                    if (petalTraits == 1 || petalTraits == 3)
//                    {
//                        if (thornsTraits == 1 || thornsTraits == 3)
//                        {
//                            //purple, no leaves, bubby, thorns
//                            gameObject.GetComponent<SpriteRenderer>().sprite = arr[4];
//                            gameObject.GetComponent<SpriteRenderer>().color = new Color(.4f, .2f, 1, 1);
//                        }

//                        else
//                        {
//                            //purple, no leaves, bubby. no thrns
//                            gameObject.GetComponent<SpriteRenderer>().sprite = arr[5];
//                            gameObject.GetComponent<SpriteRenderer>().color = new Color(.4f, .2f, 1, 1);
//                        }
//                    }

//                    else
//                    {
//                        if (thornsTraits == 1 || thornsTraits == 3)
//                        {
//                            //purple, no leaves, skinny, thorns 
//                            gameObject.GetComponent<SpriteRenderer>().sprite = arr[6];
//                            gameObject.GetComponent<SpriteRenderer>().color = new Color(.4f, .2f, 1, 1);
//                        }

//                        else
//                        {
//                            //purple, no leaves, skinny, no thorns
//                            gameObject.GetComponent<SpriteRenderer>().sprite = arr[7];
//                            gameObject.GetComponent<SpriteRenderer>().color = new Color(.4f, .2f, 1, 1);
//                        }
//                    }
//                }
//            }
