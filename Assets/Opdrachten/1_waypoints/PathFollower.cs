using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Opdrachten
{
    /// <summary>
    /// De path follower class is verantwoordelijk voor de beweging.
    /// Deze class zorgt ervoor dat het object (in Tower Defense) vaak een enemy, het path afloopt
    /// tip: je kunt de transform.LookAt() functie gebruiken en vooruitbewegen.
    /// </summary>
    
    public class PathFollower : MonoBehaviour
    {
        public int currentHp;
        public int hp;
        int index;
        public Waypoint target;
        public float speed;
        Path p;
        public int damage =1;
        private void Start()
        {
            currentHp = hp;
           p= GameObject.FindGameObjectWithTag("Path").GetComponent<Path>();

            index = 0;
           target= p.waypoints[0];
        }
        private void Update()
        {   
          if(target!=null)
            if (Vector3.Distance(transform.position, target.transform.position) < 0.1f) {
              
                
                    target = p.GetNextWaypoint(index, gameObject);
                    index++;
                
            }
            if (target != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.gameObject.transform.position, speed / 100);
                transform.LookAt(target.Position);
            }
            if (currentHp <= 0)
            {
                GameManager.GM.GetCash(100);
                Destroy(gameObject);
            }
        }
    }
}