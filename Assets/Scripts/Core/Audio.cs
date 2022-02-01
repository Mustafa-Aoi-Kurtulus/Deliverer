using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Deliverer.Core
{
    public class Audio : MonoBehaviour
    {

        public void PlaySound(AudioSource source)
        {
            source.Play();
        }
        public void StopSound(AudioSource source)
        {
            source.Stop();
        }
 
    }
}

