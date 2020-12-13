using UnityEngine;

public class PlayerReset : MonoBehaviour
{
    public Transform playerPos;
    public GunAim gunAim;

    // Update is called once per frame
    void Update()
    {
        if (playerPos.position == Vector3.zero)
        {
            // Needed af camera changes upon scene swap
            gunAim.LoadUICamera();
            playerPos.position = Vector3.zero;
        }
    }
}
