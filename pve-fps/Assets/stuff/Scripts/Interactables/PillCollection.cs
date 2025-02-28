using UnityEngine;

public class PillCollection : Interactable
{
    private Timer timer;

    void Start()
    {
        timer = Object.FindFirstObjectByType<Timer>();

    }
    protected override void Interact()
    {
        Destroy(gameObject);
        // TODO: Add pill effects here
        timer.pill();
    }
}
