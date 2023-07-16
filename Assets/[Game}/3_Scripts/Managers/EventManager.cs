using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    public static UnityEvent CoinCollected = new UnityEvent();
    public static UnityEvent PlayerTakeDamage = new UnityEvent();
    public static UnityEvent PlayerFailed = new UnityEvent();

}