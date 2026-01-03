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

    //See on raketi kaamera, mis vaatab, kas otsitav objekt on nähtav
    public Camera cam;

    void Update()
    {
        //Oleme kindlad, et meie peamine kaamera on see, mis õigeid asju näitab
        mainCamera.enabled = true;
        cam.enabled = false;
        
        //Siin me võtame oma target objekti positiooni ja leiame selle positiooni ekraanil (canvase peal)
        UnityEngine.Vector3 screenPosOfTarget = cam.WorldToScreenPoint(target.transform.position);

        //Siin me kontrollime kas vastane on nähtav
        if (screenPosOfTarget.z > 0)
        {
            //See on meie otsitava objekti kiirus
            UnityEngine.Vector3 targetSpeed = target.transform.position - targetLastFramePos / Time.deltaTime;
            
            //See on aeg kuni me otsitava objektiga kokku põrkame
            float timeToHit = UnityEngine.Vector3.Distance(transform.position, targetLastFramePos) / missileSpeed;
            
            //See on meie otsitava objekti positioon siis, kui me sellega kokku põrkame, ja see ei muuda kiirust ega suunda
            UnityEngine.Vector3 targetFuturePos = target.transform.position + (targetSpeed * timeToHit);
            
            //Siin me arvutame, kuhu me peame pöörama
            Quaternion targetRotation = Quaternion.LookRotation(transform.position - targetFuturePos - (new Vector3(1, 1, 1) * targetJamming));

            //Siin meie rakett pööratakse ja liigutatakse edasi
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, maxTurn);
        }

        //Liigutame raketi edasi
        transform.position += missileSpeed * transform.position;

        //Siin me kontrollime, kas rakett on otsitava objekti läheduses, ja kui on, siis see plahvatab
        if(Vector3.Distance(transform.position, target.transform.position) <= proximityFuze)
        {
            Explode();
        }
    }

    //See on meie plahvatamismeeteod
    void Explode()
    {
        Destroy(target);
        Destroy(gameObject);
    }
}