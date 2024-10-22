using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportSystem : MonoBehaviour, Interactionterminal
{
    // Start is called before the first frame update
    public Transform TargetLocation;

    public bool Interactwithitem(PlayerSystem other)
    {


        Debug.Log(other.transform.position);
        Debug.Log(TargetLocation.position);
        other.transform.position = TargetLocation.position;
        other.transform.eulerAngles = new Vector3(0,180,0);

        return true;
    }
}
