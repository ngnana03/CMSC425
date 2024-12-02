using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupitem : MonoBehaviour,Interactionterminal
{
    // world number for which world the item belongs to
    public int worldnumber = 1;
    // references to the other items
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    
    public bool Interactwithitem(PlayerSystem other)
    {
        // references to the other items
        if (worldnumber == 1)
        {
            // the true and falses for items that you picked up
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
        }
        // dissapear the item if it is picked up 
        item1.SetActive((!(other.item_1)));
        item2.SetActive((!(other.item_2)));
        item3.SetActive((!(other.item_3)));
        // dissapear the item if it is picked up 
        other.ItemDetect = false;

        return true;
    }
}
