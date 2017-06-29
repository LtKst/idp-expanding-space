using UnityEngine;

public class Rotate : MonoBehaviour
{

    [SerializeField]
    Vector3 eulerAngles = new Vector3(0, 0, 1);
    [SerializeField]
    float rotationSpeed = 5f;

    private void Update()
    {
        transform.Rotate(eulerAngles * rotationSpeed * Time.deltaTime);
    }
}
