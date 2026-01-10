using UnityEngine;
using UnityEngine.UI;

public class HealthCounter : MonoBehaviour
{
    public GameObject player = ActivePlayerFinder.FindActiveAircraft(GameObject.FindGameObjectWithTag("PlaneManager"), GameObject.FindGameObjectWithTag("PlaneManagerHelper"));

    //Pildid, mis näitavad, kui kiiresti me sõidame
    public Sprite tenPercent;
    public Sprite twentyPercent;
    public Sprite thirtyPercent;
    public Sprite fourtyPercent;
    public Sprite fiftyPercent;
    public Sprite sixtyPercent;
    public Sprite seventyPercent;
    public Sprite eightyPercent;
    public Sprite ninetyPercent;
    public Sprite hundredPercent;

    //Meie pilt
    public Image objectImage;

    //See kood jookseb iga kaader
    void Update()
    {
        //Kontrollime, mitu protsenti maksimumist kiirusest mängija lendab ja vahetame pildi selle järgi
        if (player.GetComponent<PlaneControls>().hp == 1)
        {
            objectImage.sprite = tenPercent;
        }
        else if (player.GetComponent<PlaneControls>().hp == 2)
        {
            objectImage.sprite = twentyPercent;
        }
        else if (player.GetComponent<PlaneControls>().hp == 3)
        {
            objectImage.sprite = thirtyPercent;
        }
        else if (player.GetComponent<PlaneControls>().hp == 4)
        {
            objectImage.sprite = fourtyPercent;
        }
        else if (player.GetComponent<PlaneControls>().hp == 5)
        {
            objectImage.sprite = fiftyPercent;
        }
        else if(player.GetComponent<PlaneControls>().hp == 6)
        {
            objectImage.sprite = sixtyPercent;
        }
        else if(player.GetComponent<PlaneControls>().hp == 7)
        {
            objectImage.sprite = seventyPercent;
        }
        else if(player.GetComponent<PlaneControls>().hp == 8)
        {
            objectImage.sprite = eightyPercent;
        }
        else if(player.GetComponent<PlaneControls>().hp == 9)
        {
            objectImage.sprite = ninetyPercent;
        }
        else if(player.GetComponent<PlaneControls>().hp == 10)
        {
            objectImage.sprite = hundredPercent;
        }
        else
        {
            return;
        }
        
    }
}
