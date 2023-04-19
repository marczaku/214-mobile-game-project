using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    public PlayerModel player;

    void FixedUpdate()
    {
        // CONTROLLER - how is the information manipulated / changed?
        if (Input.GetKey(KeyCode.A))
        {
            player.Health++; // CONTROLLER UPDATES MODEL
        }
    }
}
