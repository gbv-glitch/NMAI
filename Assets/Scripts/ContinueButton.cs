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

class ContinueButton : MonoBehaviour
{
    //See on meie nupp, mida me vajutame, et alustada mängu
    public UnityEngine.UI.Button button;

    //See on hääl, mis mängib kui me selle ekraani laadime
    public AudioSource Sfx;

    // See kood ühe korra
    void Start()
    {
        //Mängime oma hääleeffekti
        Sfx.Play();
        
        //Teeme nii, et hiirekursor on nähtav ja kasutav
        UnityEngine.Cursor.lockState = CursorLockMode.None;

        //Kui nuppu vajutatakse, siis kutsume StartGame funktsiooni
        button.onClick.AddListener(MainMenu);
    }

    // See funktsioon muudab stseeni
    private void MainMenu()
    {
        //Vahetame stseeni
        SceneManager.LoadScene("Starting menu");
    }
}
