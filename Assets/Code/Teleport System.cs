using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class TeleportSystem : MonoBehaviour, Interactionterminal
{
    // this code is for changing the worlds 

    public string sleeptext_item_1;
    public string sleeptext_item_2;
    public string sleeptext_item_3;
    public TextMeshProUGUI imagesleep;
    public GameObject textsleepscreen;

    

    public bool Interactwithitem(PlayerSystem other)
    {
        if (other.item_1 == true || other.item_2 == true || other.item_3 == true)
        {

            other.transform.eulerAngles = new Vector3(0, 180, 0);
            // disable player movement when in bed
            PlayerMovement s2 = other.GetComponent<PlayerMovement>();
            other.transform.GetChild(0).gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
            s2.canMove = false;
            // text related to which scene we are going to.
            if (other.item_1 == true)
            {
                imagesleep.text = sleeptext_item_1;
            }
            if (other.item_2 == true)
            {
                imagesleep.text = sleeptext_item_2;
            }
            if (other.item_3 == true)
            {
                imagesleep.text = sleeptext_item_3;
            }
            textsleepscreen.SetActive(true);
            other.sleep = true;

            StartCoroutine(SpawnDelay(other));
            
        }
        else
        {
            // tell player to pick up an item
            textsleepscreen.SetActive(true);
            imagesleep.text = "select an item";
            StartCoroutine(falseitemdelay(other));
            Debug.Log(imagesleep.text);
        }
        return true;
    }


    private IEnumerator falseitemdelay(PlayerSystem other)
    {
        // wait for a couple of seconds before making the message disapear. 
        yield return new WaitForSeconds(2);
        textsleepscreen.SetActive(false);
        imagesleep.text = "";
    }

    private IEnumerator SpawnDelay(PlayerSystem other)
    {
        // teleport system, wait couple of seconds before teleporting 
        yield return new WaitForSeconds(3);
        playerteleport(other);
        PlayerMovement s2 = other.GetComponent<PlayerMovement>();
        s2.canMove = true;
        // setting the displays
        other.sleep = false;
        imagesleep.text = null;
    }
    // going ot the correct world. 
    private bool playerteleport(PlayerSystem other)
        {
            if (other.item_1 == true)
            {
                SceneManager.LoadScene("Dating");

            }
            if (other.item_2 == true)
            {
                SceneManager.LoadScene("JumpScare");
            }
            if (other.item_3 == true)
            {
                SceneManager.LoadScene("RedGreenCubes");
            }
            return true;
        }
}
