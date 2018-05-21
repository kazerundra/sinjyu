using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleOrder
{
    public string name;
    public int order;

    public BattleOrder(string newName, int newOrder)
    {
        name = newName;
        order = newOrder;
    }
}
