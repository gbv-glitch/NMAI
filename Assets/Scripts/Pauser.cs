using UnityEngine;

public class Pauser : MonoBehaviour
{
    //See näitab, kas mäng on pausile pandud
    private bool isPaused;

    //See kood jookseb iga kaader
    void Update()
    {
        //See paneb mängu jooksmiskiiruse nulli e pausile, kui p on vajutatud ja ei ole pausile pandud jne
        if(Input.GetKeyDown(KeyCode.P))
        {
            if (!isPaused)
            {
                Time.timeScale = 0f;//Mängu jooksmiskiirus
                isPaused = true;

                //Paneme kõik hääled pausile
                AudioListener.pause = true;
            }

            else
            {
                Time.timeScale = 1f;
                isPaused = false;

                //Paneme kõik hääled jälle käima
                AudioListener.pause = false;
            }
        }
    }
}
