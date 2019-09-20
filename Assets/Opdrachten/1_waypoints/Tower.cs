using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    bool isActive=true;
    protected float shootRadius;
    protected GameObject BulletPref;
    protected int damage;
    GameObject target;
    GameObject barrel;
   
    public PathTree path1;
    public PathTree path2;
    protected int timer = 0;
    public GameObject[] towerOptions;
    protected int framesBetweenShots=1;
    public Sprite uisprite;
    protected int cost;
    protected void start()
    {
       
    }
    protected void Shoot()
    {
        if(target!=null)
        barrel.transform.LookAt(target.transform);

    }
    
    protected void update()
    {
        path1.currentSprite = path1.sprites[path1.level - 1];
         path2.currentSprite = path2.sprites[path2.level - 1];
        
        timer++;
        if (timer % framesBetweenShots == 0)
        {
            Shoot();
        }
    }
}
