using UnityEngine;

public class DamageText : MonoBehaviour
{
    public GameObject Target;
    public float LifeTime;
    private Vector3 position;
    void Start()
    {
        position = Target.transform.position;
        position.y += Target.transform.localScale.y * 2;
    }
    void Update()
    {
        LifeTime -= Time.deltaTime;
        if(LifeTime <= 0)
        {
            Destroy(gameObject);
        }
        position.y += Time.deltaTime * 2;
        transform.position = Camera.main.WorldToScreenPoint(position); ;
    }
}
