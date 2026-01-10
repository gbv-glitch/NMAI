using System.Collections.Generic;
using UnityEngine;

public class ActivePlayerFinder : MonoBehaviour
{
    //See kood aitab meil leida, mis lennuk on aktiivne
    public static GameObject FindActiveAircraft(GameObject planeManager, GameObject planeManagerHelper)
    {
        PlaneManager planeManagerComponent = planeManager.GetComponent<PlaneManager>();

        PlaneManagerHelper planeManagerHelperComponent = planeManagerHelper.GetComponent<PlaneManagerHelper>();

        if(planeManagerComponent.selection != "Choose Your Aircraft")
        {
            return IsActiveAircraft(planeManagerHelperComponent.aircraft);
        }

        else
        {
            return null;
        }
    }

    private static GameObject IsActiveAircraft(List<GameObject> list)
    {
        GameObject activeAircraft = null;

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].activeInHierarchy)
            {
                activeAircraft = list[i];
            }
        }

        return activeAircraft;
    }
    
}