using UnityEngine;

public class FireSpray : MonoBehaviour
{
    public int BaseDamage;
    public int DotDamage;
    public float DotLifeTime;
    public float DotTickTime;

    private void Update()
    {
        if(gameObject.GetComponent<ParticleSystem>().isStopped)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.TryGetComponent(out State state))
        {
            if (state.CurrentState == State.StateList.Wet)
            {
                state.ReduceWetness(BaseDamage);
            }
            else
            {
                state.SetBurnState(DotLifeTime);
                if (other.TryGetComponent(out Health health))
                {
                    SceneController.Instance.DealDamage(BaseDamage, health);

                    if (other.TryGetComponent(out Dot dot))
                    {
                        return;
                    }
                    else
                    {
                        dot = other.AddComponent<Dot>();
                        dot.Damage = DotDamage;
                        dot.TimeToTick = DotTickTime;
                    }
                }
            }
        }
    }
}
