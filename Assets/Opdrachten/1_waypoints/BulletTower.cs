using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTower : Tower
{
    
    // Start is called before the first frame update
    void Start()
    {
        start();
        path1.level = 1;
        
        damage = 1;
        framesBetweenShots = 180;
    }

    // Update is called once per frame
    void Update()
    {
        update();


    }
}
