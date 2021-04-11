using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mon : MonoBehaviour
{
    public Transform targetTransform;
    public GameObject fx_obj;
    private Animator ani;
    public float Die = 3.0f;
    public bool oo = false;

    private Transform tra;



    public float z_pos = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        tra = GetComponent<Transform>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            oo = true;

            ani.SetBool("death", true);
            // Instantiate(fx_obj, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }

    }

    private void Update()
    {

        if (oo && Die < 0.0f)
        {
            Destroy(gameObject);
        }
         else if (oo)
        {
            Die -= Time.deltaTime;
        }

     

    }

}
