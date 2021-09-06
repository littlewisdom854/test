using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour
{
    public float speed = 10.0f;
    public Camera followCamera;
    public Animator anim;

    private Rigidbody m_Rb;
    private Vector3 m_CameraPos;

    // Start is called before the first frame update
    void Awake()
    {
        m_Rb = GetComponent<Rigidbody>();
        m_CameraPos = followCamera.transform.position - transform.position;
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized;

        if (movement == Vector3.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(movement);

        Debug.Log(targetRotation.eulerAngles);

        targetRotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation,
            360 * Time.fixedDeltaTime);

        m_Rb.MovePosition(m_Rb.position + movement * speed * Time.fixedDeltaTime);
        m_Rb.MoveRotation(targetRotation);
    }

    private void LateUpdate()
    {
        followCamera.transform.position = m_Rb.position + m_CameraPos;
    }

    private void Update()
    {
      if(Input.GetKey(KeyCode.RightArrow))
      {
        anim.SetBool("running", true);
      }
      else if(Input.GetKey(KeyCode.UpArrow))
      {
        anim.SetBool("running", true);
      }
      else if(Input.GetKey(KeyCode.LeftArrow))
      {
        anim.SetBool("running", true);
      }
      else if(Input.GetKey(KeyCode.DownArrow))
      {
        anim.SetBool("running", true);
      }
      else if(Input.GetKey(KeyCode.Z))
      {
        anim.SetBool("cut", true);
      }
      else
      {
        anim.SetBool("running", false);
        anim.SetBool("cut", false);
      }

    }
}
