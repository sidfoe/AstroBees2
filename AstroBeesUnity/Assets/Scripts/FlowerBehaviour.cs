using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlowerBehaviour : MonoBehaviour
{
    private GameObject cc; //canvas holding traits
    private bool ccUpdate = false;

    public int colorTraits;
    public int stemTraits;
    public int petalTraits;
    public int thornsTraits;

    private void Start()
    {
        cc = gameObject.transform.GetChild(0).gameObject;
    }

    private void LateUpdate()
    {
        if (ccUpdate == false)
        {
            ccUpdate = true;

            //cc.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = colorTraits[0, 0] + colorTraits[0, 1];
            //cc.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = stemTraits[0, 0] + stemTraits[0, 1];
            //cc.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = petalTraits[0, 0] + petalTraits[0, 1];
            //cc.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = thornsTraits[0, 0] + thornsTraits[0, 1];
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        cc.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        cc.SetActive(false);
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
}
