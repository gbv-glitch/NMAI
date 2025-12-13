using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

class StartButton : MonoBehaviour
{
    //See on meie nupp, mida me vajutame, et alustada mängu
    public UnityEngine.UI.Button startButton;

    // See kood jookseb iga kaader
    void Start()
    {
        //Kui nuppu vajutatakse, siis kutsume StartGame funktsiooni
        startButton.onClick.AddListener(StartGame);
    }

    // See funktsioon muudab stseeni
    private void StartGame()
    {
        Debug.Log("Start Game");

        //Vahetame stseeni
        SceneManager.LoadScene("Plane");
    }
}
