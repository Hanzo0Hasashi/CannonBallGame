using UnityEngine;

public class Target : MonoBehaviour
{
    public int points = 1;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cannonball"))
        {
            UIManager ui = FindFirstObjectByType<UIManager>();
            if (ui != null)
                ui.AddScore(points);

            // Ничего не делаем с мишенью, просто даём очки
            Debug.Log("Попадание! +1 очко");
        }
    }
}