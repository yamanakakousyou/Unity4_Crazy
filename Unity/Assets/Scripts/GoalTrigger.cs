using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    private bool isCleared = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isCleared) return;

        if (other.CompareTag("Player"))
        {
            isCleared = true;
            Debug.Log("ゲームクリア！");
        }
    }
}