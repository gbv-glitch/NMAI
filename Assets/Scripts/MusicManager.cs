using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    //See on meie muusika
    public AudioSource music;

    //See kood jookseb ühe korra
    void Start()
    {
        //See teeb nii, et meie muusika ei kaoks ära mängu ajal
        DontDestroyOnLoad(gameObject);

        //Teeme nii, et muusika jälle mängiks, kui ta lõppeb ja paneme selle mängima
        music.loop = true;
        music.Play();
    }

    //See kood jookseb iga kaader
    void Update()
    {
        //Kui me oleme võidu- või kaotusesekraanil muusika ei mängi
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Victory screen") && music.isPlaying == true || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Death screen") && music.isPlaying == true)
        {
            music.Stop();
        }

        //Muidu see mängib
        else if(music.isPlaying == false)
        {
            music.Play();
        }
    }
}