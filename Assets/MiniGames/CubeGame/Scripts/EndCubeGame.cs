using UnityEngine;
using System.Collections;

public class EndCubeGame : MonoBehaviour {
    //list of zones for cube mini game
    CheckForCubes[] zoneList;

    public void End()
    {   
        //takes all zones and appends the checkforcubes script to a list     
        zoneList = gameObject.GetComponentsInChildren<CheckForCubes>();
        //for each zone check how many cubes are inside of it.
        foreach (CheckForCubes zone in zoneList)
        {
            zone.CheckCubes();
        }       
    }
}
