using UnityEngine;
using System.Collections;

public class Leader : MonoBehaviour {    
    public int leaderSpeed;
	public void SetLeader()
    {
        GetComponent<topMovement>().SetMaxSpeed(leaderSpeed);        
    }
    public void SetHat()
    {
        GetComponentInChildren<TurnOnHat>().Switch();
    }
}
