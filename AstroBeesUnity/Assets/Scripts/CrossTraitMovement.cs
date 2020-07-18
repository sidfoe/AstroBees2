using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CrossTraitMovement : MonoBehaviour
{
    public float speed;

    private bool moving = false;
    float fraction = 0;

    private Vector3 startPos;
    private Vector3 endPos;

    public Vector3 startScale;
    public Vector3 endScale;

    private Vector3 increment = new Vector3(.001f, .001f, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            if (fraction < 1)
            {
                fraction += Time.deltaTime * speed;
            }
            transform.localPosition = Vector3.Lerp(startPos, endPos, fraction);
            if (transform.localPosition == endPos)
            {
                moving = false;
                fraction = 0;

            }
            if (transform.localScale.x < endScale.x)
            {
                transform.localScale += increment;
            }
        }
    }

    public void StartMovement(Vector3 start, Vector3 end)
    {
        transform.localScale = startScale;
        startPos = start;
        endPos = end;
        moving = true;
    }
}
