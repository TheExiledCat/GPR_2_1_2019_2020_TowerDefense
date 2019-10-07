using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    bool isActive=true;
    [SerializeField]
    protected float shootRadius;
    [SerializeField]
    protected GameObject BulletPref;
    protected int damage;


   
    public PathTree path1;
    public PathTree path2;
    protected int timer = 0;
    public GameObject[] towerOptions;
    protected int framesBetweenShots=1;
    public Sprite uisprite;
    public int cost;
    GameObject _target;
    public bool targeted;
    [SerializeField]
    protected Collider[] colliders;
    [HideInInspector]
    public int pathlvl1, pathlvl2;
    [HideInInspector]
    public Sprite path1sprite, path2sprite;
    public LayerMask enemyLayer;
    void Start()
    {
        pathlvl1 = 1;
        pathlvl2 = 1;
    }
   virtual protected void Update()
    {
         colliders = Physics.OverlapSphere(transform.position, shootRadius,enemyLayer);
         
        if (colliders.Length > 0) 
        print(colliders[0].gameObject);
        path1sprite = path1.sprites[pathlvl1 - 1];
        path2sprite = path2.sprites[pathlvl2 - 1];
        
      
        
    }
    virtual protected void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, shootRadius);
    }
    protected void Shoot(GameObject target, GameObject barrel, float bulletSpeed)
    {
        if (target != null)
            barrel.transform.LookAt(target.transform);
        GameObject bullet = Instantiate(BulletPref, barrel.transform.position, Quaternion.identity);
        bullet.AddComponent<Rigidbody>();
        bullet.GetComponent<Rigidbody>().useGravity = false;
        bullet.transform.LookAt(target.transform);
        bullet.AddComponent<ProjectileScript>();
        bullet.GetComponent<ProjectileScript>().damage = damage;
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
        
        Destroy(bullet, 2f);

    }
}
