using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items: MonoBehaviour
{
    public enum Item
    {
        NONE,
        BROOM
    }
    public static Items itemsSingleton = null;
    private void Start()
    {
        if (itemsSingleton != null)
            Destroy(gameObject);

        itemsSingleton = this;
    }
    public GameObject BroomPrefab;
    public GameObject GetPrefab(Item item)
    {
        switch(item)
        {
            case Item.BROOM:
                return BroomPrefab;
            default:
                return null;
        }
    }
}
   