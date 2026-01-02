using UnityEngine;

public class Missile : MonoBehaviour
{
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

    void Update()
    {
        //See on meie otsitava objekti kiirus
        UnityEngine.Vector3 targetSpeed = target.transform.position - targetLastFramePos / Time.deltaTime;
        
        //See on aeg kuni me otsitava objektiga kokku põrkame
        float timeToHit = UnityEngine.Vector3.Distance(transform.position, targetLastFramePos) / missileSpeed;
        
        //See on meie otsitava objekti positioon siis, kui me sellega kokku põrkame, ja see ei muuda kiirust ega suunda
        UnityEngine.Vector3 targetFuturePos = target.transform.position + (targetSpeed * timeToHit);
        
        //Siin me arvutame, kuhu me peame pöörama
        Quaternion targetRotation = Quaternion.LookRotation(transform.position - targetFuturePos * targetJamming);

        //Siin meie rakett pööratakse ja liigutatakse edasi
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, maxTurn);
    }
}