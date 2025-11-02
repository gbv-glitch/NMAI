using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Siin me teeme oma muutujad
    public float bulletSpeed;
    public Rigidbody rigidbodyBullet;
    public string hostTag;

    //Selle koodi me jookseme ühe korra siis, kui objekt tehakse
    void Start()
    {
        //Me ei taha selles mängus, et kuulid kukuksid
        rigidbodyBullet.useGravity = false;

        //See on spetsiifiliselt kiirete objektide kokkupõrke tuvastamine
        rigidbodyBullet.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

        //Liigutab kuuli palju parmeini
        rigidbodyBullet.interpolation = RigidbodyInterpolation.Interpolate;

        //Paneme kuulile kiiruse
        rigidbodyBullet.linearVelocity += transform.forward * bulletSpeed;
        
        //Kustutame kuuli pärast 3 sekundit
        Destroy(gameObject, 3);
    }

    //See kood jookseb siis, kui me millegagi kokku põrkame
    void OnCollisionEnter(Collision collision)
    {        
        //Vaatame, kas objekt on objekt, mida saab ära purustada
        if (collision.gameObject.tag == "Target" || collision.gameObject.tag == "Player")
        {            
            if (collision.gameObject.tag == "Target" & collision.gameObject.tag != hostTag)
            {
                //Kustutame objekti millega kokku põrkasime
                Destroy(collision.gameObject);
            }

            if (collision.gameObject.tag != hostTag)
            {
                //Kustutame kuuli ära
                Destroy(gameObject);
            }

            if (collision.gameObject.tag == "Player" & hostTag != "Player")
            {
                print("You got a hole in your left wing!");
            }
        }        
    }

}