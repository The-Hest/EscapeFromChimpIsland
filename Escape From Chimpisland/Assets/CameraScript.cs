using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform LookAt;
    public Transform CurrentRoom;

    public float boundX = 2.0f;
    public float boundY = 1.5f;
    public float NRoomX = 20f;
    public float NRoomY = 12f;

    public float speed = 0.15f;

    private Vector3 desiredPosition;

  

    private void LateUpdate()
    {
        
    }
}
