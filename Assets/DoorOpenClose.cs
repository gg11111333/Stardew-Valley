using System;
using UnityEngine;

public class DoorOpenClose : MonoBehaviour
{
   [SerializeField] GameObject openDoor;
   [SerializeField] GameObject closeDoor;

   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.GetComponent<Character>() != null)
      {
        OpenDoor();
         
      }
   }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Character>() != null)
        {
            CloseDoor();
        }
    }

    private void CloseDoor()
    {
        closeDoor.SetActive(true);
        openDoor.SetActive(false);
    }

    private void OpenDoor()
    {
        closeDoor.SetActive(false);
        openDoor.SetActive(true);
    }
}
