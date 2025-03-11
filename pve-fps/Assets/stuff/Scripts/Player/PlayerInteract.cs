using TMPro;
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
    public delegate void PickedHat();
    public static event PickedHat ActivateAnim;
    public delegate void PlayerGainDamage();
    public static event PlayerGainDamage AddDamage;



    [SerializeField] private float _damageBuff;

    private int myHats;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = GetComponent<PlayerCam>().cam;
        playerUI = GetComponent<PlayerUI>();
        actionManager = GetComponent<ActionManager>();

        myHats = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
       
        playerUI.UpdateText(string.Empty);
        // create a ray at the center of the camera, shooting outwards
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;  // collision info
        if (Physics.Raycast(ray, out hitInfo, distance, mask))  // out -> return info to hitInfo
        {
            // check if object hit is interactable
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                // then update screen text
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);
                if (actionManager.onFoot.Interact.triggered)
                {
                    // if the interactable is HatCollection, then update hats
                    if (interactable is HatCollection)
                    {
                        AddDamage?.Invoke();
                        ActivateAnim?.Invoke();
                        myHats++;
                        playerUI.UpdateHatScore(myHats);


                        GameObject.FindGameObjectWithTag("Stats").GetComponent<BossStatTracker>()._extraDamage += _damageBuff;
                    }
                    interactable.BaseInteract();  // base interact, may delete so always call last
                }
            }
        }
    }
}
