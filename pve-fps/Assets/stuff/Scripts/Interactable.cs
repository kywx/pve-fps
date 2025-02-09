using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string promptMessage;
    //public GameObject player;

    private void Start()
    {
        //player = GameObject.FindWithTag("Player");
    }

    public void BaseInteract()
    {
        Interact();
    }

    protected virtual void Interact()
    {
        // abstract method
    }

    //public int ReturnValue()
    //{
    //    return ReturnVal();
    //}

    //protected virtual int ReturnVal()
    //{
    //    // abstract method
    //    return 0;
    //}
}
