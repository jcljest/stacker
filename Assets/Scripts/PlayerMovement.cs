using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 12f;

    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        transform.Translate(move * speed * Time.deltaTime, 0, 0);
    }
}
