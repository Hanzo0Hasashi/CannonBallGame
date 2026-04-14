using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CannonController : MonoBehaviour
{
    public float rotationSpeed = 30f;
    public Transform firePoint;
    public GameObject cannonballPrefab;
    public float shootForce = 500f;
    public int poolSize = 10;

    private float currentAngle = 0f;
    private Queue<GameObject> pool = new Queue<GameObject>();

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(cannonballPrefab);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    void Update()
    {
        float input = Input.GetAxis("Horizontal");
        currentAngle += input * rotationSpeed * Time.deltaTime;
        currentAngle = Mathf.Clamp(currentAngle, -30f, 30f);
        transform.localRotation = Quaternion.Euler(0, currentAngle, 0);

        if (Input.GetButtonDown("Fire1"))
            Shoot();
    }

    void Shoot()
    {
        GameObject ball = GetCannonball();
        ball.transform.position = firePoint.position;
        ball.transform.rotation = firePoint.rotation;
        ball.SetActive(true);

        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.AddForce(firePoint.forward * shootForce);

        StartCoroutine(ReturnToPool(ball, 3f));
    }

    GameObject GetCannonball()
    {
        if (pool.Count > 0)
            return pool.Dequeue();
        else
            return Instantiate(cannonballPrefab);
    }

    public void ReturnCannonball(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }

    IEnumerator ReturnToPool(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        ReturnCannonball(obj);
    }
}