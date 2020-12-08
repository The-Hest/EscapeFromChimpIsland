using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    private float shakeTimeRemaining;
    private float shakePower;
    private float shakeFadeTime;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartCameraShake(0.1f, 0.3f);
        }
    }

    private void LateUpdate()
    {
        if(shakeTimeRemaining > 0)
        {
            shakeTimeRemaining -= Time.deltaTime;

            // Get random values for shake
            float shakeX = Random.Range(-1f, 1f);
            float shakeY = Random.Range(-1f, 1f);

            transform.position += new Vector3(shakeX * shakePower, shakeY * shakePower, 0f);
            shakePower = Mathf.MoveTowards(shakePower, 0f, shakeFadeTime * Time.deltaTime);
        }
    }

    public void StartCameraShake(float duration, float magnitude)
    {
        shakeTimeRemaining = duration;
        shakePower = magnitude;

        // Decrease the magnitude of the shake wrt the duration
        shakeFadeTime = magnitude / duration;
    }
}
