using UnityEngine;

public class WaterStone : Weapon
{
    public GameObject WaterBall;
    public float Force;
    public override void Attack()
    {
        if(WaterBall.activeSelf)
        {
            return;
        }
        WaterBall.SetActive(true);
        Rigidbody body = WaterBall.GetComponent<Rigidbody>();
        WaterBall.transform.position = transform.position;
        Vector3 direction = transform.forward;
        body.AddForce(direction * Force, ForceMode.Impulse);
    }
}
