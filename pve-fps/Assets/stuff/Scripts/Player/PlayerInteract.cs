using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI playerUI;
    private ActionManager actionManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = GetComponent<PlayerCam>().cam;
        playerUI = GetComponent<PlayerUI>();
        actionManager = GetComponent<ActionManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        // create a ray at the center of the camera, shooting outwards
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;  // collision info
        if (Physics.Raycast(ray, out hitInfo, distance, mask))  // out -> return
        {
            // check if object hit is interactable
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                // then update screen text
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);
                if (actionManager.onFoot.Interact.triggered)
                {
                    interactable.BaseInteract();  // interact function
                }
            }
        }
    }
}
