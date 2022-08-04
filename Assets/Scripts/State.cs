using UnityEngine;

public class State : MonoBehaviour
{
    public enum StateList
    {
        Normal,
        Burn,
        Wet
    }

    public Material Normal;
    public Material Burn;
    public Material Wet;

    public StateList CurrentState;
    public int MaxWetness;
    private int Wetness;
    private float BurnTimer;
    private Material Material;

    void Start()
    {
        if (gameObject.TryGetComponent(out SkinnedMeshRenderer renderer))
        {
            Material = renderer.material;
        }
    }
    void Update()
    {
        BurnTimer -= Time.deltaTime;
        if (BurnTimer < 0)
        {
            BurnTimer = 0;
        }
        if(BurnTimer == 0 && Wetness == 0)
        {
            SetNormalState();
        }
    }
    public void IncreaseWetness(int value)
    {
        Wetness += value;
        if (Wetness > MaxWetness)
        {
            Wetness = MaxWetness;
        }
        BurnTimer = 0;
        SetWetState();
    }
    public void ReduceWetness(int value)
    {
        Wetness -= value;
        if (Wetness < 0)
        {
            Wetness = 0;
            SetNormalState();
        }
    }
    public void SetWetState()
    {
        CurrentState = StateList.Wet;
        ChangeColor(Wet);
    }
    public void SetNormalState()
    {
        Wetness = 0;
        BurnTimer = 0;
        CurrentState = StateList.Normal;
        ChangeColor(Normal);
    }
    public void SetBurnState(float timer)
    {
        CurrentState = StateList.Burn;
        ChangeColor(Burn);
        BurnTimer = timer;
    }
    public int GetWetness()
    {
        return Wetness;
    }
    public float GetBurnTimer()
    {
        return BurnTimer;
    }
    public void ChangeColor(Material material)
    {
        Material.color = material.color;
    }
}
