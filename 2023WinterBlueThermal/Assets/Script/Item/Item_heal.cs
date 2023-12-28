using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_heal : Item
{
    int HealHp = 10;

    protected override void ItemEffect()
    {
        Debug.Log("Healed");
        player.GetHeal(HealHp);
    }
}