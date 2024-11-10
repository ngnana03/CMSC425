using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TeleportSystem : MonoBehaviour, Interactionterminal
{
    // Start is called before the first frame update
    public Transform world_item_1;
    public Transform world_item_2;
    public Transform world_item_3;
    public string sleeptext_item_1;
    public string sleeptext_item_2;
    public string sleeptext_item_3;
    public TextMeshProUGUI imagesleep;
    public GameObject textsleepscreen;

    

    public bool Interactwithitem(PlayerSystem other)
    {
        if (other.item_1 == true || other.item_2 == true || other.item_3 == true)
        {
            //other.transform.position = transform.position;
            other.transform.eulerAngles = new Vector3(0, 180, 0);

            PlayerMovement s2 = other.GetComponent<PlayerMovement>();
            other.transform.GetChild(0).gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
            s2.canMove = false;
            
            textsleepscreen.SetActive(true);
            other.sleep = true;

            StartCoroutine(SpawnDelay(other));
        }
        return true;
    }
    private IEnumerator SpawnDelay(PlayerSystem other)
    {
        yield return new WaitForSeconds(3);
        playerteleport(other);
        //other.transform.position = world_item_1.position;
        PlayerMovement s2 = other.GetComponent<PlayerMovement>();
        s2.canMove = true;
        
        other.sleep = false;
        imagesleep.text = null;
    }

    private bool playerteleport(PlayerSystem other)
        {
            if (other.item_1 == true)
            {
                other.transform.position = world_item_1.transform.position;
                imagesleep.text = sleeptext_item_1;

            }
            if (other.item_2 == true)
            {
                other.transform.position = world_item_2.transform.position;
                imagesleep.text = sleeptext_item_2;
            }
            if (other.item_3 == true)
            {
                other.transform.position = world_item_3.transform.position;
                imagesleep.text = sleeptext_item_3;
            }
            return true;
        }
}
