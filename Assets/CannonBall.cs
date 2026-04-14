using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            
           
        }
    }
}