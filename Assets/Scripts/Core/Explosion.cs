using System.Collections;
using UnityEngine;

namespace GalaxyShooter.Core
{
    public class Explosion : MonoBehaviour
    {
        [SerializeField] private AnimationClip _amimation;
        
        private void Start()
        {
            StartCoroutine(Destroy());
        }

        IEnumerator Destroy()
        {
            yield return new WaitForSeconds(_amimation.length);
            Destroy(gameObject);
        }
    }
}
