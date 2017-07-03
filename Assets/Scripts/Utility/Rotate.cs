using UnityEngine;

public class Rotate : MonoBehaviour
{

    public float rotationSpeed = 5f;

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1) * rotationSpeed * Time.deltaTime);
    }
}
