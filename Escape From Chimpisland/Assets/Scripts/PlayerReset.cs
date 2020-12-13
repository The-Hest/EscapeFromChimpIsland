using UnityEngine;

public class PlayerReset : MonoBehaviour
{
    public Transform playerPos;
    public GunAim gunAim;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(playerPos.position, Vector3.zero) < 0.5)
        {
            // Needed af camera changes upon scene swap
            gunAim.LoadUICamera();
        }
    }
}
