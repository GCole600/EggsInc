using System;
using ObjectPooling;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Singleton
{
    public class GameManager : Singleton<GameManager>
    {
        public float totalChickens;
        public float totalProfit;

        private int _spawnBad;
        
        private ChickenObjectPool _pool;

        private bool _keyboardMode = true;
        
        void Start()
        {
            _pool = gameObject.GetComponent<ChickenObjectPool>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                _keyboardMode = !_keyboardMode;
            }
            
            if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Tab) && _keyboardMode)
            {
                _spawnBad = Random.Range(0, 10);
                
                if (_spawnBad <= 2)
                    _pool.SpawnEvilOne();
                
                else
                    _pool.SpawnChick();
            }
            else if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Tab) && !_keyboardMode)
            {
                var evilChickens = FindObjectsOfType<EvilChicken>();

                foreach (var chicken in evilChickens)
                {
                    Destroy(chicken.gameObject);
                }
            }

            totalProfit += (totalChickens * 0.02f);
        }
    }
}