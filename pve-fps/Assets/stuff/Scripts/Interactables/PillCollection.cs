using UnityEngine;

public class PillCollection : Interactable
{

    protected override void Interact()
    {
        base.Interact();  // v good code
        Destroy(gameObject);
        // TODO: Add pill effects here
    }
}
