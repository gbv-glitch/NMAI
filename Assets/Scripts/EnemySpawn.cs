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


public class EnemySpawn : MonoBehaviour
{
    //See on selleks, et valida, kuhhu meie vastane ilmub
    public UnityEngine.Vector3 spawnPoint;

    //See on meie mängija
    public GameObject player;

    //See on meie vastane, kes ilmub
    public GameObject enemyPrefab;

    //See on mitu vastast me tahame
    public float enemiesLeftToSpawn;

    public UnityEngine.Quaternion rotationOfEnemy;

    // See kood jookseb üks kord, kui mäng algab
    void Start()
    {
        //Siin me valime, mitu vastast peab ilmuma
        enemiesLeftToSpawn = UnityEngine.Random.Range(5, 15);

        //Me teatame mängijale mitu vastast on alguses
        player.GetComponent<PlaneControls>().enemiesLeft = enemiesLeftToSpawn;

        Debug.Log(enemiesLeftToSpawn);
        //Siin me kontrollime, kas rohkem vastaseid peab ilmuma
        for (int i = 0; i <enemiesLeftToSpawn; i++)
        {
            //Siin me paneme oma x ja z positiooni millegiks -1000 ja 1000 vahel, y positiooni jätame 0-ks
            spawnPoint = new UnityEngine.Vector3(UnityEngine.Random.Range(-1000, 1000), 0, UnityEngine.Random.Range(-1000, 1000));
            gameObject.transform.position = spawnPoint;

            //Siin me pöörame oma vastase mängija poole
            rotationOfEnemy = UnityEngine.Quaternion.LookRotation(player.transform.position - spawnPoint);

            //Siin meie vastane ilmub ja me anname sellele kõige vajaliku info mis tal on vaja
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint, rotationOfEnemy);
            enemy.tag = "Enemy" + i;
            enemy.GetComponent<Enemy>().target = player;

            //Lõpus me muudame selle nime, et järgmine vastane samuti saaks seda infot
            enemy.name = "Mig31_" + i;
        }
    }
}