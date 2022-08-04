using UnityEngine;

public class Hand : MonoBehaviour
{
    private GameObject Weapon;
    private float Height;
    public void Attack()
    {
        if (Weapon != null)
        {
            Weapon.GetComponent<Weapon>().Attack();
        }
    }
    public void DropWeapon()
    {
        Weapon.transform.SetParent(null);
        Vector3 position = Weapon.transform.position;
        position.y = Height;
        Weapon.transform.position = position;
        Weapon = null;
    }
    public void EquipWeapon(GameObject weapon)
    {
        Height = weapon.transform.position.y;
        Weapon = weapon;
        Weapon.transform.SetParent(gameObject.transform);
        Weapon.transform.localPosition = Vector3.zero;
        if(weapon.GetComponent<Gun>())
        {
            Weapon.transform.localRotation = new Quaternion(0, -0.7f, 0, 0.7f);
            //Поворот пистолета на -90 градусов по Y, цифры получены методом научного тыка в гугол
        }
        else
        {
            Weapon.transform.localRotation = new Quaternion(0, 0, 0, 0);
        }
    }
    public void SetWeapon(GameObject weapon)
    {
        if (Weapon == null && weapon != null)
        {
            EquipWeapon(weapon);
        }
        else if (Weapon != null && weapon != null)
        {
            DropWeapon();
            EquipWeapon(weapon);
        }
        else if (Weapon != null)
        {
            DropWeapon();
        }
    }
}
