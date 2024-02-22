using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitControll : MonoBehaviour
{

    public float verticalForce = 500f; //400
    public float horizontalForce = 30f; //150
    public float ZForce = -400f;
    public float lifetime = 2f;

    //시간이 지남에 따라 점점 빠르게
    public float verticalForceSet = 500.0f;
    public float time_data;

    void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(new Vector3(
                //horizontalForce,
                Random.Range(-horizontalForce -30, horizontalForce),
                verticalForce,
                ZForce
            ));


        //시간이 지남에 따라 점점 빠르게
        GameController gameController = GameObject.Find("GameController").GetComponent<GameController>();
        time_data = gameController.gameTimer;
        //verticalForce = verticalForceSet - (time_data * +5);
        ZForce = verticalForceSet + (time_data * +5);
        //Debug.Log(ZForce);

    }


    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
