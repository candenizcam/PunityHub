using System;
using UnityEngine.UIElements;

namespace Punity.ui
{
    public class GenericButton : VisualElement
    {
        public Action ClickAction = () => {};
        public Action TouchDownAction= () => {};
        public Action TouchUpAction= () => {};
        public Action TouchLeaveAction= () => {};

        protected bool Disabled;

        public GenericButton()
        {
            RegisterCallback<MouseLeaveEvent>(TouchLeave);
            RegisterCallback<MouseDownEvent>(TouchDown);
            RegisterCallback<MouseUpEvent>(TouchUp);
            RegisterCallback<ClickEvent>(Click);
        }


        protected virtual void TouchLeaveFunction() { }
        protected virtual void TouchDownFunction() { }
        protected virtual void ClickFunction() { }
        protected virtual void TouchUpFunction() { }

        protected virtual void DisableFunction(bool b) { }

        public void Disable(bool b)
        {
            DisableFunction(b);
            Disabled = b;
        }
        
        
        private void TouchLeave(MouseLeaveEvent evt)
        {
            if (!Disabled)
            {
                TouchLeaveFunction();
                TouchLeaveAction();
            }
        }
        
        private void TouchDown(MouseDownEvent evt)
        {
            if (!Disabled)
            {
                TouchDownFunction();
                TouchDownAction();
            }
        }
        
        
        private void TouchUp(MouseUpEvent evt)
        {
            if (!Disabled)
            {
                TouchUpFunction();
                TouchUpAction();
            }
        }

        
        
        private void Click(ClickEvent e)
        {
            if (!Disabled)
            {
                ClickFunction();
                ClickAction();
            }
        }
    }
}