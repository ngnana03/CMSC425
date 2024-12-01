using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Dia : MonoBehaviour
{
    //public PlayerMovement playm;
    public GameObject canvas;
    public GameObject option1;
    public GameObject option2;

    public static string currPos = "Boo";       // the current string to start at before going down routes

    public string BooA = "I'd like to get to know you better. You seem... interesting.";

    public string BooReplyFirst = "I've been waiting for someone bold enough to accompany me. Aren't you brave, or just foolish? I'd be lying if I said I wasn't intrigued.";

    public string BooAA = "I’m not sure... but I’ve always wanted to understand the mysteries of life";
    public string BooAB = "Uh, I’m not sure I’m ready for all of that. Maybe we should just keep it simple.";
    public string BooReplyA = "Not many are brave enough to see the beauty in the other side. Tell me.. what is it you seek from this world? Perhaps I could help. "; 




    public string BooB = "Ghosts are a little too... creepy for me.";

    public string BooBA = "I’m sorry if I offended you. This is all new to me. If you’re willing to, I’d love to talk more.";
    public string BooBB = "I think I prefer the living for now. Thanks, but lets just get this over with."; 
    public string BooReplyB = "Afraid of a little company from the afterlife? Hm I thought you were different..";

    public string BooAAA = "Companions sounds..great! Travelling with a ghost sounds awesome!";         // Good Ending
    public string BooAAB = "Hmm, companions in this life sounds good for now. Let me learn about you more before I decide the rest.";   // Positive Neutral Ending
    public string BooReplyAA = "You’re more like me than you realize. We could be… companions in this life, and the next. What do you think?";

    public string BooABA = "I'll help to the extent I can."; // Positive Neutral Ending
    public string BooABB = "Sounds like a lot of work..lets just enjoy the party"; // Negative Neutral Ending
    public string BooReplyAB = "Well! In simple terms, I'm a wandering ghost going to silly parties in hope of finding someone like you to help me. Would you help an old ghost tie loose ends? ";


    public string BooBAA = "I'll help to the extent I can.";  // Positive Neutral Ending
    public string BooBAB = "Sounds like a lot of work..lets just enjoy the party"; // Negative Neutral Ending
    public string BooReplyBA = "Well! A bit about me, I'm a wandering ghost going to silly parties in hope of finding someone like you to help me. Would you help an old ghost tie loose ends? "; 


    public string BooBBA = "Sure, nothing else better to do.."; // Negative Neutral Ending
    public string BooBBB = "No, I'll stay right here."; // Bad ending (he ditches you)
    public string BooReplyBB = "What a sour attitude... I'm going to get some refreshments, would you like to join?";

    



    public Transform Atext;         // need to make sure text is aware of each other
    public Transform Btext;

    public static int BooSync = 0; // tracks likeabilty;

    public Transform BooResponse; // for Boo's lines


 /*   public bool Interactwithitem(PlayerSystem other)
    {
        canvas.SetActive(true);
        ActualStart();
        return true;
    } */



    // Start is called before the first frame update
    void Start()
    {

        BooResponse.GetComponent<TextMeshPro>().text = BooReplyFirst;   // add gui 
        Atext.GetComponent<TextMeshPro>().text = BooA;      // Grab the text GUI component and set it to...
        Btext.GetComponent<TextMeshPro>().text = BooB;
        

    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void OnMouseDown()
    {
        // Atext.GetComponent<TextMeshProUGUI>().text = currPos;
        // currPos += "A";

        currPos += gameObject.name;

        if (currPos == "BooA")
            {
                Atext.GetComponent<TextMeshPro>().text = BooAA;
                Btext.GetComponent<TextMeshPro>().text = BooAB;
                BooResponse.GetComponent<TextMeshPro>().text = BooReplyA;
           
        }
        
        if (currPos == "BooAA")
            {
                Atext.GetComponent<TextMeshPro>().text = BooAAA;
                Btext.GetComponent<TextMeshPro>().text = BooAAB;
                BooResponse.GetComponent<TextMeshPro>().text = BooReplyAA;
            //currPos = "BooAA";
           
            
            }
         if (currPos == "BooAB")
            {
                Atext.GetComponent<TextMeshPro>().text = BooABA;
                Btext.GetComponent<TextMeshPro>().text = BooABB;
                BooResponse.GetComponent<TextMeshPro>().text = BooReplyAB;
            }

           if (currPos == "BooBA")
            {
                Atext.GetComponent<TextMeshPro>().text = BooBAA;
                Btext.GetComponent<TextMeshPro>().text = BooBAB;
                BooResponse.GetComponent<TextMeshPro>().text = BooReplyBA;
            }

           if (currPos == "BooBB")     
            {
                Atext.GetComponent<TextMeshPro>().text = BooBBA;
                Btext.GetComponent<TextMeshPro>().text = BooBBB;
                BooResponse.GetComponent<TextMeshPro>().text = BooReplyBB;
            }

        if (currPos == "BooB")
        {
            Atext.GetComponent<TextMeshPro>().text = BooBA;
            Btext.GetComponent<TextMeshPro>().text = BooBB;
            BooResponse.GetComponent<TextMeshPro>().text = BooReplyB;

        }

                if (currPos == "BooAAA")    // Good Ending!
                {
                    option1.SetActive(false);
                    option2.SetActive(false);
                    BooResponse.GetComponent<TextMeshPro>().text = "You and Boo travel the after life together as companions..";
                }

                if (currPos == "BooBBA" || currPos == "BooABB" || currPos == "BooBAB")    // Neutral Negative
                {
                    option1.SetActive(false);
                    option2.SetActive(false);
                    BooResponse.GetComponent<TextMeshPro>().text = "You and Boo go around the party and mingle. Boo seems to be incredibly disheartened and distant most of the time.";
                }

                if (currPos == "BooBAA" || currPos == "BooABA" || currPos == "AAB") // Neutral Positive
                {
                    option1.SetActive(false);
                    option2.SetActive(false);
                    BooResponse.GetComponent<TextMeshPro>().text = "You and Boo go around the party and make normal conversation, becoming ok friends.";
                }

                if (currPos == "BooBBB")        // Bad Ending
        {
            option1.SetActive(false);
            option2.SetActive(false);
            BooResponse.GetComponent<TextMeshPro>().text = "Boo goes to get refreshments but never comes back. You are left stranded at the party.";
        }
                
    }

  

}
