using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingCircle : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private int speed;
    [SerializeField] private int jumpPower;
    [SerializeField] private BoxCollider2D startZoneBoxCollider2D;

    private Vector2 tmpVec;
    private Vector2 currentVelocity;
    private int currentJumpPower;
    void Start()
    {
        currentJumpPower = jumpPower;
    }

    // Update is called once per frame
    void Update()
    {
        this.currentVelocity = this._rb.velocity;
    }

    private void FixedUpdate()
    {
        SetVelocityX(speed);
    }
    
    public void SetVelocityX(float velocity)
    {
        this.tmpVec.Set(velocity, this.currentVelocity.y);
        this._rb.velocity = this.tmpVec;
        this.currentVelocity = this.tmpVec;
    }
        
    

    private void ResetObject()
    {
        currentJumpPower = UnityEngine.Random.Range(5, 10);
        speed = UnityEngine.Random.Range(-3, -8);
        
        var bounds = startZoneBoxCollider2D.bounds;
        var target = new Vector2(
            UnityEngine.Random.Range(bounds.min.x, bounds.max.x),
            UnityEngine.Random.Range(bounds.min.y, bounds.max.y)
        );
        this.transform.position = target;
    }

   
    
    
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("PlayZone"))
        {
            ResetObject();
        }
    }
}
