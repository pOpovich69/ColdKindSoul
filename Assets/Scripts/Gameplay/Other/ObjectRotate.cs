using UnityEngine;

public class ObjectRotate : MonoBehaviour
{
    public float speed = 30f;
    void FixedUpdate()
    {
        this.transform.Rotate(0f, 0f, speed * Time.deltaTime);
    }
}
