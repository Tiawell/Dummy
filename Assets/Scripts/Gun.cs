using UnityEngine;

public class Gun : Weapon
{
    public int Damage;
    public GameObject Flash;
    private Vector2 Center;
    private void Start()
    {
        Center = new Vector2(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
    }
    public override void Attack()
    {
        Flash.SetActive(true);
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Center);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.TryGetComponent(out Health health))
            {
                health.Reduce(SceneController.Instance.CalculateDamage(Damage, health));
            }
        }
    }
    private void Update()
    {
        if (Flash.GetComponent<ParticleSystem>().isStopped)
        {
            Flash.SetActive(false);
        }
    }
}
