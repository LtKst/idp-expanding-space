using UnityEngine;

namespace Utility
{
    public class Random : MonoBehaviour
    {

        public static bool RandomBool()
        {
            int i = UnityEngine.Random.Range(0, 2);
            
            return i == 1 ? true : false;
        }
    }
}