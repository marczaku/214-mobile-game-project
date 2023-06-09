using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    public PlayerModel player;
    
    // SINGLETON DESIGN PATTERN
    public static PlayerInput Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        // makes sure that this game object persists even when scene changes
        DontDestroyOnLoad(this);
    }
    
    void FixedUpdate()
    {
        // CONTROLLER - how is the information manipulated / changed?
        if (Input.GetKey(KeyCode.A))
        {
            player.Health++; // CONTROLLER UPDATES MODEL
        }
    }

    public void FullyHeal()
    {
        player.Health = player.MaxHealth;
    }
}
