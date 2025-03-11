using UnityEngine;

public class PillCollection : Interactable
{
    private Timer timer;
    public delegate void AddTime();
    public static event AddTime addTime;

    void Start()
    {
        timer = Object.FindFirstObjectByType<Timer>();

    }
    protected override void Interact()
    {

        Destroy(gameObject);
        // TODO: Add pill effects here
        timer.pill();
        addTime?.Invoke();
    }
}
