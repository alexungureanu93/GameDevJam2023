using UnityEngine;

public class TorchController : MonoBehaviour
{
    public float torchSpeed = 5f;
    public float minX = -5f; // Minimum X position constraint
    public float maxX = 5f;  // Maximum X position constraint
    public float minY = -3f; // Minimum Y position constraint
    public float maxY = 3f;  // Maximum Y position constraint
    public Transform playerTransform;

    void Update()
    {
     Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    targetPosition.z = transform.position.z;

    // Apply position constraints relative to the player's position
    targetPosition.x = Mathf.Clamp(targetPosition.x, playerTransform.position.x + minX, playerTransform.position.x + maxX);
    targetPosition.y = Mathf.Clamp(targetPosition.y, playerTransform.position.y + minY, playerTransform.position.y + maxY);

    transform.position = Vector3.MoveTowards(transform.position, targetPosition, torchSpeed * Time.deltaTime);
    }
}
