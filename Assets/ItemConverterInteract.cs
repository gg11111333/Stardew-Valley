using System.Collections;
using System.Collections.Generic;
using System;
using Microsoft.VisualBasic;
using UnityEngine;

public class ItemConverterInteract : Interactable
{
    [SerializeField] Item convertableItem;
    [SerializeField] Item productedItem;
    [SerializeField] int productedItemCount = 1;


    ItemSlot itemSlot;

    [SerializeField] float timeToProcess = 5f;
    float timer;

    private void Start()
    {
        itemSlot = new ItemSlot();
    }

    public override void Interact(Character character)
    {
        
        if(itemSlot.item == null)
        {
            if (GameManager.instance.dragAndDropController.Check(convertableItem))
            {
                
                StarItemProcessing();
            }
        }
        if(itemSlot.item != null && timer <= 0f)
        {
            GameManager.instance.inventoryContainer.Add(itemSlot.item, itemSlot.count);
            itemSlot.Clear();
        }

        

    }

    private void StarItemProcessing()
    {
        itemSlot.Copy(GameManager.instance.dragAndDropController.itemSlot);
        GameManager.instance.dragAndDropController.RemoveItem();    

        timer = timeToProcess;
    }

    private void Update()
    {
        if(itemSlot == null){return;}
        if(timer > 0f)
        {
            timer -= Time.deltaTime;
            if(timer <= 0f)
            {
                CompleteItemConversion();
                
            }
        }
    }

     private void CompleteItemConversion()
    {
        itemSlot.Clear();  
        itemSlot.Set(productedItem, productedItemCount);
    } 

  
}
