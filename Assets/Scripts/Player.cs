using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private int speed = 3;
    [SerializeField] private int jumpForce = 3;
    bool isGrounded;

    void Update()
    {
        gameObject.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            Jump();
        }
    }

    void Jump()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            SceneManager.LoadScene("Level 2");
        }
        else if(other.tag == "Obstacle")
        {
            SceneManager.LoadScene("Level 1");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
