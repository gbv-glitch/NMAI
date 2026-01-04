using System.IO;
using UnityEngine;

public class Missile : MonoBehaviour
{
    //See on meie peamine kaamera
    public Camera mainCamera;

    //See on objekt, mida meie rakett otsib
    public GameObject target;

    //See näitab, kui kaugel meie rakett peab olema ühest spetsiifilisest objektist, et plahvatada
    public float proximityFuze;

    //See näitab, kui palju meie rakett oskab pöörata
    public float maxTurn;

    //See on meie otsitava objekti eelmise kaadri positioon
    public Vector3 targetLastFramePos = new Vector3(0, 0, 0);

    //See on kui kiiresti meie rakett lendab
    public float missileSpeed;

    //See on, kui palju otsitava objekti süsteemid raketti segavad
    public float targetJamming;

    //See kood jookseb ühe korra
    void Start()
    {
        Destroy(gameObject, 10);
    }
    //See kood jookseb iga kaader
    void Update()
    {        
        if(target != null)
        {
            Vector3 toTarget = target.transform.position - transform.position;
            float angle = Vector3.Angle(transform.forward, toTarget);
            
            bool hasLock = angle < 180 * 0.5f;
            if (hasLock)
            {
                //See on meie otsitava objekti kiirus
                UnityEngine.Vector3 targetSpeed = (target.transform.position - targetLastFramePos) * Time.deltaTime;
                
                //See on aeg kuni me otsitava objektiga kokku põrkame
                float timeToHit = UnityEngine.Vector3.Distance(transform.position, targetLastFramePos) / (missileSpeed * Time.deltaTime);
                
                //See on meie otsitava objekti positioon siis, kui me sellega kokku põrkame, ja see ei muuda kiirust ega suunda
                UnityEngine.Vector3 targetFuturePos = target.transform.position + (targetSpeed * timeToHit);
                
                //Siin me arvutame, kuhu me peame pöörama
                Quaternion targetRotation = Quaternion.LookRotation(targetFuturePos - transform.position - (new Vector3(1, 1, 1) * targetJamming));

                //Siin meie rakett pööratakse ja liigutatakse edasi
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, maxTurn * Time.deltaTime);

                //Alles lõpus me muudame targetLastFramePos, sest me kasutame seda jälle uues kaadris
                targetLastFramePos = target.transform.position;
            }

            //Muidu me plahvatame
            //else
            {
                //Explode(false);
            }

            //Liigutame raketi edasi
            transform.position += missileSpeed * transform.forward * Time.deltaTime;

            //Siin me kontrollime, kas rakett on otsitava objekti läheduses, ja kui on, siis see plahvatab
            if(Vector3.Distance(transform.position, target.transform.position) <= proximityFuze)
            {
                Explode(true);
            }
        }
    }

    //See on meie plahvatamismeeteod
    void Explode(bool reachedTarget)
    {
        if(reachedTarget)
        {
            target.GetComponent<Enemy>().SelfDestroy();
        }
        Destroy(gameObject);
    }
}