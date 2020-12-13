using UnityEngine;


public class GunAim : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D playerRb;
    public SpriteRenderer Gun;

    private Camera _cam;
    private Vector2 mousePos;
    private Vector2 gunPos;

    private void Start()
    {
        LoadUICamera();
    }

    void Update()
    {
        mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {


        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg ;
        rb.rotation = angle - 90;
        Vector2 gunPos = mousePos - rb.position;

        
        
            var x = 1 * Mathf.Cos(angle * Mathf.Deg2Rad);
            var y = 1 * Mathf.Sin(angle * Mathf.Deg2Rad);
            var newPosition = playerRb.position;
            newPosition.x += x;
            newPosition.y += y;
            rb.position = newPosition;      
    }

    public void LoadUICamera()
    {
        _cam = Camera.main;
    }
}
