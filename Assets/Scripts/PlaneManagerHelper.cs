using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class PlaneManagerHelper : MonoBehaviour
{
    //See on objekt, mis ütleb meile, mis lennuki mängija valis
    public GameObject planeManager;

    //Need on meie lennukite valikud
    public List<GameObject> aircraft;

    void Start()
    {
        ActivateAllAircraft(aircraft.Count, aircraft);
        
        planeManager = GameObject.FindGameObjectWithTag("PlaneManager");

        PlaneManager managerComponent =  planeManager.GetComponent<PlaneManager>();

        if(managerComponent.selection == "JAS 39E")
        {
            DeactivateAllAircraftExcept(aircraft.Count, aircraft, 0);
        }

        else if(managerComponent.selection == "F 35A")
        {
            DeactivateAllAircraftExcept(aircraft.Count, aircraft, 1);
        }
    }

    void DeactivateAllAircraftExcept(int amountOfObjectsInList, List<GameObject> list, int index)
    {
        for(int i = 0; i < amountOfObjectsInList; i ++)
        {
            if(i != index)
            {
                list[i].SetActive(false);
            }
        }
    }

    void ActivateAllAircraft(int amountOfObjectsInList, List<GameObject> list)
    {
        for(int i = 0; i < amountOfObjectsInList; i++)
        {
            list[i].SetActive(true);
        }
    }

    void Update()
    {
        Debug.Log(ActivePlayerFinder.FindActiveAircraft(planeManager, gameObject));
    }
}