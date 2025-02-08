using UnityEngine;

public class HatCollection : Interactable
{
    protected override void Interact()
    {
        base.Interact();  // v good code
        Destroy(gameObject);
        // TODO: Add hat effects here
            //player.hatScore++;
    }
}
