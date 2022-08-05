using UnityEngine.Events;
using UnityEngine;

public class EventManager
{
    public static UnityEvent<GameObject, int> OnTakeDamage = new UnityEvent<GameObject, int>();

    public static void SendTakeDamage(GameObject target, int value)
    {
        OnTakeDamage.Invoke(target, value);
    }
}
