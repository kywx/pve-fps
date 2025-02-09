using UnityEngine;

public class PillCollection : Interactable
{

    protected override void Interact()
    {
        Destroy(gameObject);
        // TODO: Add pill effects here
    }
}
