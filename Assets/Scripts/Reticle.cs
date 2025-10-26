using UnityEngine;

public class Reticle : MonoBehaviour
{
    //See kood joostakse iga kaader
    void Update()
    {
        //Me peame jätma selle z pööramisväärtuse 0, sest muidu see tiirleb koos lennukiga, mida me ei taha
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
    }
}
