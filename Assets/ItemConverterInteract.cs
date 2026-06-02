using System.Collections;
using System.Collections.Generic;
using System;
using Microsoft.VisualBasic;
using UnityEngine;
using UnityEditor.UIElements;



public class ItemConvertorData
{
    public ItemSlot itemSlot;
    public int timer;

    public ItemConvertorData()
    {
        itemSlot = new ItemSlot();
    }
}

[RequireComponent(typeof(TimeAgent))]
public class ItemConverterInteract : Interactable, IPersistant
{
    [SerializeField] Item convertableItem;
    [SerializeField] Item productedItem;
    [SerializeField] int productedItemCount = 1;

    [SerializeField] int timeToProcess = 5;

    ItemConvertorData data;
    Animator animator;

    private void Start()
    {
        TimeAgent timeAgent = GetComponent<TimeAgent>();
        timeAgent.onTimeTick += ItemConvertProcess;

        if(data == null)
        {
            data = new ItemConvertorData();
        }

        animator = GetComponent<Animator>();
        Animate();  
    }

    private void ItemConvertProcess()
    {
        if(data.itemSlot == null){return;}
        if(data.timer > 0f)
        {
            data.timer -= 1;
            if(data.timer <= 0f)
            {
                CompleteItemConversion();
            }
        }
    }

    public override void Interact(Character character)
    {
        if(data.itemSlot.item == null)
        {
            if (GameManager.instance.dragAndDropController.Check(convertableItem))
            {
                StarItemProcessing(GameManager.instance.dragAndDropController.itemSlot);
                return;
            }
            ToolbarController toolbarController = character.GetComponent<ToolbarController>();
            if(toolbarController == null){return;}

            ItemSlot itemSlot = toolbarController.GetItemSlot;

            if(itemSlot.item == convertableItem)
            {
                StarItemProcessing(itemSlot);
                return;
            }   
        }

        if(data.itemSlot.item != null && data.timer <= 0)
        {

            GameManager.instance.inventoryContainer.Add(data.itemSlot.item, data.itemSlot.count);

            data.itemSlot.Clear();

        }
    }

    private void StarItemProcessing(ItemSlot toProcess)
    {

        data.itemSlot.Copy(GameManager.instance.dragAndDropController.itemSlot);
        data.itemSlot.count = 1;

        if (toProcess.item.stackable)
        {
            toProcess.count -= 1;
            if(toProcess.count < 0)
            {
                toProcess.Clear();
            }
        }
        else
        {
            toProcess.Clear();
        }

        data.timer = timeToProcess;

        Animate();
    }

    private void Animate()
    {
        animator.SetBool("Working", data.timer > 0f);
    }



     private void CompleteItemConversion()
    {

        Animate();

        data.itemSlot.Clear();  

        data.itemSlot.Set(productedItem, productedItemCount);

    }

    public string Read()
    {
        return JsonUtility.ToJson(data);
    }

    public void Load(string jsonString)
    {
        data = JsonUtility.FromJson<ItemConvertorData>(jsonString);
    }

}