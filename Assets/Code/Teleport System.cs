using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TeleportSystem : MonoBehaviour, Interactionterminal
{
    // Start is called before the first frame update
    public Transform TargetLocation;
    public string sleeptext;
    public TextMeshProUGUI imagesleep;
    public GameObject textsleepscreen;

    

    public bool Interactwithitem(PlayerSystem other)
    {
        other.transform.position = transform.position;
        other.transform.eulerAngles = new Vector3(0, 180, 0);
        //other.PlayerMovement.canMove = false;
        PlayerMovement s2 = other.GetComponent<PlayerMovement>();
        other.transform.GetChild(0).gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
        s2.canMove = false;
        imagesleep.text = sleeptext;
        textsleepscreen.SetActive(true);
        other.sleep = true;

        StartCoroutine(SpawnDelay(other));
        
        return true;
    }
    private IEnumerator SpawnDelay(PlayerSystem other)
    {
        yield return new WaitForSeconds(3);
        Debug.Log(other.transform.position);
        Debug.Log(TargetLocation.position);
        other.transform.position = TargetLocation.position;
        PlayerMovement s2 = other.GetComponent<PlayerMovement>();
        s2.canMove = true;
        
        other.sleep = false;
        imagesleep.text = null;
    }

}
