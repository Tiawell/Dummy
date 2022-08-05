using System;

public class EventManager
{
    public static Action<Health, int> OnTakeDamage;

    public static void SendTakeDamage(Health health, int value)
    {
        if(OnTakeDamage != null)
        {
            OnTakeDamage.Invoke(health, value);
        }
    }
}
