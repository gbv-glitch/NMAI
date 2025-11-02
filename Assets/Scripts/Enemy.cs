using System;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    //See on meie mängija
    public GameObject target;

    public GameObject bulletPrefab;
    public bool readyToShoot = true;
    public Vector3 targetLastFramePosition;

    // Seda koodi me jookseme alati
    void Update()
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
        Quaternion targetRotation = Quaternion.LookRotation(targetFuturePos - transform.position);

        //Siin me pöörame vastast
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 60 * Time.deltaTime);

        if (readyToShoot)
        {
            GameObject enemyBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            enemyBullet.GetComponent<Bullet>().hostTag = "Target";

            readyToShoot = false;

            Invoke("ReadyToShoot", 1f);
        }

        //Alles lõpus me muudame mängija positiooni, sest kui me seda jälle kasutame, on juba järgmine kaader
        targetLastFramePosition = target.transform.position;
    }

    void ReadyToShoot()
    {
        readyToShoot = true;
    }
}
