using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Siin me teeme oma muutujad
    public float bulletSpeed;
    public Rigidbody rigidbodyBullet;

    //Siin me teeme kuuli sündmusteks valmis
    void Start()
    {
        //Paneme kuulile kiiruse
        rigidbodyBullet.linearVelocity += transform.forward * bulletSpeed;

        //Kustutame kuuli pärast 3 sekundit
        Destroy(gameObject, 3);
    }
}
