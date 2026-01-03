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

class QuitButton : MonoBehaviour
{
    //See on meie nupp, mida me vajutame, et alustada mängu
    public UnityEngine.UI.Button button;

    // See kood ühe korra
    void Start()
    {        
        //Teeme nii, et hiirekursor on nähtav ja kasutav
        UnityEngine.Cursor.lockState = CursorLockMode.None;

        //Kui nuppu vajutatakse, siis kutsume StartGame funktsiooni
        button.onClick.AddListener(Quit);
    }

    // See funktsioon muudab stseeni
    private void Quit()
    {
        //Paneme mängu kinni
        Application.Quit();
    }
}
