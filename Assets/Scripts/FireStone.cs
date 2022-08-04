using UnityEngine;

public class FireStone : Weapon
{
    public GameObject FireSpray;
    public override void Attack()
    {
        FireSpray.SetActive(true);
        FireSpray.transform.SetParent(transform);
        FireSpray.transform.localPosition = Vector3.zero;
        FireSpray.transform.localRotation = new Quaternion(0, 0, 0, 0);
    }
}
