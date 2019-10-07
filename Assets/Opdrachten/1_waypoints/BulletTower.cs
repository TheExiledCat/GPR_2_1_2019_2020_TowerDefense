using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTower : Tower
{
    GameObject target;
    public float bulletSpeed;
    // Start is called before the first frame update
     void Start()
    {

        pathlvl1 = 1;
        pathlvl2 = 1;

        damage = 1;
        framesBetweenShots = 30;
    }
    
    // Update is called once per frame
    override protected void Update()
   {
       base.Update();
        if (colliders.Length > 0)
            timer++;
        else timer = framesBetweenShots - 1;
        if(colliders.Length>0)
        target = colliders[0].gameObject;
        if (targeted)
            if (timer % framesBetweenShots == 0)
            {
                Shoot(target, gameObject,bulletSpeed);
            }
        Debug.Log(target);
    }
}
