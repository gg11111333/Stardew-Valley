using UnityEngine;
using UnityEngine.UIElements;

public class InventoryController : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject statusPanel;
    [SerializeField] GameObject toolbarPanel;
    [SerializeField] GameObject additionalPanel;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if(panel.activeInHierarchy == false)
            {
                Open();
            }
            else
            {
                Close();
            }
        }   
    }

    public void Open()
    {
        panel.SetActive(true);
        statusPanel.SetActive(true);
        toolbarPanel.SetActive(true);
    }

    public void Close()
    {
        panel.SetActive(false);
        statusPanel.SetActive(false);
        toolbarPanel.SetActive(false);
        additionalPanel.SetActive(false);
    }
}
