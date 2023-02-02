﻿using System;
using System.Collections.Generic;

namespace Punity.animations
{
    public class TweenHolder
    {
        private List<Tween> _tweenList;
        
        public TweenHolder()
        {
            _tweenList = new List<Tween>();
        }


        public void NewTween(Tween t, float delay = 0f)
        {
            if (delay > 0f)
            {
                _tweenList.Add(new Tween(delay,exitAction: () =>
                {
                    _tweenList.Add(t);
                }));
                
            }
            else
            {
                _tweenList.Add(t);
            }
        }

        public void NewTween(float sec, Action startAction = null, Action exitAction = null,
            Action<float> duringAction = null, int repeat = 1, bool callDuringWithStartFunction = false,
            float delay = 0f)
        {
            NewTween(new Tween(sec, startAction,exitAction,duringAction,repeat,callDuringWithStartFunction),delay);
        }


        public void RemoveTween(Tween t)
        {
            _tweenList.Remove(t);
        }



        public void Update(float dt)
        {
            var n = _tweenList.Count;
            var i = 0;
            
            for(var j = 0;j<n;j++)
            {
                if (_tweenList[i].Dead)
                {
                    _tweenList.RemoveAt(i);
                }
                else
                {
                    _tweenList[i].DoTheThing(dt);
                    i += 1;
                }
            }
        }
    }
}