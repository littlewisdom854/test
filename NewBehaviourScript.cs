using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

public float speed = 0.1f;
public Rigidbody2D rigid2D;
void Start () {
      print("Start");
    }

    void Update ()  {
      if(Input.GetKeyDown(KeyCode.A))
      {
        rigid2D.AddForce(new Vector2(0,-5), ForceMode2D.Impulse);
        print("Jump");
      }
     if(Input.GetKeyDown(KeyCode.Z))
     {
       rigid2D.AddForce(new Vector2(0,5), ForceMode2D.Impulse);
       print("Jump");
     }
     if(Input.GetKey(KeyCode.RightArrow))
     {
       this.gameObject.transform.position += new Vector3(speed,0,0);
     }
      if(Input.GetKey(KeyCode.LeftArrow))
     {
       this.gameObject.transform.position -= new Vector3(speed,0,0);
     }

    }
}
