using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemModel
{
  
    public int Id { get; set; }
    public string Name { get; set; }
    public ItemType Type { get; set; }
    public string Description { get; set; }
    public int MaxLimit { get; set; }


    public enum ItemType
    {
        aaa = 0,
        bbb = 1
    }

    public override string ToString()
    {
        return string.Format("Id: {0}, Name: {1}, Type:{2}, Description: {3}, MaxLimit: {4}", Id, Name,Type, Description, MaxLimit);
    }
}
