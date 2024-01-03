using UnityEngine;
//Credit: https://www.youtube.com/c/Brackeys
public class KHC_cameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(1, 10)]
    public float smoothFactor;
    public Vector3 minPosition, maxPosition;
    
    void Start()
    {

    }

    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 targetPosition = target.position + offset;

        Vector3 boundPosition = new Vector3
        (
            Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x),
            Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y),
            Mathf.Clamp(targetPosition.z, minPosition.z, maxPosition.z)
        );

        Vector3 smoothPosition = Vector3.Lerp(transform.position, boundPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "barrel")
        {
            print("corner man speaks to you");
        }
    }

}
