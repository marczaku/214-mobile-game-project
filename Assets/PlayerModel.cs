using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Very safe to add mew values to this class.
/// Also easy to merge, even if there's conflicts.
/// </summary>
public class PlayerModel : MonoBehaviour
{
    public int maxHealth = 1000;
    [SerializeField] int health = 50; // MODEL what is the current state of information?
    public float rotation;
    
    public int Health
    {
        get => health;
        set => health = Mathf.Clamp(0, maxHealth, value);
    }

    public void SetRotationDegree(float degree)
    {
        rotation = degree * Mathf.Deg2Rad;
    }
}
