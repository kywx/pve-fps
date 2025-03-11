using UnityEngine;
using UnityEngine.SceneManagement;

public class KillOnCollide : MonoBehaviour
{
   [SerializeField] GameObject Playercam;
    [SerializeField] Transform Player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.position.y <= -31)
        {
            Player.position = new Vector3(-17, 10, -24);

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            // SceneManager.LoadScene("StartMenu");
       

        }
        else 
        {
            other.gameObject.SetActive(false);
        }
        
    }
}
