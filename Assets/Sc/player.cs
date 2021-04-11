using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Animator ani;

    private Transform tra;
  //  private float hor =  0.0f;
    private float ver = 0.0f;

    private float moving_speed = 5.0f;
    private float rot_speed = 500.0f;

    float cool = 0.0f;


    public GameObject obj;

   private void player_Moving_Control()
    {
       // hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        Vector3 moveDirect = (Vector3.forward * ver);  // + (Vector3.right * hor);


        if(cool <= 0.0f)
            tra.Translate(moveDirect.normalized * Time.deltaTime * moving_speed);



        tra.Rotate(Vector3.up * Time.deltaTime * rot_speed * Input.GetAxis("Mouse X"));


        if (Input.GetKeyUp(KeyCode.Mouse0) && cool<= 0.0f)
        {
            Debug.Log("mouse pressed");
            Instantiate(obj, new Vector3(tra.position.x , tra.position.y + 1.6f, tra.position.z),tra.rotation );
            ani.SetBool("shot", true);
            cool = 1.0f;
        }

        if (cool > 0.0f)
        {
            cool -= Time.deltaTime;
            if(cool <= 0.5f )
            ani.SetBool("shot", false);
        }

        if (ver >= 0.1f) {

            ani.SetBool("run", true);
        }


        else
        {
            ani.SetBool("run", false);
        }




    }
    // Start is called before the first frame update
 
    void Start()
    {
        tra = GetComponent<Transform>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        player_Moving_Control();
    
    }
}
