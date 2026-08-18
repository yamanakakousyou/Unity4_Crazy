using UnityEngine;

public class CameraController : MonoBehaviour
{
    // 追いかける対象
    public Transform playerTarget;

    // プレイヤーとカメラの距離
    public Vector3 offset = new Vector3(0.0f, 3.0f, -5.0f);

    // カメラの追いかけるスピード
    public float smoothSpeed = 5.0f;

    void LateUpdate()
    {
        if (playerTarget == null) return;

        // カメラが移動する目標地点を計算
        Vector3 desiredPosition = playerTarget.position + offset;

        // 現在のカメラの位置から目標地点まで、滑らかに移動させる
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // カメラの位置の更新
        transform.position = smoothedPosition;

        // 常にプレイヤーの方向を見続ける
        transform.LookAt(playerTarget);
    }
}
