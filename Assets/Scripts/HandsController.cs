using UnityEngine;

public class HandsController : MonoBehaviour
{
    public GameObject LeftHandGO;
    public GameObject RightHandGO;
    public GameObject Head;
    public float EquipDistance;

    private GameObject Weapon;
    private Hand LeftHand;
    private Hand RightHand;

    void Start()
    {
        LeftHand = LeftHandGO.GetComponent<Hand>();
        RightHand = RightHandGO.GetComponent<Hand>();
    }
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Head.transform.position, Head.transform.forward, out hit, EquipDistance))
        {
            if (hit.transform.gameObject.GetComponent<Weapon>())
            {
                Weapon = hit.transform.gameObject;
            }
        }
        else
        {
            Weapon = null;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            LeftHand.SetWeapon(Weapon);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            RightHand.SetWeapon(Weapon);
        }
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            LeftHand.Attack();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            RightHand.Attack();
        }
    }
}
