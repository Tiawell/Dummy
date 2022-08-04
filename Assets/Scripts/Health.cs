using UnityEngine;

public class Health : MonoBehaviour
{
    public int Maximum;
    private int Current;

    void Start()
    {
        Restore();
    }
    public int GetCurrent()
    {
        return Current;
    }
    public void Reduce(int value)
    {
        SceneController.Instance.ShowDamage(gameObject, value);
        Current -= value;
        if(Current <= 0)
        {
            Current = 0;
            Hide();
        }
    }
    public void Restore()
    {
        Current = Maximum;
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
