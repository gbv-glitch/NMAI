using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Siin me teeme oma muutujad
    public float bulletSpeed;
    public Rigidbody rigidbodyBullet;
    public string hostTag;

    //See on meie mängija
    public GameObject player;

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
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Enviroment" && collision.gameObject.tag != hostTag)
        {
            collision.gameObject.GetComponentInParent<Enemy>().hp -= 1;
        }

        //Siin me kontrollime kas kuul on vastase oma ja kas see on mängijale pihta saanud
        if (collision.gameObject.tag == "Player" && hostTag != "Player")
        {
            //Võtame mängijalt elu ära
            player.GetComponent<PlaneControls>().hp -= 1f;
        }    
    }

}