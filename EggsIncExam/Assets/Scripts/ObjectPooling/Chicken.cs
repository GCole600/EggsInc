using UnityEngine;
using UnityEngine.Pool;

namespace ObjectPooling
{
    public class Chicken : MonoBehaviour
    {
        public IObjectPool<Chicken> Pool { get; set; }
        
        private Vector3 _startPosition;
        private Vector3 _targetPosition;
        private float _lerpTime = 3f;
        private float _lerpProgress;

        private void OnDisable()
        {
            ResetPosition();
        }
        
        private void Update()
        {
            _lerpProgress += Time.deltaTime / _lerpTime;
            
            transform.position = Vector3.Lerp(_startPosition, _targetPosition, _lerpProgress);

            // Return to pool when it reaches the target position
            if (_lerpProgress >= 1f)
                ReturnToPool();
        }
        
        public void SetTargetPosition(Vector3 position)
        {
            _startPosition = transform.position;
            _targetPosition = position;
        }
        
        private void ReturnToPool()
        {
            Pool.Release(this);
        }

        private void ResetPosition()
        {
            transform.position = _startPosition;
            _lerpProgress = 0f;
        }
    }
}
