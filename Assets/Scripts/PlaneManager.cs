using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlaneManager : MonoBehaviour
{
    //See on objekt, millega me valime oma valikut
    public TMP_Dropdown dropdown;

    //See on meie valik
    public string selection;

    void Start()
    {
        //Teeme nii, et see objekt jääb meie mängu, isegi, kui me uue stseeni leiame
        DontDestroyOnLoad(gameObject);

        //Kui me muudame oma valikut, me muudame ka muutujat
        dropdown.onValueChanged.AddListener(ChangeSelection);
    }

    //Muudame muutujat
    private void ChangeSelection(int value)
    {
        selection = dropdown.options[value].text;
    }


}