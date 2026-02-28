using UnityEngine;
using System.Collections;
using UnityEngine.UI;

class ReticleLeadShower : MonoBehaviour
{
    //See on meie mängija
    public GameObject player;

    //See on meie mängija poolt välja valitud vastatne
    public GameObject target;
    
    //Selles positioonis meie valitud vastane oli eelmises kaadris
    public Vector3 targetLastFramePosition;

    //See on meie kaamera
    public Camera mainCam;
    
    //See on see pilt, mis seda koodi kasutab
    public RectTransform reticleLeadShower;

    //See on meie canvas
    public Canvas canvas;

    //See on pilt, mida me näitame, kui me ei peaks veel tulistama
    public Sprite dontShoot;

    //See on pilt, mida me näitame, kui me peaks tulistama
    public Sprite shoot;

    //See näitab, kus me tulistame
    public RectTransform reticle;

    //See on tühi pilt
    public Sprite blank;

    //Paneme oma mängija paika
    
    void Start()
    {
        StartCoroutine(Wait1Frame());
    }

    //See kood jookseb iga kaader
    void Update()
    {
        //Anname mängija välja valitud vastase selle objektile teada
        target = player.GetComponent<PlaneControls>().lockedTarget;

        if (target != null)
        {
            reticleLeadShower.GetComponent<Image>().sprite = dontShoot;
            //Leiame kui kiiresti valitud vastane liigub
            Vector3 targetSpeed = (target.transform.position - targetLastFramePosition) / Time.deltaTime;

            //Leiame aja, mis on meie kuulil vaja, et valitud vastasele pihta saada
            float timeToHit = Vector3.Distance(player.transform.position, targetLastFramePosition) / 300f;//Kuuli kiirus

            //Leiame, kus valitud vastane on timeToHit sekundi pärast
            Vector3 targetFuturePos = target.transform.position + (targetSpeed * timeToHit);

            //Leiame valitud vastase tuleviku positiooni ekraanil
            Vector3 posOnScreen = mainCam.WorldToScreenPoint(targetFuturePos);

            //Teeme oma positiooni canvase positiooniks
            Vector2 canvasPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, posOnScreen, null, out canvasPos);
            //Liigutame oma pilti ekraanil
            reticleLeadShower.anchoredPosition = canvasPos;

            //Teeme selle valmis järgmiseks kaadriks
            targetLastFramePosition = target.transform.position;
        }

        else
        {
            reticleLeadShower.GetComponent<Image>().sprite = blank;
        }   
    }

    IEnumerator Wait1Frame()
    {
        yield return null;
        player = ActivePlayerFinder.FindActiveAircraft(GameObject.FindGameObjectWithTag("PlaneManager"), GameObject.FindGameObjectWithTag("PlaneManagerHelper"));
    } 
}