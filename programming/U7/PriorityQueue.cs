

using System;
using System.Collections.Generic;

namespace U7
{

    public class PriorityQueue<TKey, TValue> where TKey : IComparable<TKey>
    {
        
        /// <summary>
        /// This child class just wraps two data types (key, value), such that we can
        /// use them together within a heap
        /// </summary>

        public class KeyValuePair : IComparable<KeyValuePair>
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }
            public KeyValuePair(TKey key)
            {
                Key = key;
            }
            public KeyValuePair(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }
            public int CompareTo(KeyValuePair other)
            {
                   if(other.Key.Equals(Key)){
                       return 1;
                   }
                   return 0;
            }
        }
            public List<KeyValuePair> queList;
            // do something


            // Implement here useful things with a heap
            /// <summary>
            /// Stores a value together with its priority within the queue
            /// </summary>
            public void Enqueue(TKey priority, TValue value)
            {

            }
            /// <summary>
            /// Fetches from the queue the value with the smallest priority
            /// </summary>
            /// <return>The value with the smallest priority</returns>
            public TValue Dequeue()
            {
                return null;
            }
            /// <summary>
            /// Change the priority of value. You can (and must so far) do this
            /// operation very inefficiently!
            /// </summary>
            public void DecreasePriority(TValue value, TKey newPriority)
            {

            }

        
    }

