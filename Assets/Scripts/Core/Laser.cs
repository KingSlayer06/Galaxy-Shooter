using System;
using GalaxyShooter.Managers;
using UnityEngine;

namespace GalaxyShooter.Core
{
    public class Laser : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;

        private void Start()
        {
            GameManager.Instance.audioManager.PlaySound("laser");
        }

        private void Update()
        {
            transform.Translate(Vector3.up * (_speed * Time.deltaTime));

            if (transform.position.y >= 8f)
            {
                if (transform.parent)
                    Destroy(transform.parent.gameObject);
                else
                    Destroy(gameObject);
            }
        }
    }
}