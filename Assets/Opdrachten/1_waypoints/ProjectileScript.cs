using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [HideInInspector]
    public int damage;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (other.gameObject.GetComponent<Opdrachten.PathFollower>() != null)
            {
                other.gameObject.GetComponent<Opdrachten.PathFollower>().currentHp -= damage;
                print("HIT");
                Destroy(gameObject);
            }
        }
    }
}
