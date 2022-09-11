using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private ObjectController[] objects;
        
        
        [SerializeField] private float speed;
        private int index;
        private int debug;

        private void Start()
        {
            index = UnityEngine.Random.Range(0, objects.Length);
            objects[index].EnablePlatform();
            debug = 0;
        }

        private void Update()
        {
            if (!objects[index].isEnabledPlatform() && debug<100)
            {
                index = UnityEngine.Random.Range(0, objects.Length);
                objects[index].EnablePlatform();
                debug++;
                Debug.Log(index);
            }
        }

        public float GetSpeed()
        {
            return speed;
        }
    }
}