using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTower : Tower
{
    ParticleSystem p;
    // Start is called before the first frame update
    void Start()
    {
        p = GetComponent<ParticleSystem>();
        pathlvl1 = 1;
        pathlvl2 = 1;
        damage = 3;
        framesBetweenShots = 30;
    }
    
    // Update is called once per frame
    override protected void Update()
    {
        base.Update();
        if (colliders.Length > 0)
            timer++;
        else timer = framesBetweenShots - 1;
        
        
            if (timer % framesBetweenShots == 0)
            {
                FireRing( );
            }
     
    }
    void FireRing()
    {
        p.Play();
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].GetComponent<Opdrachten.PathFollower>().currentHp -= damage;
        }
    }
}
