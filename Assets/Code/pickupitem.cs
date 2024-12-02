using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupitem : MonoBehaviour,Interactionterminal
{
    public int worldnumber = 1;
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    // Start is called before the first frame update
    public bool Interactwithitem(PlayerSystem other)
    {
        if (worldnumber == 1)
        {
            if (other.item_1 == false)
            {
                other.item_1 = true;
            }
            else
            {
                other.item_1 = false;
            }
            other.item_2 = false;
            other.item_3 = false;
            //item1.SetActive((!(other.item_1)));
            //item2.SetActive((!(other.item_2)));
            //item3.SetActive((!(other.item_3)));
        }
        if (worldnumber == 2)
        {
            if (other.item_2 == false)
            {
                other.item_2 = true;
            }
            else
            {
                other.item_2 = false;
            }
            other.item_1 = false;
            other.item_3 = false;
            //item2.SetActive((!(other.item_2)));
        }
        if (worldnumber == 3)
        {
            if (other.item_3 == false)
            {
                other.item_3 = true;
            }
            else
            {
                other.item_3 = false;
            }
            other.item_1 = false;
            other.item_2 = false;
            //item3.SetActive((!(other.item_3)));
        }
        item1.SetActive((!(other.item_1)));
        item2.SetActive((!(other.item_2)));
        item3.SetActive((!(other.item_3)));
        other.ItemDetect = false;
        //yield return new WaitForSeconds(4);
        return true;
    }
}
