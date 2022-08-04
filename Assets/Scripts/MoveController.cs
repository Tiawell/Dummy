using UnityEngine;

public class MoveController : MonoBehaviour
{
    public int MoveSpeed;
    public float RotationSpeed;
    [Range(0, 0.5f)]
    public float MaximumAngle;
    public GameObject Head;

    private Rigidbody Body;
    private Quaternion Rotation;
    private float HorisontalRotatation;
    private float VerticalRotatation;

    void Start()
    {
        Body = GetComponent<Rigidbody>();
    }
    void Update()
    {
        HorisontalRotatation = Input.GetAxis("Mouse X") * RotationSpeed;
        VerticalRotatation = -Input.GetAxis("Mouse Y") * RotationSpeed;
        Head.transform.Rotate(VerticalRotatation, 0, 0);

        Rotation = Head.transform.localRotation;
        if (Rotation.x < -MaximumAngle)
        {
            Rotation.x = -MaximumAngle;
            Head.transform.localRotation = Rotation;
        }
        else if (Rotation.x > MaximumAngle)
        {
            Rotation.x = MaximumAngle;
            Head.transform.localRotation = Rotation;
        }

        transform.Rotate(0, HorisontalRotatation, 0);
        //Вертикально крутится только башка, горизонтально всё тело

        if (Input.GetKey(KeyCode.W))
        {
            Move(Body.transform.forward);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Move(-1 * Body.transform.forward);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Move(Body.transform.right);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Move(-1 * Body.transform.right);
        }
    }
    public void Move(Vector3 direction)
    {
        Body.AddForce(MoveSpeed * Time.deltaTime * direction, ForceMode.Impulse);
    }
}
