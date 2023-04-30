using UnityEngine;
using UnityEngine.UIElements;

namespace Punity.ui
{
    public static class QuickAccess
    {
        public static Sprite LoadSprite(string path) 
        {
            return Resources.Load<Sprite>(path);
        }
        
        public static StyleBackground LoadSpriteBg(string path)
        {
            return new StyleBackground(LoadSprite(path));
        }

        public static StyleFontDefinition LoadFont(string path)
        {
            return new StyleFontDefinition((Font) Resources.Load(path));
        }

        public static TextElement QuickText(this TextElement te, string fontPath)
        {
            return new TextElement()
            {
                style =
                {
                    unityFontDefinition = LoadFont(fontPath),
                    unityTextAlign = TextAnchor.MiddleCenter,
                    whiteSpace = WhiteSpace.Normal
                }
                
            }
            ;
        }
    }
}