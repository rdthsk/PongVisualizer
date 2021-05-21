using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class Paddle : MonoBehaviour
{
    //Shown in Inspector
    [SerializeField] private string inputAxis;
    [SerializeField] private float speed;
    
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float translate = Input.GetAxisRaw(inputAxis) * speed * Time.deltaTime;
        transform.Translate(0f, translate, 0f);
    }
}
