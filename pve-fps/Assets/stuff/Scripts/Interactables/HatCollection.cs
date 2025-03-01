using UnityEngine;

public class HatCollection : Interactable
{
    protected override void Interact()
    {
        Destroy(gameObject);
    }
    
}
