using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 20.0f;

    public int colorTraits;
    public int stemTraits;
    public int petalTraits;
    public int thornsTraits;

    public int colorTraits2;
    public int stemTraits2;
    public int petalTraits2;
    public int thornsTraits2;

    private bool onFlower = false;
    private GameObject flower;
    private GameObject lastFlower;

    private bool placedFirstTraits;

    private bool onPod = false;
    private GameObject pod;

    private bool onTable = false;
    private GameObject breedingTable;

    public float speed;
    private Vector3 target;

    private bool canOpen = true;
    public GameObject grabGenesOption;

    private bool canOpenPlace = true;
    public GameObject placeGenesOption;

    private bool canOpenBreed = true;
    public GameObject breedGenesOption;

    private int currentArea;

    void Start()
    {
        breedingTable = GameObject.Find("Breeding Table");
        target = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        OpenGeneOption();
        OpenPlaceOption();
        OpenBreedOption();
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        rb.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    void Movement()
    {
        if (Input.GetMouseButtonDown(0) && !grabGenesOption.activeInHierarchy && !placeGenesOption.activeInHierarchy && !breedGenesOption.activeInHierarchy)
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    public void GrabGenes()
    {
        if (colorTraits == 0)
        {
            colorTraits = flower.GetComponent<FlowerBehaviour>().colorTraits;
            stemTraits = flower.GetComponent<FlowerBehaviour>().stemTraits;
            petalTraits = flower.GetComponent<FlowerBehaviour>().petalTraits;
            thornsTraits = flower.GetComponent<FlowerBehaviour>().thornsTraits;
        }
        else if(colorTraits != 0 && colorTraits2 != 0)
        {
            MoveGenesUp();
            colorTraits2 = flower.GetComponent<FlowerBehaviour>().colorTraits;
            stemTraits2 = flower.GetComponent<FlowerBehaviour>().stemTraits;
            petalTraits2 = flower.GetComponent<FlowerBehaviour>().petalTraits;
            thornsTraits2 = flower.GetComponent<FlowerBehaviour>().thornsTraits;
        }
        else
        {
            colorTraits2 = flower.GetComponent<FlowerBehaviour>().colorTraits;
            stemTraits2 = flower.GetComponent<FlowerBehaviour>().stemTraits;
            petalTraits2 = flower.GetComponent<FlowerBehaviour>().petalTraits;
            thornsTraits2 = flower.GetComponent<FlowerBehaviour>().thornsTraits;
        }

    }

    void MoveGenesUp()
    {
        colorTraits = colorTraits2;
        stemTraits = stemTraits2;
        petalTraits = petalTraits2;
        thornsTraits = thornsTraits2;
        colorTraits2 = 0;
        stemTraits2 = 0;
        petalTraits2 = 0;
        thornsTraits2 = 0;
    }

    public void CloseGeneOption()
    {
        grabGenesOption.SetActive(false);
        canOpen = false;
    }
    void OpenGeneOption()
    {
        if (onFlower == true && grabGenesOption.activeInHierarchy == false && canOpen)
        {
            Vector3 offset = new Vector3(0, -2.1f);
            Vector3 menuPos = flower.transform.position + offset;
            grabGenesOption.transform.position = Camera.main.WorldToScreenPoint(menuPos);
            grabGenesOption.SetActive(true);
        }
    }

    public void ClosePlaceOption()
    {
        placeGenesOption.SetActive(false);
        canOpenPlace = false;
    }

    
    void OpenPlaceOption()
    {
        if (onPod == true && placeGenesOption.activeInHierarchy == false && canOpenPlace)
        {
            Vector3 offset = new Vector3(0, -2.1f);
            Vector3 menuPos = pod.transform.position + offset;
            placeGenesOption.transform.position = Camera.main.WorldToScreenPoint(menuPos);
            placeGenesOption.SetActive(true);
        }
    }

    public void CloseBreedOption()
    {
        breedGenesOption.SetActive(false);
        canOpenBreed = false;
    }


    void OpenBreedOption()
    {
        if (onTable == true && breedGenesOption.activeInHierarchy == false && canOpenBreed)
        {
            Vector3 offset = new Vector3(0, -2.1f);
            Vector3 menuPos = breedingTable.transform.position + offset;
            breedGenesOption.transform.position = Camera.main.WorldToScreenPoint(menuPos);
            breedGenesOption.SetActive(true);
        }
    }
    //public void Breed()
    //{
    //    pod.GetComponent<PotBehaviour>().StartSquare();
    //}

    public void GiveGenes()
    {
        pod.GetComponent<PodBehavior>().colorTraits = colorTraits;
        pod.GetComponent<PodBehavior>().stemTraits = stemTraits;
        pod.GetComponent<PodBehavior>().petalTraits = petalTraits;
        pod.GetComponent<PodBehavior>().thornsTraits = thornsTraits;
        pod.GetComponent<PodBehavior>().hasTraits = true;
        MoveGenesUp();
        pod.GetComponent<PodBehavior>().SendTraits();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("flower"))
        {
            canOpen = true;
            onFlower = true;
            flower = col.gameObject;
            flower.GetComponent<FlowerBehaviour>().Grow();
        }

        if (col.gameObject.CompareTag("pod"))
        {
            canOpenPlace = true;
            onPod = true;
            pod = col.gameObject;
        }

        if (col.gameObject == breedingTable)
        {
            canOpenBreed = true;
            onTable = true;
        }

        if (col.gameObject.name == "SwitchAreaButton")
        {
            Vector3 cameraPosChange = new Vector3(18.1f, 0);
            Vector3 playerPosChange = new Vector3(4, 0);
            currentArea++;
            if (currentArea % 2 == 1) 
            {
                // Goes to ship
                Camera.main.transform.position += cameraPosChange;
                transform.position += playerPosChange;
            }
            else
            {
                // Goes to planet
                Camera.main.transform.position -= cameraPosChange;
                transform.position -= playerPosChange;
            }
            CancelMovement();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("flower"))
        {
            onFlower = false;
            lastFlower = flower;
            lastFlower.GetComponent<FlowerBehaviour>().Shrink();
        }

        if (col.gameObject.CompareTag("pod"))
        {
            onPod = false;
            lastFlower = flower;
        }

        if (col.gameObject == flower)
        {
            canOpen = true;
        }
    }
    
    void CancelMovement()
    {
        target = transform.position;
    }

}
