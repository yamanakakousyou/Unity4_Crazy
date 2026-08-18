using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("ジャンプの設定")]
    public float jumpUpForce = 4.0f; // 上方向への力
    public float jumpForwardForce = 2.0f; // 前方向への力

    private Rigidbody rb;
    private bool isGrounded; // 地面に着地しているかどうかのフラグ

    void Start()
    {
         rb = GetComponent<Rigidbody>();    
    }

    // --- スペースキーが押されたときに呼び出される関数 ---
    void OnJump(InputValue value)
    {
        // 押された瞬間 & 地面に着地している時だけ
        if (value.isPressed　&& isGrounded)
        {
            // 上方向と前方向の力を計算する
            Vector3 jumpVelocity = (Vector3.up * jumpUpForce) + (transform.forward * jumpForwardForce);

            // 瞬間的な力を加える
            rb.AddForce(jumpVelocity, ForceMode.Impulse);

            // ジャンプした瞬間は地面から離れるので、フラグをflaseにする
            isGrounded = false;
        }
    }

    // --- 何らかのコライダーに触れている間は呼ばれる ---
    void OnCollisionStay(Collision collision)
    {
        // 触れている相手の表面が上向きに近い場合、地面と判定する
        foreach (ContactPoint contact in collision.contacts)
        {
            if(contact.normal.y > 0.6f)
            {
                isGrounded = true;
                break;
            }
        }
    }

    // --- 床から完全に離れた時 ---
    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
