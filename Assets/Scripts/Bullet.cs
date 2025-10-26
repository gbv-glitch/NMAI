using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Siin me teeme oma muutujad
    public float bulletSpeed;
    public Rigidbody rigidbodyBullet;

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
        //Vaatame, kas objekt on objekt, mida saab ära purustada
        if (collision.gameObject.tag == "Target")
        {
            //Kustutame objekti millega kokku põrkasime
            Destroy(collision.gameObject);

            //Kustutame kuuli ära
            Destroy(gameObject);
        }
        
    }

}