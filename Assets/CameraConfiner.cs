using Unity.Cinemachine;
using UnityEngine;

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
}
