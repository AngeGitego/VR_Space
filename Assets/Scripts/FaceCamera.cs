using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    void LateUpdate()
    {
        // Make this object always look at the main camera
        Transform cam = Camera.main.transform;
        if (cam != null)
        {
            transform.LookAt(cam);
            transform.Rotate(0, 180, 0); // Flip so text isn't mirrored
        }
    }
}