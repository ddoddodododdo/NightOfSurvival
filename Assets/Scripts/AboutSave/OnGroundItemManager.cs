using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGroundItemManager : MonoBehaviour
{
    public static OnGroundItemManager instance;

    public List<OnGroundItem> allOnGroundItems; //�������ִ�
    public List<OnGroundItem> allOnGroundItemPrefabs;

    private Dictionary<string, OnGroundItem> itemDictionary;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
        allOnGroundItems.Capacity = 32;
        SetItemDictionary();
    }


    public OnGroundItem GetItemPrefab(string itemName)
    {
        if (itemDictionary.ContainsKey(itemName))
        {
            return itemDictionary[itemName];
        }

        Debug.LogWarning(itemName + "��(��) On Ground Item Dictionary�� ��ϵ����� �ʽ��ϴ�.");
        return null;
    }

    private void SetItemDictionary()
    {
        itemDictionary = new Dictionary<string, OnGroundItem>();

        foreach(var item in allOnGroundItemPrefabs)
        {
            itemDictionary.Add(item.objectName, item);
        }
    }

    public void DeleteAllItem()
    {
        foreach (var item in allOnGroundItems)
        {
            Destroy(item.gameObject);
        }
        
        allOnGroundItems.Clear();
    }

}
