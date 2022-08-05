using UnityEngine;

public class Dot : MonoBehaviour
{
    public int Damage;
    public float TimeToTick;

    private Health Health;
    private State State;
    private float Timer;
    void Start()
    {
        Health = GetComponent<Health>();
        State = GetComponent<State>();
    }
    void Update()
    {
        Timer += Time.deltaTime;
        if(Timer >= TimeToTick)
        {
            Health.Reduce(Damage);
            Timer -= TimeToTick;
        }
        if(State.GetBurnTimer() <= 0)
        {
            Destroy(this);
        }
    }
}
