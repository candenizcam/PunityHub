using UnityEngine.UIElements;

namespace Punity.ui
{
    public class ImageButton : GenericButton
    {
        private StyleBackground _upImage;
        private StyleBackground _downImage;
        private StyleBackground _disableImage;
        
        public ImageButton(string upPath, string downPath = null, string disablePath = null)
        {
            _upImage = QuickAccess.LoadSpriteBg(upPath);
            _downImage = QuickAccess.LoadSpriteBg(downPath ?? upPath);
            _disableImage = QuickAccess.LoadSpriteBg(disablePath ?? upPath);

            style.backgroundImage = _upImage;


        }
        
        
        protected override void TouchLeaveFunction()
        {
            style.backgroundImage = _upImage;
        }

        protected override void TouchDownFunction()
        {
            style.backgroundImage = _upImage;
        }
        protected override void ClickFunction() { }

        protected override void TouchUpFunction()
        {
            style.backgroundImage = _downImage;
        }

        protected override void DisableFunction(bool b)
        {
            style.backgroundImage = b ? _disableImage : _upImage;
        }
    }
}