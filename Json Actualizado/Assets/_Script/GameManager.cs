using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    [Header("CONTADOR ITEM")]
    public static GameManager instance;
    public TMP_Text itemCountText;
    
    public int itemCount = 0;

    void Awake()
    {
       instance = this;
    }

    public void CollectableItem(int value)
    {
        itemCount += value;
        UpdateItemCount();
    }
    
    void UpdateItemCount()
    {
        itemCountText.text = " : " + itemCount.ToString();
    }
}
