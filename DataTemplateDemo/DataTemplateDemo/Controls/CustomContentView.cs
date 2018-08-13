using System;
using Xamarin.Forms;

namespace DataTemplateDemo.Controls
{
    public class CustomContentView : ContentView
    {
        public event EventHandler SwipeDown;
        public event EventHandler SwipeUp;
        public event EventHandler SwipeLeft;
        public event EventHandler SwipeRight;

        public void OnSwipeDown()
        {
            var handler = SwipeDown;
            if (handler != null)
                SwipeDown(this, null);
        }

        public void OnSwipeUp()
        {
            var handler = SwipeUp;
            if (handler != null)
                SwipeUp(this, null);
        }

        public void OnSwipeLeft()
        {
            var handler = SwipeLeft;
            if (handler != null)
                SwipeLeft(this, null);
        }

        public void OnSwipeRight()
        {
            var handler = SwipeRight;
            if (handler != null)
                SwipeRight(this, null);
        }
    }
}