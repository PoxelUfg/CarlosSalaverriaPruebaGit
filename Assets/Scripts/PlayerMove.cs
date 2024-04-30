using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed;
    private float movX;
    private float movZ;

    private void Update()
    {
        movX = Input.GetAxis("Horizontal");
        movZ = Input.GetAxis("Vertical");

        transform.position += new Vector3(movX * speed * Time.deltaTime,
            transform.position.y,
            movZ * speed * Time.deltaTime);



    }

}
