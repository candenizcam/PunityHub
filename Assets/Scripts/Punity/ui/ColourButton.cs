using UnityEngine;

namespace Punity.ui
{
    public class ColourButton : GenericButton
    {
        private Color _upColour;
        private Color _downColour;
        private Color _disableColour;
        
        public ColourButton(Color upColour, Color? downColour = null, Color? disableColour = null)
        {
            _upColour = upColour;
            _downColour = downColour ?? upColour;
            _disableColour = disableColour ?? upColour;
            
            style.backgroundColor = _upColour;
        }

        protected override void TouchLeaveFunction()
        {
            style.backgroundColor = _upColour;
        }

        protected override void TouchDownFunction()
        {
            style.backgroundColor = _downColour;
        }
        protected override void ClickFunction() { }

        protected override void TouchUpFunction()
        {
            style.backgroundColor = _upColour;
        }

        protected override void DisableFunction(bool b)
        {
            style.backgroundColor = b ? _disableColour : _upColour;
        }
    }
}