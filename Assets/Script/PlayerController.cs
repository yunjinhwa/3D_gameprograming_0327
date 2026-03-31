using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2;
    float jumbForce = 680.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigidbody2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            this.rigidbody2.AddForce(transform.up * this.jumbForce);
        }
    }
}
