using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;

namespace Punity
{
    /** A collection for unbounded fields
     * heh, heh, heh
     */
    [Serializable]
    public class Pasture<T> 
    {
        private List<(string key, T value)> _innerList = new();


        public void ApplyTo(string key, Func<T,T> lambda)
        {
            for (var i = 0; i < _innerList.Count; i++)
            {
                if (_innerList[i].key == key)
                {
                    _innerList[i] = (key, lambda(_innerList[i].value));
                    return;
                }
            }
            throw new Exception($"No member in pasture with key {key}");
        }
        
        public TNew LetTo<TNew>(string key, Func<T,TNew> lambda)
        {
            for (var i = 0; i < _innerList.Count; i++)
            {
                if (_innerList[i].key == key)
                {
                    return lambda(_innerList[i].value);
                }
            }
            throw new Exception($"No member in pasture with key {key}");
        }

        public void Apply( Func<T, T> lambda)
        {
            for (var i = 0; i < _innerList.Count; i++)
            {
                this[_innerList[i].key] = lambda(_innerList[i].value);
            }
        }
        
        
        public Pasture<TNew> Select<TNew>(Func<T,TNew> lambda)
        {
            var n = new Pasture<TNew>();
            for (var i = 0; i < _innerList.Count; i++)
            {
                n[_innerList[i].key] = lambda(_innerList[i].value);
            }
            return n;
        }
        
        public Pasture<TNew> Select<TNew>(Func<string,T,TNew> lambda)
        {
            var n = new Pasture<TNew>();
            for (var i = 0; i < _innerList.Count; i++)
            {
                n[_innerList[i].key] = lambda(_innerList[i].key,_innerList[i].value);
            }
            return n;
        }
        

        public T Get(string key)
        {
            for (var i = 0; i < _innerList.Count; i++)
            {
                if (_innerList[i].key == key)
                {
                    return _innerList[i].value;
                }
            }

            throw new Exception($"No member in pasture with key {key}");
        }

        public T this[string key]
        {
            get => Get(key);
            set => Set(key, value);
        }

        public void Set(string key, T value)
        {
            for (var i = 0; i < _innerList.Count; i++)
            {
                if (_innerList[i].key == key)
                {
                    _innerList[i] = (key,value);
                    return;
                }
            }
            _innerList.Add((key,value));
        }
        
    }
}