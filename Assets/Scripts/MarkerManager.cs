using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MarkerManager : MonoBehaviour
{
    [SerializeField] Tilemap targetTiemap;
    [SerializeField] TileBase tile;
    public Vector3Int markedCellPosition;
    Vector3Int oldCellPosition;
    bool show;

    private void Update()
    {
        if(show == false){ return; }
        targetTiemap.SetTile(oldCellPosition ,null);
        targetTiemap.SetTile(markedCellPosition, tile);
        oldCellPosition = markedCellPosition;

    }

    internal void Show(bool selectable)
    {
        show = selectable;
        targetTiemap.gameObject.SetActive(show);
    }
}
