using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Siin me teeme oma muutujad
    public float bulletSpeed;
    public Rigidbody rigidbodyBullet;

    public GameObject gun;

    //Selle koodi me jookseme ühe korra siis, kui objekt tehakse
    void Start()
    {
        //Paneme kuulile kiiruse
        rigidbodyBullet.linearVelocity += transform.forward * bulletSpeed;

        //Kustutame kuuli pärast 3 sekundit
        Destroy(gameObject, 3);
    }

    //See kood jookseb siis, kui me millegagi kokku põrkame
    void OnCollisionEnter(Collision collision)
    {
        //Kustutame objekti millega kokku põrkasime
        Destroy(collision.gameObject);
    }

}