using UnityEngine;
using UnityEngine.SceneManagement;

public class BossStatTracker : MonoBehaviour
{
    public static BossStatTracker Instance {get; private set;}
    
    //[SerializeField] private EnemyStats _bossBaseStats; This ScriptableObject will instead be found on the boss itself in the BossRoom scene

    public float _extraHealth;
    public float _extraDamage;
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;

       /* if (SceneManager.GetActiveScene().name != "BossRoom")
        {
            _extraHealth = 0;
            Debug.Log("zero");
        } */
    }

    

    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {
        BossShortcutKey();
    }

    public void AddHealth(float extraHealth)
    {
        _extraHealth += extraHealth;
    }

    public void AddDamage(float damage)
    {
        _extraDamage += damage;
    }

    private void BossShortcutKey()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("BossRoom");
        }
    }
}
