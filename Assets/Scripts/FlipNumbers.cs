using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GalaxyShooter
{
    public class FlipNumbers : MonoBehaviour
    {
        private Dictionary<int, int> dictionary = new Dictionary<int, int>();
        
        public void IsMirror(int num) {

            dictionary.Add(6,9);
            dictionary.Add(9,6);
            dictionary.Add(0,0);
            dictionary.Add(8,8);

            int sum = 0;
            while(num > 0) {
                int digit = num%10;
                if (dictionary.ContainsKey(digit))
                    digit = dictionary[digit];
                
                Debug.Log(sum + " " +  num);

                sum += digit*10;
                num /= 10; 
            }

            Debug.Log(sum == num);
        }

        private void Start()
        {
            IsMirror(69);
        }
    }
}
