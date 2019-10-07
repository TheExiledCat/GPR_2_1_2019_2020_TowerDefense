using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{

    public IEnumerator shake(GameObject g, float dist)
    {
        Vector3 origin = g.transform.position;
        for (int i = 0; i < 10; i++)
        {

            g.transform.position += Vector3.right * dist;
            yield return new WaitForEndOfFrame();
        }
        for (int i = 0; i < 20; i++)
        {
            g.transform.position -= Vector3.right * dist;
            yield return new WaitForEndOfFrame();
        }
        g.transform.position = origin;
        yield return null;
    }
}
