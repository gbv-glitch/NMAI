using System;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    //See on meie mängija
    public GameObject target;

    //See on meie kuul
    public GameObject bulletPrefab;

    //See näitab, kas me oleme valmis tulistama
    public bool readyToShoot = true;

    //See on meie mängija viimase kaadri positioon
    public Vector3 targetLastFramePosition;

    //See kood jookseb ühe korra alguses
    void Start()
    {
        //Anname kõikidele oma nn lastele õige tag-i
        GiveAllChildrenTag(gameObject.tag);
    }

    // Seda koodi me jookseme alati
    void Update()
    {
        //Kontrollime, kas mängija on meil ikka olemas ja meie vastane näeb teda
        if (target != null)
        {
            //Kontrollime, kas mäng on pausile pandud
            if (target.GetComponent<PlaneControls>().pause != true)
            {
                //Leiame kui kiiresti mängija liigub
                Vector3 targetSpeed = (target.transform.position - targetLastFramePosition) / Time.deltaTime;

                //Leiame aja, mis on meie kuulil vaja, et mängijale pihta saada
                float timeToHit = Vector3.Distance(transform.position, targetLastFramePosition) / 300f;

                //Leiame, kus mängija on timeToHit skundi pärast
                Vector3 targetFuturePos = target.transform.position + (targetSpeed * timeToHit);

                // Liigutame vastase edasi
                transform.position += transform.forward * Time.deltaTime * 15;

                //Siin me arvutame, kuhu me peame pöörama
                Quaternion targetRotation = Quaternion.LookRotation(targetFuturePos - transform.position - new Vector3(UnityEngine.Random.Range(-20f, 20f), UnityEngine.Random.Range(-20f, 20f), UnityEngine.Random.Range(-20f, 20f)));

                //Siin me pöörame vastast
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 20 * Time.deltaTime);

                //Siin meie vastane tulistab
                if (readyToShoot)
                {
                    //Kuul ilmub
                    GameObject enemyBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

                    //Me anname kuulile info, mida sellel on vaja
                    enemyBullet.GetComponent<Bullet>().hostTag = gameObject.tag;
                    enemyBullet.GetComponent<Bullet>().player = target;

                    //Vastane saab alles tulistada 1 sekund hiljem
                    readyToShoot = false;
                    Invoke("ReadyToShoot", 1f);
                }

                //Alles lõpus me muudame mängija positiooni, sest kui me seda jälle kasutame, on juba järgmine kaader
                targetLastFramePosition = target.transform.position;}
            }
        }

    //Siin me teeme ennast valmis tulistama
    void ReadyToShoot()
    {
        readyToShoot = true;
    }

    //Siin me anname kõikidele nn lastale õige tag-i
    void GiveAllChildrenTag(string tag)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).tag = tag;
        }
    }
}