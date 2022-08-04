using UnityEngine;

public class WaterBall : MonoBehaviour
{
    public int Wetness;
    private Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.gameObject.TryGetComponent(out State state))
        {
            state.IncreaseWetness(Wetness);
        }
        body.velocity = Vector3.zero;
        gameObject.SetActive(false);
    }
}
