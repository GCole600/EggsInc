using System;
using UnityEngine;

namespace ObjectPooling
{
    public class EvilChicken : MonoBehaviour
    {
        private Transform _target;
        private float _speed = 5.0f;

        private void Start()
        {
            var obj = FindAnyObjectByType<Chicken>();
            
            if (obj)
                _target = obj.transform;
            else
                Destroy(this.gameObject);
        }

        private void Update()
        { 
            var obj = FindAnyObjectByType<Chicken>();
            if (obj)
                transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
            else
                Destroy(this.gameObject);
        }
    }
}
