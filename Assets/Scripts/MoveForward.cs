using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private readonly float speed = 15f;

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
