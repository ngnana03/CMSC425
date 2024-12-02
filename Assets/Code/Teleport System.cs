using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
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
            
            textsleepscreen.SetActive(true);
            imagesleep.text = "select an item";
            falseitemdelay(other);
            Debug.Log(imagesleep.text);
            //textsleepscreen.SetActive(false);

        }
        return true;
    }

    private IEnumerator falseitemdelay(PlayerSystem other)
    {
        yield return new WaitForSeconds(3);
        textsleepscreen.SetActive(false);
    }

    private IEnumerator SpawnDelay(PlayerSystem other)
    {
        yield return new WaitForSeconds(3);
        playerteleport(other);
        PlayerMovement s2 = other.GetComponent<PlayerMovement>();
        s2.canMove = true;
        
        other.sleep = false;
        imagesleep.text = null;
    }

    private bool playerteleport(PlayerSystem other)
        {
            if (other.item_1 == true)
            {
            ////other.transform.position = world_item_1.transform.position;
                SceneManager.LoadScene("JumpScare");

            }
            if (other.item_2 == true)
            {
                //other.transform.position = world_item_2.transform.position;
                SceneManager.LoadScene("RedGreenCubes");
            }
            if (other.item_3 == true)
            {
                //other.transform.position = world_item_3.transform.position;
                SceneManager.LoadScene("Dating");
            }
            return true;
        }
}
