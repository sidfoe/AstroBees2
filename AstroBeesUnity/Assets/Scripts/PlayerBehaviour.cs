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

    public GameObject grabGenesOption;

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
        
        if(Input.GetMouseButtonDown(0) && Time.timeScale != 0)
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
        flower.GetComponent<FlowerBehaviour>().Grow();
        Time.timeScale = 1;
        if (lastFlower != null && lastFlower != flower)
        {
            lastFlower.GetComponent<FlowerBehaviour>().Shrink();
        }
    }

    public void CloseGeneOption()
    {
        grabGenesOption.SetActive(false);
        Time.timeScale = 1;
    }
    void OpenGeneOption()
    {
         if (Input.GetKeyDown(KeyCode.Space) && onFlower == true)
         {
             Vector3 offset = new Vector3(0, -1.75f);
             Vector3 menuPos = flower.transform.position + offset;
             grabGenesOption.transform.position = Camera.main.WorldToScreenPoint(menuPos);
             grabGenesOption.SetActive(true);
             Time.timeScale = 0;
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
            onFlower = true;
            flower = col.gameObject;
        }

        if (col.gameObject.CompareTag("pot"))
        {
            onPot = true;
            pot = col.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("flower"))
        {
            onFlower = false;
            lastFlower = flower;
        }

        if (col.gameObject.CompareTag("pot"))
        {
            onPot = false;
            lastFlower = flower;
        }
    }
}
