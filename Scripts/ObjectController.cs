using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ObjectController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private BoxCollider2D startZoneBoxCollider2D;
        [SerializeField] private GameController _gameController;
        
        private float speed;
        private Vector2 tmpVec;
        private Vector2 currentVelocity;
        private bool isEnable;

        public BoxCollider2D[] colliders;
        

        void Start()
        {
            isEnable = false;
            colliders = transform.GetComponentsInChildren<BoxCollider2D>(); 
            SwitchCollider();
        }

        public void SwitchCollider()
        {
            foreach (var collider in colliders)
            {
                collider.enabled = !collider.enabled;
            }
        }

        public void EnablePlatform()
        {
            isEnable = true;
            SwitchCollider();
        }

        public bool isEnabledPlatform()
        {
            return isEnable;
        }

       
        void Update()
        {
            this.currentVelocity = this._rb.velocity;
            this.speed = _gameController.GetSpeed();
            
        }

        private void FixedUpdate()
        {
            if(isEnable)
                SetVelocityX(speed);
        }

        private void ResetObject()
        {
            var bounds = startZoneBoxCollider2D.bounds;
            var target = new Vector2(
                UnityEngine.Random.Range(bounds.min.x, bounds.max.x),
                transform.position.y
            );
            this.transform.position = target;
            SwitchCollider();
        }
        
        public void SetVelocityX(float velocity)
        {
            this.tmpVec.Set(velocity, this.currentVelocity.y);
            this._rb.velocity = this.tmpVec;
            this.currentVelocity = this.tmpVec;
        }
        
        private void OnTriggerExit2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("PlayZone") && isEnable)
            {
                ResetObject();
                SetVelocityX(0);
                isEnable = false;
                Debug.Log("Exited");
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            
        }
    }
}