using UnityEngine;

public class PlaceableObjectsReferenceManager : MonoBehaviour
{
    public PlaceableObjectsManager placeableObjectsManager;

    public void Place(Item item, Vector3Int pos)
    {
        if(placeableObjectsManager == null)
        {
            Debug.LogWarning("NO placeableObjectManager reference detected");
            return;
        }

        placeableObjectsManager.Place(item, pos);
    }
}
