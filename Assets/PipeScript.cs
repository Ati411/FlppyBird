using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public float deadZone = -15f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if (GameManager.instance != null)
        {
            transform.position = transform.position + (Vector3.left * GameManager.instance.pipespeed * Time.deltaTime);
        }

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
