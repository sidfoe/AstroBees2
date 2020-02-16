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

    private bool onFlower = false;
    private GameObject flower;
    private GameObject lastFlower;

    private bool onPot = false;
    private GameObject pot;

    public float speed;
    private Vector3 target;

    private bool canOpen = true;
    public GameObject grabGenesOption;

    private int currentArea;

    void Start()
    {
        target = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        GiveGenes();
        OpenGeneOption();
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
        if (Input.GetMouseButtonDown(0) && !grabGenesOption.activeInHierarchy)
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    public void GrabGenes()
    {
        colorTraits = flower.GetComponent<FlowerBehaviour>().colorTraits;
        stemTraits = flower.GetComponent<FlowerBehaviour>().stemTraits;
        petalTraits = flower.GetComponent<FlowerBehaviour>().petalTraits;
        thornsTraits = flower.GetComponent<FlowerBehaviour>().thornsTraits;
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
    void GiveGenes()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onPot == true)
        {
            pot.GetComponent<PotBehaviour>().colorTraits = colorTraits;
            pot.GetComponent<PotBehaviour>().stemTraits = stemTraits;
            pot.GetComponent<PotBehaviour>().petalTraits = petalTraits;
            pot.GetComponent<PotBehaviour>().thornsTraits = thornsTraits;
            pot.GetComponent<PotBehaviour>().StartSquare();
        }
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

        if (col.gameObject.CompareTag("pot"))
        {
            onPot = true;
            pot = col.gameObject;
        }

        if(col.gameObject.name == "SwitchAreaButton")
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

        if (col.gameObject.CompareTag("pot"))
        {
            onPot = false;
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
