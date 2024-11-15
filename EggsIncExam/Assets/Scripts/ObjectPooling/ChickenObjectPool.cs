using UnityEngine;
using UnityEngine.Pool;

namespace ObjectPooling
{
    public class ChickenObjectPool : MonoBehaviour
    {
        public GameObject chickPrefab;
        public GameObject evilChickPrefab;
        public Vector3 spawnPosition;
        public Vector3 endPosition;

        public int maxPoolSize = 100;
        public int stackDefaultCapacity = 100;
        
        private IObjectPool<Chicken> _pool;

        private IObjectPool<Chicken> Pool
        {
            get
            {
                if (_pool == null)
                    _pool = new ObjectPool<Chicken>(CreatedPooledItem, OnTakeFromPool, OnReturnedToPool, 
                        OnDestroyPoolObject, true, stackDefaultCapacity, maxPoolSize);
                return _pool;
            }
        }

        public void SpawnChick()
        {
            var newChick = Pool.Get();
            
            // Get the Chicken component and set its target position
            Chicken chick = newChick.GetComponent<Chicken>();
            
            if (chick != null)
                chick.SetTargetPosition(endPosition);
        }
        
        public void SpawnEvilOne()
        {
            GameObject newEvilOne = Instantiate(evilChickPrefab, spawnPosition, Quaternion.identity);
        }
        
        // Callback implementation
        private Chicken CreatedPooledItem()
        {
            GameObject newChick = Instantiate(chickPrefab, spawnPosition, Quaternion.identity);

            Chicken chick = newChick.GetComponent<Chicken>();
            
            chick.Pool = Pool;
            
            return chick;
        }

        // Object gets deactivated and removed from scene
        private void OnReturnedToPool(Chicken chick)
        {
            chick.gameObject.SetActive(false);
        }

        // Requests an instance from the pool
        private void OnTakeFromPool(Chicken chick)
        {
            chick.gameObject.SetActive(true);
        }

        // Method called when there is no more space in the pool,
        // Destroying the returned instance to free memory
        private void OnDestroyPoolObject(Chicken chick)
        {
            Destroy(chick.gameObject);
        }
    }
}
