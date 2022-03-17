using UnityEngine;

public class Character2DController : MonoBehaviour
{
    public float MovementSpeed = 1;

    private void Start()
    {
        
    }

    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        var movement2 = Input.GetAxis("Vertical");

        transform.position += new Vector3(movement, movement2, 0) * Time.deltaTime * MovementSpeed;
    }
}
