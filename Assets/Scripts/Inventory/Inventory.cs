using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region  Singleton
    public static Inventory instance;
    private void Awake() {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;
    public List<Item> items = new List<Item>();
    [SerializeField] int space = 6;
    public bool AddItem(Item item)
    {
        if(items.Count >= space)
        {
            print("Not Enough Room");
            return false;
        }
        items.Add(item);
        
        if(onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();

        return true;
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
        
        if(onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }

}
