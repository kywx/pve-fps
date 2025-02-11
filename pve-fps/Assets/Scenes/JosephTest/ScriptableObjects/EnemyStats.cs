using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Scriptable Objects/EnemyStats", order = 1)]
public class EnemyStats : ScriptableObject
{
    public float health;
    public float chaseSpeed;
    public float knockback;

}
