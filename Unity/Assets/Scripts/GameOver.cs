using UnityEngine;

public class GameOver : MonoBehaviour
{
    private bool isGameOver = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isGameOver)
            return;

        if (other.CompareTag("Player") ||
            other.transform.root.CompareTag("Player"))
        {
            isGameOver = true;

            Debug.Log("車に衝突！ゲームオーバー判定成功");
        }
    }
}