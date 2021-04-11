using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{

    public Transform targetTransform;


    public float dist = 7.0f;
    public float height = 2.0f;
    public float dampTrace = 20.0f;

    private Transform tra;

    // Start is called before the first frame update
    void Start()
    {
        tra = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        tra.position = Vector3.Lerp(tra.position, targetTransform.position - (targetTransform.forward * dist) + (Vector3.up * height), Time.deltaTime * dampTrace);
        tra.LookAt(targetTransform.position);
    }
}
