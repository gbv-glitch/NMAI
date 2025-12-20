using System;
using System.Numerics;
using JetBrains.Annotations;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class PlayerController : MonoBehaviour
{
    //See on selleks, et valida, kuhhu meie vastane ilmub
    public UnityEngine.Vector3 spawnPoint;

    //See on meie mängija
    public GameObject player;

    //See on meie vastane, kes ilmub
    public GameObject enemy;

    //See on mitu vastast me tahame
    public float enemiesLeftToSpawn;

    // See kood jookseb üks kord, kui mäng algab
    void Start()
    {
        //Siin me kontrollime, kas rohkem vastaseid peab ilmuma
        while(enemiesLeftToSpawn > 0)
        {
            //Siin me paneme oma x ja z positiooni millegiks -1000 ja 1000 vahel, y positiooni jätame 0-ks
            spawnPoint = new UnityEngine.Vector3(UnityEngine.Random.Range(-1000, 1001), 0, UnityEngine.Random.Range(-1000, 1001));

            //Siin me pöörame oma vastase mängija poole
            enemy.transform.LookAt(player.transform);

            //Siin meie vastane ilmub
            Instantiate(enemy, spawnPoint, gameObject.transform.rotation);

            //Siin me vähendame vastaste veel ilmumise arvu ühe võrra
            enemiesLeftToSpawn -= 1;
        }
    }
}