using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    public class Random : MonoBehaviour
    {

        public static bool RandomBool()
        {
            int i = UnityEngine.Random.Range(0, 1);
            
            return i == 1 ? true : false;
        }
    }
}