using System;
using System.Collections;
using System.Collections.Generic;
using GameLogic;
using UnityEngine;

public class GalatiCat : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    bool isJumping;

    public Rigidbody rig;
    FoodController _foodController;

    void OnEnable()
    {
        _foodController = FindObjectOfType<FoodController>();
    }

    void Update() {
        
        Move();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }
    }

    void FixedUpdate()
    {
        if (!isJumping) return;
        Jump();
        isJumping = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("food"))
        {
            _foodController.CheckIfEnds(other.gameObject.name.Split('(')[0]);
            Destroy(other.gameObject);
        }
    }


    void Move ()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 dir = transform.right * x + transform.forward * z;
        dir *= moveSpeed;
        dir.y = rig.velocity.y;

        rig.velocity = dir;
        
    }

    void Jump()
    {
        if(CanJump())
        {
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            FindObjectOfType<AudioManager>().Play("playerJump");
        }
    }

    bool CanJump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 0.1f))
        {
            return hit.collider != null;
        }

        return false;
    }
}
