using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class JetskiMovement : MonoBehaviour
{
    [HideInInspector]
    public bool isMoving = false;
    public GameObject smokeEffect;
    public Transform groundCheck;
    public float rotationSpeed;
    public float dirSpeed;
    //float angularSpeed = 7;
    bool onRamp = false;
    RaycastHit hit;
    public Rigidbody rb;
    //Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        smokeEffect.SetActive(false);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < -1.5f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        //Debug.Log(isGrounded());
        boatRotation();
        //Debug.Log(isGrounded());
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            isMoving = true;
            smokeEffect.SetActive(true);
            //When the ray hits anything, print the world position of what the ray hits using hit.point
            if (Physics.Raycast(ray, out hit) && Input.GetMouseButton(0))
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(hit.point.x, transform.position.y, transform.position.z), dirSpeed * Time.deltaTime);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            smokeEffect.SetActive(false);
            isMoving = false;
            rb.angularVelocity = Vector3.zero;
        }

    }
    bool isGrounded()
    {
        return Physics.Raycast(groundCheck.position, Vector3.down, 0.5f);
    }
    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, Vector3.down * 0.5f, Color.blue);
    }
    void boatRotation()
    {
        if (isGrounded() == false && Input.GetMouseButton(0) && onRamp == false)
        {
            isMoving = true;
            smokeEffect.SetActive(true);
            transform.Rotate(-rotationSpeed * Time.deltaTime, 0, 0);
            //rotationSpeed = rb.velocity.magnitude;
            //angularSpeed = rb.angularVelocity.magnitude;
            //rb.maxAngularVelocity = float.MaxValue;
            //rb.AddTorque(Vector3.forward);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ramp"))
        {
            onRamp = true;
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ramp"))
        {
            onRamp = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SecondLevel"))
        {
            SceneManager.LoadScene("Level2");
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene("Levels");
        }
    }
}
