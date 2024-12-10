/*
 * Jakub Bukała
 * 
 * Created: 11.11.2018 r.
 * 
 * Edited: -
 *  
 * [LemEvent]
 * 
 * in Kurki
 * 
 */

using UnityEngine;
using System.Collections.Generic;

namespace Lem
{
    [CreateAssetMenu]
    public class LemEvent : ScriptableObject
    {
        private List<LemEventListener> listeners = new List<LemEventListener>();

        public void Rise()
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRised();
            }
        }

        public void RegisterListener(LemEventListener givenListener)
        {
            listeners.Add(givenListener);
        }

        public void UnregisterListener(LemEventListener givenListener)
        {
            listeners.Remove(givenListener);
        }
    }
}
