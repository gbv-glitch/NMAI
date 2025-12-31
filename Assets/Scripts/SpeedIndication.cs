using UnityEngine;
using UnityEngine.UI;

public class SpeedIndication : MonoBehaviour
{
    public GameObject Player;

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
        if (Player.GetComponent<PlaneControls>().planeSpeedPercent == 10)
        {
            objectImage.sprite = tenPercent;
        }
        else if (Player.GetComponent<PlaneControls>().planeSpeedPercent == 20)
        {
            objectImage.sprite = twentyPercent;
        }
        else if (Player.GetComponent<PlaneControls>().planeSpeedPercent == 30)
        {
            objectImage.sprite = thirtyPercent;
        }
        else if (Player.GetComponent<PlaneControls>().planeSpeedPercent == 40)
        {
            objectImage.sprite = fourtyPercent;
        }
        else if (Player.GetComponent<PlaneControls>().planeSpeedPercent == 50)
        {
            objectImage.sprite = fiftyPercent;
        }
        else if(Player.GetComponent<PlaneControls>().planeSpeedPercent == 60)
        {
            objectImage.sprite = sixtyPercent;
        }
        else if(Player.GetComponent<PlaneControls>().planeSpeedPercent == 70)
        {
            objectImage.sprite = seventyPercent;
        }
        else if(Player.GetComponent<PlaneControls>().planeSpeedPercent == 80)
        {
            objectImage.sprite = eightyPercent;
        }
        else if(Player.GetComponent<PlaneControls>().planeSpeedPercent == 90)
        {
            objectImage.sprite = ninetyPercent;
        }
        else if(Player.GetComponent<PlaneControls>().planeSpeedPercent == 100)
        {
            objectImage.sprite = hundredPercent;
        }
        
    }
}
