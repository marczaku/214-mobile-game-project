using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// Very safe to add mew values to this class.
/// Also easy to merge, even if there's conflicts.
/// </summary>
[CreateAssetMenu]
public class PlayerModel : ScriptableObject
{
    [SerializeField] int maxHealth = 1000;
    [SerializeField] int health = 50; // MODEL what is the current state of information?
    public float rotation;

    public UnityEvent<int> HealthChanged;
    public UnityEvent<int> MaxHealthChanged;

    public int Health
    {
        get => health;
        set
        {
            health = Mathf.Clamp(value, 0, maxHealth);
            HealthChanged.Invoke(health);
        } 
    }

    public int MaxHealth
    {
        get => maxHealth;
        set
        {
            maxHealth = value;
            MaxHealthChanged.Invoke(maxHealth);
        }
    }

    public void SetRotationDegree(float degree)
    {
        rotation = degree * Mathf.Deg2Rad;
    }
}
