using UnityEngine;

public class DoorExit : MonoBehaviour
{
    [SerializeField] public int levelIndex;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerExited();
        }
    }

    public void PlayerExited()
    {
        if (ProgressTracker.Instance != null)
        {
            ProgressTracker.Instance.MarkLevelCompleted(levelIndex);
        }
    }
}
