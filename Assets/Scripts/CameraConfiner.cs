using System;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class CameraConfiner : MonoBehaviour
{
    [SerializeField] CinemachineConfiner2D confiner;

    void Start()
    {
        UpdateBounds();
    }

    public void UpdateBounds()
    {
        GameObject go = GameObject.Find("CameraConfiner");
        if(go == null)
        {
            confiner.BoundingShape2D = null;
            return;
        }
        Collider2D bounds = go.GetComponent<Collider2D>();
        confiner.BoundingShape2D = bounds;
    }

    internal void UpdateBounds(Collider2D confiner)
    {
        this.confiner.BoundingShape2D = confiner;
    }
}
