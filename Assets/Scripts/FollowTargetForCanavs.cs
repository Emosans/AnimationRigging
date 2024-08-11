using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target; // The target (player or object) to follow
    public Vector3 offset; // Offset from the target position

    void Update()
    {
        if (target != null)
        {
            // Update the canvas position to follow the target with the offset
            //transform.position = target.position + offset;

            // Optionally, make the canvas always face the camera
            transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward,
                            Camera.main.transform.rotation * Vector3.up);

            Vector3 eulerAngles = transform.eulerAngles;
            eulerAngles.y += 90;
            transform.eulerAngles = eulerAngles;
        }
    }
}
