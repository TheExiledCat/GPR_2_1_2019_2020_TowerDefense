using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Opdrachten
{
    
    /// <summary>
    /// De path class beheerd een array van waypoints. En houd bij bij welk waypoint een object is.
    /// Deze vormen samen het pad. 
    /// Logica die op het path niveau plaatsvindt gebeurt in deze class.
    /// Een deel van de functies welke je nodig hebt zijn hier al beschreven.
    /// </summary>
    public class Path : MonoBehaviour
    {
        
        public Waypoint[] waypoints;
        /// <summary>
        /// Deze functie returned het volgende waypoint waar naartoe kan worden bewogen.
        /// </summary>
        public Waypoint GetNextWaypoint(int index, GameObject Caller)
        {
            if (index < waypoints.Length - 1)
            {
                index++;
                // dit is nu niet goed, zorg ervoor dat het goede waypoint wordt teruggegeven.
                return waypoints[index];
            }
            else { GameManager.GM.enemies.Remove(Caller); GameManager.GM.HP -= Caller.GetComponent<PathFollower>().damage; Destroy(Caller); GameManager.GM.LessEnemies();  }
            
            return null;
        }
       
        
    }
}
