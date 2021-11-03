using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 cameraOffset = new Vector3(0f, 7f, -10f);

    void LateUpdate()
    {
        transform.position = player.transform.position + cameraOffset;
    }
}
