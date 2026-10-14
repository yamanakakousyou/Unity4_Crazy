
using UnityEngine;

public class CarMover : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private void Update()
    {
        transform.position +=
            transform.forward * moveSpeed * Time.deltaTime;
    }
}
