using UnityEngine;

public class CarMover : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Transform roadEdge;

    public void SetRoadEdge(Transform edge)
    {
        roadEdge = edge;
    }

    private void Update()
    {
        // 元々の移動処理は変更しない
        transform.position +=
            transform.forward * moveSpeed * Time.deltaTime;

        if (roadEdge == null)
            return;

        // 車の進行方向に対して右端を通過したら削除
        float distance = Vector3.Dot(
            transform.position - roadEdge.position,
            transform.forward.normalized
        );

        if (distance >= 0f)
        {
            Destroy(gameObject);
        }
    }
}