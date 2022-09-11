using System;
using UnityEngine;

namespace Platforms
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private int speed;
        [SerializeField] private BoxCollider2D _startZoneBoxCollider2D;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        private Vector2 tmpVec;
        private Vector2 currentVelocity;
        private void Start()
        {
            
        }

        public void StartMoving()
        {
            
        }

        private void Update()
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
            speed = UnityEngine.Random.Range(-3, -10);
            var newSize = new Vector2(
                UnityEngine.Random.Range(3, 10),
                _spriteRenderer.size.y
            );
            _spriteRenderer.size = newSize;
            var bounds = _startZoneBoxCollider2D.bounds;
            var target = new Vector2(
                UnityEngine.Random.Range(bounds.min.x+newSize.x, bounds.max.x),
                UnityEngine.Random.Range(bounds.min.y, bounds.min.y+3)
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
}