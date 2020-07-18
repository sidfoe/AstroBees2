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

    //public int colorTraits;
    public int stemTraits;
    public int petalTraits;
    public int thornsTraits;

    //public int colorTraits2;
    public int stemTraits2;
    public int petalTraits2;
    public int thornsTraits2;

    public Sprite currentSprite;
    public int currentTrait;

    private bool onFlower = false;
    private GameObject flower;
    private GameObject lastFlower;

    private bool placedFirstTraits;

    private bool onPod = false;
    private GameObject pod;

    private bool onTable = false;

    public float speed;
    private Vector3 target;

    private GameObject currentPanel;
    private bool canOpen = false;
    public GameObject grabGenesPanel;
    public GameObject placeGenesPanel;
    public GameObject breedGenesPanel;

    public GameObject breedingTable;

    public GameObject firstPod;

    private GameObject obj;

    private int currentArea;

    private ParticleSystem lastFlowerPS; //the flower particle system, when collected it plays until we have an animation or in addition to the animation

    public bool goneOutside = false;

    void Start()
    {
        pod = firstPod;
        currentPanel = grabGenesPanel;
        target = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        OpenPanel();
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, transform.position - mousePos);
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
        if (Input.GetMouseButtonDown(0) && !currentPanel.activeInHierarchy)
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    public void GrabGenes()
    {
        if (GameManager.tracker == 1)
        {
            currentSprite = flower.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
            //print(currentSprite.name);
            currentTrait = flower.GetComponent<FlowerBehaviour>().petalTraits;
        }
        else if (GameManager.tracker == 2)
        {
            currentSprite = flower.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;

            currentTrait = flower.GetComponent<FlowerBehaviour>().stemTraits;
        }
        else 
        {
            currentSprite = flower.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite;
            currentTrait = flower.GetComponent<FlowerBehaviour>().thornsTraits;
        }

        lastFlowerPS.Play();

        //else if(currentTrait != 0 && currentTrait2 != 0)
        //{
        //    MoveGenesUp();
        //    if (GameManager.tracker == 1)
        //    {
        //        currentTrait2 = flower.GetComponent<FlowerBehaviour>().petalTraits;
        //    }
        //    else if (GameManager.tracker == 2)
        //    {
        //        currentTrait2 = flower.GetComponent<FlowerBehaviour>().stemTraits;
        //    }
        //    else
        //    {
        //        currentTrait2 = flower.GetComponent<FlowerBehaviour>().thornsTraits;
        //    }
        //}
        //else
        //{
        //    if (GameManager.tracker == 1)
        //    {
        //        currentTrait2 = flower.GetComponent<FlowerBehaviour>().petalTraits;
        //    }
        //    else if (GameManager.tracker == 2)
        //    {
        //        currentTrait2 = flower.GetComponent<FlowerBehaviour>().stemTraits;
        //    }
        //    else
        //    {
        //        currentTrait2 = flower.GetComponent<FlowerBehaviour>().thornsTraits;
        //    }
        //}

        pod.GetComponent<PodBehavior>().traitSprite = currentSprite;
        pod.GetComponent<PodBehavior>().trait = currentTrait;
        pod.GetComponent<PodBehavior>().SendTraits();
        pod = pod.GetComponent<PodBehavior>().nextPod;
    }

    void OpenPanel()
    {
        if (currentPanel.activeInHierarchy == false && canOpen && (onFlower || onPod || onTable) && GameManager.tracker <= 3)
        {
            Vector3 offset = new Vector3(0, -2.1f);
            if (onFlower)
            {
                offset = GetOffset(flower.transform.position.x, flower.transform.position.y);
            }
            Vector3 menuPos = obj.transform.position + offset;
            canOpen = false;
            currentPanel.transform.position = Camera.main.WorldToScreenPoint(menuPos);
            currentPanel.SetActive(true);
        }
        else if (currentPanel.activeInHierarchy == false && canOpen && onTable && GameManager.tracker > 3 && currentPanel == breedGenesPanel)
        {
            Vector3 offset = new Vector3(0, -2.1f);
            Vector3 menuPos = obj.transform.position + offset;
            canOpen = false;
            currentPanel.transform.position = Camera.main.WorldToScreenPoint(menuPos);
            currentPanel.SetActive(true);
        }
    }
    public void ClosePanel()
    {
        currentPanel.SetActive(false);
        canOpen = false;
    }
    //void MoveGenesUp()
    //{
    //    currentTrait = currentTrait2;
    //    currentTrait2 = 0;
    //}
    public void GiveGenes()
    {
        if (GameManager.tracker == 1)
        {
            pod.GetComponent<PodBehavior>().trait = currentTrait;
        }
        else if (GameManager.tracker == 2)
        {
            pod.GetComponent<PodBehavior>().trait = currentTrait;
        }
        else
        {
            pod.GetComponent<PodBehavior>().trait = currentTrait;
        }

        //MoveGenesUp();
        
        pod.GetComponent<PodBehavior>().SendTraits();
    }

    Vector3 GetOffset(float xPos, float yPos)
    {
        Vector3 offset = new Vector3();
        if ((xPos >= -7.25 && xPos <= 7.25) && yPos >= -2)
        {
            offset = new Vector3(0, -2.1f);
        }
        else if ((xPos >= -7.25 && xPos <= 7.25) && yPos < -2)
        {
            offset = new Vector3(0, 1.8f);
        }
        else if (xPos > 7.25)
        {
            offset = new Vector3(-3, 0);
        }
        else if (xPos < -7.25)
        {
            offset = new Vector3(3, 0);
        }
        return offset;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("flower"))
        {
            canOpen = true;
            onFlower = true;
            obj = col.gameObject;
            currentPanel = grabGenesPanel;
            flower = col.gameObject;
            lastFlowerPS = col.gameObject.GetComponent<ParticleSystem>();
            flower.GetComponent<FlowerBehaviour>().Grow();
        }

        //if (col.gameObject.CompareTag("pod"))
        //{
        //    canOpen = true;
        //    onPod = true;
        //    obj = col.gameObject;
        //    currentPanel = placeGenesPanel;
        //    pod = col.gameObject;
        //}

        if (col.gameObject == breedingTable)
        {
            canOpen = true;
            onTable = true;
            obj = col.gameObject;
            currentPanel = breedGenesPanel;
        }

        if (col.gameObject.name == "SwitchAreaButton")
        {
            if (goneOutside == false)
            {
                goneOutside = true;
            }

            Vector3 cameraPosChange = new Vector3(18.1f, 0);
            Vector3 playerPosChange = new Vector3(4, 0);
            currentArea++;
            if (currentArea % 2 == 1) 
            {
                // Goes to ship
                Camera.main.transform.position -= cameraPosChange;
                transform.position -= playerPosChange;
            }
            else
            {
                // Goes to planet
                Camera.main.transform.position += cameraPosChange;
                transform.position += playerPosChange;
            }
            CancelMovement();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("flower"))
        {
            canOpen = true;
            onFlower = false;
            lastFlower = flower;
            lastFlower.GetComponent<FlowerBehaviour>().Shrink();
        }

        //if (col.gameObject.CompareTag("pod"))
        //{
        //    canOpen = true;
        //    onPod = false;
        //    lastFlower = flower;
        //}

        if (col.gameObject == flower)
        {
            canOpen = true;
        }
        if (col.gameObject == breedingTable)
        {
            canOpen = true;
            onTable = false;
        }
    }
    
    void CancelMovement()
    {
        target = transform.position;
    }

}
