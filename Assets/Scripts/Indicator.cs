using UnityEngine;
using System;
using System.Numerics;
using System.Data.Common;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{
    //See on see objekt, mida meie objekt selle koodiga näitab
    public GameObject target;

    //See on tühi pilt, mida me kasutame, kui asi, mida me peame selle näitajaga näitama ei ole ekraanil nähtav
    public Sprite blank;

    //See on meie normaalne pilt
    public Sprite normal;

    //See on meie kaamera
    public Camera cam;

    //See on see asi, kuhupeale kõik meie UI läheb
    public Canvas canvas;

    //See on see pilt, mis seda koodi kasutab
    public RectTransform indicatorUI;

    //See kood jookseb iga kaader
    void Update()
    {
        //Kui veel sellist objekti pole, siis me proovime uuesti järgmine kaader
        if (target == null)
        {
            return;
        }

        //Siin me võtame oma target objekti positiooni ja näitame selle positiooni ekraanil (canvase peal)
        UnityEngine.Vector3 screenPosOfTarget = cam.WorldToScreenPoint(target.transform.position);

        //Siin me kontrollime kas vastane on nähtav
        if (screenPosOfTarget.z > 0)
        {
            //Me paneme selle näitaja pildiks normaalse pildi
            indicatorUI.GetComponent<Image>().sprite = normal;

            //Siin me teeme oma positiooni canvas positiooniks
            UnityEngine.Vector2 canvasPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, screenPosOfTarget, canvas.worldCamera, out canvasPos);

            //Siin me muudame oma pildi positiooni
            indicatorUI.anchoredPosition = canvasPos;
        }

        //Kui vastane ei ole ekraanil, me paneme näitaja pildiks tühja pildi
        else
        {
            indicatorUI.GetComponent<Image>().sprite = blank;
        }
        
    }
}