using UnityEngine;

public class Target : MonoBehaviour
{
    public int points = 1;
    public Color hitColor = Color.red;      // цвет при попадании
    public float colorDuration = 0.2f;      // как долго держится цвет

    private Renderer rend;
    private Color originalColor;
    private UIManager ui;

    void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
        ui = FindFirstObjectByType<UIManager>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cannonball"))
        {
            // Начисляем очки
            if (ui != null)
                ui.AddScore(points);

            // Меняем цвет
            rend.material.color = hitColor;

            // Возвращаем цвет обратно через colorDuration секунд
            Invoke("ResetColor", colorDuration);

            Debug.Log("Попадание! +" + points + " очко");
        }
    }

    void ResetColor()
    {
        rend.material.color = originalColor;
    }
}