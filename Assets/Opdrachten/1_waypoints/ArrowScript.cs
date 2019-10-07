using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public Transform targetPos;
    Vector3 startPos;
    float speed = 5;
    float startTime;
    float Length;
    int indexframe;
    private void Start()
    {
        startPos = transform.position;
        startTime = Time.time;
     
        Length = Vector3.Distance(startPos, targetPos.position);
    }
    // Update is called once per frame
    void Update()
    {
        indexframe++;
        if (indexframe % 300 == 0)
        {
            indexframe = 0;
            GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
        }
        if (Vector3.Distance(transform.position, targetPos.position) < 0.5f)
        {
            transform.position = startPos;
            startTime = Time.time;
          
    
            print("DONE");
         
        }
        float coveredDist = ((Time.time - startTime) * speed) / Length;
        transform.position = Vector3.Lerp(startPos, targetPos.position, coveredDist);

    }
}
