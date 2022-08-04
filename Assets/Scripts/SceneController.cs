using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;
    public GameObject Dummy;
    public GameObject DummyBars;
    public GameObject HealthBar;
    public GameObject WetnessBar;
    public GameObject DamageText;
    public float DamageTextTime;
    public GameObject Canvas;

    private Health DummyHealth;
    private State DummyState;
    private void Awake()
    {
        CheckInstance();
    }
    private void CheckInstance()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        DummyHealth = Dummy.GetComponent<Health>();
        DummyState = Dummy.GetComponent<State>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Dummy.SetActive(true);
            DummyHealth.Restore();
            DummyState.SetNormalState();
        }

        float value = DummyHealth.GetCurrent() / (float)DummyHealth.Maximum;
        UpdateBar(HealthBar, value);
        value = DummyState.GetWetness() / (float)DummyState.MaxWetness;
        UpdateBar(WetnessBar, value);
    }
    public int CalculateDamage(int damage, Health health)
    {
        if(health.gameObject.TryGetComponent(out State state))
        {
            if (state.CurrentState == State.StateList.Burn)
            {
                return damage + 10;
            }
            else if(state.CurrentState == State.StateList.Wet)
            {
                return damage - 10;
            }
        }
        return damage;
    }
    public void DealDamage(int damage, Health health)
    {
        health.Reduce(damage);
        ShowDamage(health.gameObject, damage);
    }
    public void ShowDamage(GameObject target, int value)
    {        
        GameObject text = Instantiate(DamageText);
        text.transform.SetParent(Canvas.transform);
        text.GetComponent<Text>().text = value.ToString();
        DamageText damageText = text.AddComponent<DamageText>();
        damageText.Target = target;
        damageText.LifeTime = DamageTextTime;
    }
    private void UpdateBar(GameObject bar, float value)
    {
        Image image = bar.GetComponent<Image>();
        image.fillAmount = value;
    }
}
