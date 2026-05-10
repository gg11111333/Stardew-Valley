using UnityEngine;

public class TreeCuttable : ToolHit
{
    [SerializeField] GameObject pickUpDrop;

    [SerializeField] float speed = 0.7f;
    [SerializeField] Item item;
    [SerializeField] int itemCountInOneDrop = 1;    
    [SerializeField] int dropCount = 5;
    public override void Hit()
    {
        while (dropCount > 0)
        {       
            dropCount -= 1;

            Vector3 position = transform.position;
            position.x += speed * UnityEngine.Random.value - speed / 2;
            position.y += speed * UnityEngine.Random.value - speed / 2;
            
            ItemSpawnManager.instance.SpawnItem(position, item, itemCountInOneDrop);

        }
        Destroy(gameObject);
    }
}
