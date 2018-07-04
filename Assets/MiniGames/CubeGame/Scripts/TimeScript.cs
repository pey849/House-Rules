 using UnityEngine;
 using System.Collections;
 using UnityEngine.UI;
 
 public class TimeScript : MonoBehaviour
{
    //The UI element that will display the time
    public Text timerLabel;
    //Time left in the game
    public float time;
    //end of game
    private bool end = false;
    

    void Update()
    {
        //decrements time based on time in the game
        time -= Time.deltaTime;

        //dividing time by 60 to get minutes, we subtract -5 for rounding error
        float minutes = (time / 60) - 0.5f; 
        //modulus division to get seconds remaining
        float seconds = time % 60;


        
        //if time is still a positive number
        if (time > 0)
        {
            //update timer lable to current time
            timerLabel.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        }        
        else
        {
            //end cube game
            End("Cubes");            
        }
        //wait to let results be scored
        //then find winner and load overworld
        if (time < -2)
        {
            gameObject.GetComponent<GetResults>().findWinner();
        }
    }

    // end takes in name of a game and then will handle the winning 
    //condition appropriatly
    void End(string gameName)
    {
        if(gameName == "Cubes")
        {
            gameObject.GetComponent<EndCubeGame>().End();
        }
    }   
}

