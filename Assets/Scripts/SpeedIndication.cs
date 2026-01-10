using UnityEngine;
using UnityEngine.UI;

public class SpeedIndication : MonoBehaviour
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
        if (player.GetComponent<PlaneControls>().planeSpeedPercent == 10)
        {
            objectImage.sprite = tenPercent;
        }
        else if (player.GetComponent<PlaneControls>().planeSpeedPercent == 20)
        {
            objectImage.sprite = twentyPercent;
        }
        else if (player.GetComponent<PlaneControls>().planeSpeedPercent == 30)
        {
            objectImage.sprite = thirtyPercent;
        }
        else if (player.GetComponent<PlaneControls>().planeSpeedPercent == 40)
        {
            objectImage.sprite = fourtyPercent;
        }
        else if (player.GetComponent<PlaneControls>().planeSpeedPercent == 50)
        {
            objectImage.sprite = fiftyPercent;
        }
        else if(player.GetComponent<PlaneControls>().planeSpeedPercent == 60)
        {
            objectImage.sprite = sixtyPercent;
        }
        else if(player.GetComponent<PlaneControls>().planeSpeedPercent == 70)
        {
            objectImage.sprite = seventyPercent;
        }
        else if(player.GetComponent<PlaneControls>().planeSpeedPercent == 80)
        {
            objectImage.sprite = eightyPercent;
        }
        else if(player.GetComponent<PlaneControls>().planeSpeedPercent == 90)
        {
            objectImage.sprite = ninetyPercent;
        }
        else if(player.GetComponent<PlaneControls>().planeSpeedPercent == 100)
        {
            objectImage.sprite = hundredPercent;
        }
        
    }
}
