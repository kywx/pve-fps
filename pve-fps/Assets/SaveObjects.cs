using UnityEngine;

public class SaveObjects : MonoBehaviour
{
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

    }


}
