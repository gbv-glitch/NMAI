using System;
using JetBrains.Annotations;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.UnityConsent;

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
        //Vahetame stseeni
        SceneManager.LoadScene("Plane");
    }
}
