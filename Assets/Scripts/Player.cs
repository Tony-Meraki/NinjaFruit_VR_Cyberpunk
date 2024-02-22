using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int score = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        raycasting();

        //RaycastHit hit;

        //if (Physics.Raycast(transform.position, transform.forward, out hit))
        //{
        //    if(hit.transform.GetComponent<FruitControll>() != null)
        //    {
        //        score += 100;
        //        Destroy(hit.transform.gameObject);
        //    }
        //}
    }

    void raycasting()
    {
        RaycastHit hit;

        Vector3 forward = transform.TransformDirection(Vector3.forward * 10);
        if(Physics.Raycast(transform.position, forward, out hit))
        {
            Debug.Log("hit!");
            score += 100;
            Destroy(hit.transform.gameObject);
        }
        Debug.DrawRay(transform.position, forward, Color.blue);
    }
}
