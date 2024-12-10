/*
 * Jakub Bukała
 * 
 * Created: 11.11.2018 r.
 * 
 * Edited: -
 *  
 * [LemEventListiner]
 * 
 * in Kurki
 * 
 */

using UnityEngine;
using UnityEngine.Events;

namespace Lem
{
    public class LemEventListener : MonoBehaviour
    {
        public LemEvent lemEvent;
        public UnityEvent response;

        public void OnEventRised()
        {
            response.Invoke();
        }

        private void OnEnable()
        {
            lemEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            lemEvent.UnregisterListener(this);
        }
    }
}
