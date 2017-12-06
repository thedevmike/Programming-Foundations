using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarlanMichael_Week2Game : MonoBehaviour
{
    Text Body;
    Page[] aBook;

    public string sPreviousHeading;
    public string sCurrentHeading;
    public string sNextHeading = "Welcome";

    public bool bHaveArtifact = false;
    public bool bCheckedHole = false;

    // Use this for initialization
    void Start()
    {
        Body = GameObject.Find("BodyText").GetComponent<Text>();
        Body = FindObjectOfType<Text>();
        BuildBook();
        RenderStory();
    }

    // Update is called once per frame
    void Update()
    {
        Gameplay();
        RenderStory();
        StepBack();
    }

    //STORY LOOP
    void RenderStory()
    {
        if (!string.IsNullOrEmpty(sNextHeading))
        {
            for (int nPage = 0; nPage < aBook.Length; nPage++)
            {
                if (sNextHeading == aBook[nPage].Heading)
                {
                    sPreviousHeading = sCurrentHeading;
                    sCurrentHeading = sNextHeading;
                    sNextHeading = "";

                    Debug.Log(aBook[nPage].Body);
                    Body.text = (aBook[nPage].Body);
                }
            }
        }
    }

    //GAMEPLAY MECHANICS
    void Gameplay()
    { //Welcome --> Wake up
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(sCurrentHeading == "Welcome")
            {
                sNextHeading = "Wake up";
            }
                //WAKE UP

            //Wake up --> Door
        } if (Input.GetKeyDown(KeyCode.D))
        {
            if (sCurrentHeading == "Wake up")
            {
                sNextHeading = "Door";
            }
            //Wake up --> Basket
        } else if (Input.GetKeyDown(KeyCode.W))
        {
            if (sCurrentHeading == "Wake up")
            {
                sNextHeading = "Basket";
            }
            //Wake up --> Bowl
        } else if (Input.GetKeyDown(KeyCode.B))
        {
            if (sCurrentHeading == "Wake up")
            {
                sNextHeading = "Bowl";
            } 
            //Wake up --> Hole
        } else if (Input.GetKeyDown(KeyCode.H))
        {
            bCheckedHole = true;
            if (sCurrentHeading == "Wake up")
            {
                sNextHeading = "Hole";
            }
        }
                //BASKET
            //Basket --> Kick
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (sCurrentHeading == "Basket")
            {
                sNextHeading = "Kick";
            }
        }

        //Open Trap Door
        if (bHaveArtifact == true && bCheckedHole == true)
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                if (sCurrentHeading == "Hole")
                {
                    sNextHeading = "Trap";
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            if (sCurrentHeading == "Hole")
            {
                sCurrentHeading = "Trap";
            }
        }
                //KICK
            //Kick --> Inspect
        if (Input.GetKeyDown(KeyCode.I))
        {
            bHaveArtifact = true;
            if (sCurrentHeading == "Kick")
            {
                sNextHeading = "Inspect";
            }
        }
                //BOWL
            //Bowl --> Pick up
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (sCurrentHeading == "Bowl")
            {
                sNextHeading = "Pick up";
            }
        }
                // PIC KUP
            //Pick up --> Drink
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (sCurrentHeading == "Pick up")
            {
                sNextHeading = "Pour";
            }
            //Pick up --> Pour
        } else if (Input.GetKeyDown(KeyCode.D))
        {
            if (sCurrentHeading == "Pick up")
            {
                sNextHeading = "Drink";
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (sCurrentHeading == "Trap")
            {
                sNextHeading = "Secret Room";
            }
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            if (sCurrentHeading == "Secret Room")
            {
                sNextHeading = "Crate";
            }
        } else if (Input.GetKeyDown(KeyCode.P))
        {
            if (sCurrentHeading == "Secret Room")
            {
                sNextHeading = "Window";
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (sCurrentHeading == "Crate")
            {
                sNextHeading = "Blow up";
            }
        } else if (Input.GetKeyDown(KeyCode.C))
        {
            if (sCurrentHeading == "Crate")
            {
                sNextHeading = "Window";
            }
        }

        //END GAME

        if (Input.GetKeyDown(KeyCode.Y) && sCurrentHeading == "Pour" || 
            Input.GetKeyDown(KeyCode.Y) && sCurrentHeading == "Drink" ||
            Input.GetKeyDown(KeyCode.Y) && sCurrentHeading == "Window" ||
            Input.GetKeyDown(KeyCode.Y) && sCurrentHeading == "Blow up")
        {
            sNextHeading = "Wake up";
        } else if (Input.GetKeyDown(KeyCode.N) && sCurrentHeading == "Pour" ||
                   Input.GetKeyDown(KeyCode.N) && sCurrentHeading == "Drink" ||
                   Input.GetKeyDown(KeyCode.N) && sCurrentHeading == "Window" ||
                   Input.GetKeyDown(KeyCode.N) && sCurrentHeading == "Blow up")
        {
            sNextHeading = "No";
        }

    }

    void StepBack()
    {   
        if (Input.GetKeyDown(KeyCode.X))
        {
            sNextHeading = sPreviousHeading;
        }
    }
    //Book Array
    void BuildBook()
    {
        aBook = new Page[]
        {  //WELCOME 
            new Page ("Welcome", "Welcome to the newest in Text Based Adventure Games \"Desert Escape\". You find yourself in a mysterious room with only one goal, survive. Choose correctly " +
            "and make it home alive, but one mistake will cost you your life. \nPress <color=#5bc0be>[Enter]</color> to play."),
            //Trap door
            new Page("Trap","With the trap door open a cool breeze blows on you coming from the trap door. Do you [D]ecend the steps of the trap door or [X] to return."),
            //BODY
            new Page("Wake up","You awaken in a sweltering room that smells of dust and dry rot. \nTo your left you see a woven basket, about " +
                    "three feet in front of you you see a deep steel bowl filled with what " +
                    "looks like milk, and 10 feet beyond that is a heavy iron door " +
                    "you assume is locked. You also notice what looks like a hole in the floor " +
                    "with some strange markings around it.\n " +
                    "Will you check the <color=#5bc0be>[W]</color>oven basket, check the <color=#5bc0be>[B]</color>owl, check the door <color=#5bc0be>[D]</color>oor, or check " +
                    "the <color=#5bc0be>[H]</color>ole?"),

            //Secret Room
            new Page("Secret Room","<b><i><color=#5bc0be>Secret Room</color></i></b> \nAs you decend down into the secret room, the trap door slams above you. You turn around and try the trap door but it will not budge." +
            " There is a small window towards the back of the room that is slightly open. You go to inspect the window to find bars are on the outside of the window. As you look around " +
            "you see a crowbar, a ladder and a crate with warning stickers all over it. You decide to <color=#5bc0be>[B]</color>reak open the crate with the crowbar or <color=#5bc0be>[P]</color>ry the bars off the window."),
           
            //Crate
            new Page("Crate","<b><i><color=#5bc0be>At Crate</color></i></b> \nYou break open the crate to find sticks of dynamite, flint and a note that reads \"This is to be used by the breach team during Operation Hidden Valley\"" +
            "Do you use the dynemite on the <color=#5bc0be>[W]</color>indow, use the dynemite on the or use the <color=#5bc0be>[C]</color>rowbar on the window bars?"),
            
            //Hole
            new Page ("Hole","<b><i><color=#5bc0be>At Hole</color></i></b> \nYou decide to go investigate the hole and its surroundings. The hole looks " +
            "keyed with unique markings around the hole. You <color=#5bc0be>[U]</color>se the artifact you found in the hole and a trap door in the floor opens. <color=#5bc0be>[X]</color> to return. "),
            //Basket
            new Page("Basket", "<b><i><color=#5bc0be>At Basket</color></i></b> \nYou walk over to examine the woven basket, which " +
                    "stands almost 3 feet tall. You see that the lid on the bbasket has a " +
                    "handle, but when you try to pull up, it seems to be tied down. " +
                    "You find ties on the four sides of the basekt holding the lid on. " +
                    "You undo the ties and find the basket oddly empty. <color=#5bc0be>[K]</color>ick the basket or press <color=#5bc0be>[X]</color> to return " +
                    "to the previous step."),
            //Kick
            new Page ("Kick", "<b><i><color=#5bc0be>Kicked Basket</color></i></b> \nFrustrated that the basket is empty, and your over all " +
                    "situation. You kick the basket and see a once hiden object slide out of the basket. " +
                    "<color=#5bc0be>[I]</color>nspect object, <color=#5bc0be>[X]</color> to retun. "),
            //Inspect
            new Page ("Inspect","<b><i><color=#5bc0be>Inspect Hole</color></i></b> \nUpon inspection you find strange engravings on the " +
                    "stone disk shaped item. The engravins seem to be foreign to you but " +
                    "you put the item in your pocket in hopes to use it later. With nothing left for " +
                    "you to do here, you go back to the start. <color=#5bc0be>[X]</color> to return."),
            //Door
            new Page("Door", "<b><i><color=#5bc0be>At Door</color></i></b> \nWhile you think it shoul dbe easy enough to waltz through " +
                    "the iron door. When you come up on it, you realize it is much heavier " +
                    "than originally thought. You put all your weight into it " +
                    "to find it only groans and will not budge. \nIt seems you will need " +
                    "a key to unlock the door before it moves anymore. Press <color=#5bc0be>[X]</color> to return " +
                    "to the previous step."),
            //Bowl
            new Page("Bowl","<b><i><color=#5bc0be>At Bowl</color></i></b> \nYou look at the bowl of creamy liquid before you, unsure of its " +
                    "contents. You tap the bowl with your foot and see that the liquid moves with the " +
                    "same viscosity as milk would. You are quit parched, do you <color=#5bc0be>[P]</color>ick up the bowl " +
                    "or press <color=#5bc0be>[X]</color> to return?"),
            //Pick up
            new Page("Pick up", "<b><i><color=#5bc0be>Holding Bowl</color></i></b> \nYou pick up the bowl and bring it closer to sniff the contents. " +
                    "The smell of the liquid is mild, though there is a twinge of something " +
                    "odd to it that you cannot place yoru finger on. You slosh the liquid " +
                    "a bit and notice something shifting at the bottom of the bowl. Do you " +
                    "<color=#5bc0be>[P]</color>our out the contents or <color=#5bc0be>[D]</color>rink the liquid? Press <color=#5bc0be>[X]</color> to return " +
                    "to the previous step."),
            //ENDING

            new Page("Pour","You pour out all the contents onto the dusty floor, " +
                    "including what seems to be some maggots and a wrought iron key. " +
                    "One that looks like it fit in the keyhole of the heavy door. You use " +
                    "the key to unlatch the door and budge it enough to escape. \n<color=#70ae6e>You have won!!!</color>\n<color=#5bc0be>Play Again?</color>"),
             new Page("Window","As you begin to pry the bars off the window, an alarm sounds and a metal plate is activated covering the window. With you oxygen running low and no way out " +
                    "you begin to fade away and eventually die. \n<color=#5bc0be>Play Again?</color>"),
             new Page ("Blow up","You decide to use the dynamte on the window. Placing the sticks between the window bars, you light the sticks and BOOM the dynemite explodes taking out the " +
                    "window, the bars, and a portion of the wall. With freedom in sight you run out of the room not thinking once about looking back. \n<color=#5bc0be>Play Again?</color> "),
            new Page("Drink","You decide your thirst could help to kill two birds " +
                    "with one stone and begin to drink the liquid. The liquid isn't milk " +
                    "at all and has a severe acid taste, you swallow some more anyway, feeling " +
                    "chunks of items floating on your tongue. You spit out the bits and upon " +
                    "further inspection, see they are wriggling. You toss the bowl away from " +
                    "you as you feel the need to wretch. Standing up you see a key landing next to " +
                    "the tossed bowl and as you go to reach for it, you fall forward, mind hazing into " +
                    "unconsiousness. \n <color=#70ae6e>You have died.</color> \n<color=#5bc0be>Play Again?</color>"),
            new Page("No","Thank you for playing!!!")
                  
        };
    }
}
