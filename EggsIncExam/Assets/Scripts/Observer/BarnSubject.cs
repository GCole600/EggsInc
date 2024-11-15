using System;
using Singleton;
using UnityEngine;

namespace Observer
{
    public class BarnSubject : Subject
    {
        private void OnEnable()
        {
            AddObserver(FindObjectOfType<UiManager>());
        }
        
        private void OnDisable()
        {
            RemoveObserver(FindObjectOfType<UiManager>());
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Chicken"))
            {
                GameManager.Instance.totalChickens += 1;
                NotifyObservers();
            }
        }
    }
}