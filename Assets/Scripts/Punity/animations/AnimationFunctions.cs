using System;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

namespace Punity.animations
{
    public static class AnimationFunctions
    {
        public static float EaseIn(float alpha)
        {
            
            
            return Easing.InCubic(alpha);
        }
        
        public static float EaseOut(float alpha)
        {
            return Easing.OutCubic(alpha);
        }
        
        public static float EaseInOut(float alpha)
        {
            return Easing.InOutCubic(alpha);
        }
        
        public static float SubTween(float alpha, float startAlpha = 0f, float endAlpha = 1f)
        {
            if (endAlpha<startAlpha || alpha is < 0f or > 1f)
            {
                Debug.LogWarning("SubTween called incorrectly, izel, have u fucked up?");
            }

            if (Math.Abs(endAlpha - startAlpha)<1e-6f)
            {
                return SwitchTween(alpha, endAlpha);
            }
            
            return Math.Clamp((alpha - startAlpha) / (endAlpha - startAlpha), 0f, 1f);
        }

        public static float SwitchTween(float alpha, float splitter)
        {
            return alpha < splitter ? 0f : 1f;
        }
        
        
    }
}