using System;
using Android.Views;
using DataTemplateDemo.Controls;
using DataTemplateDemo.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Xamarin.Forms.View;

[assembly: ExportRenderer(typeof(CustomContentView), typeof(GestureContentViewRenderer))]

namespace DataTemplateDemo.Droid.Renderers
{
    public class GestureContentViewRenderer : ViewRenderer
    {
        private readonly GestureDetector _detector;
        private readonly DroidGestureListener _listener;

        public GestureContentViewRenderer()
        {
            _listener = new DroidGestureListener();
            _detector = new GestureDetector(_listener);
        }


        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
            {
                GenericMotion -= HandleGenericMotion;
                Touch -= HandleTouch;
                _listener.OnSwipeLeft -= HandleOnSwipeLeft;
                _listener.OnSwipeRight -= HandleOnSwipeRight;
                _listener.OnSwipeUp -= HandleOnSwipeTop;
                _listener.OnSwipeDown -= HandleOnSwipeDown;
            }

            if (e.OldElement == null)
            {
                GenericMotion += HandleGenericMotion;
                Touch += HandleTouch;
                _listener.OnSwipeLeft += HandleOnSwipeLeft;
                _listener.OnSwipeRight += HandleOnSwipeRight;
                _listener.OnSwipeUp += HandleOnSwipeTop;
                _listener.OnSwipeDown += HandleOnSwipeDown;
            }
        }

        private void HandleTouch(object sender, TouchEventArgs e)
        {
            _detector.OnTouchEvent(e.Event);
        }

        private void HandleGenericMotion(object sender, GenericMotionEventArgs e)
        {
            _detector.OnTouchEvent(e.Event);
        }

        private void HandleOnSwipeLeft(object sender, EventArgs e)
        {
            var _gi = (CustomContentView) Element;
            _gi.OnSwipeLeft();
        }

        private void HandleOnSwipeRight(object sender, EventArgs e)
        {
            var _gi = (CustomContentView) Element;
            _gi.OnSwipeRight();
        }

        private void HandleOnSwipeTop(object sender, EventArgs e)
        {
            var _gi = (CustomContentView) Element;
            _gi.OnSwipeUp();
        }

        private void HandleOnSwipeDown(object sender, EventArgs e)
        {
            var _gi = (CustomContentView) Element;
            _gi.OnSwipeDown();
        }
    }

    public class DroidGestureListener : GestureDetector.SimpleOnGestureListener
    {
        private static readonly int SWIPE_THRESHOLD = 100;
        private static readonly int SWIPE_VELOCITY_THRESHOLD = 100;

        public event EventHandler OnSwipeDown;
        public event EventHandler OnSwipeUp;
        public event EventHandler OnSwipeLeft;
        public event EventHandler OnSwipeRight;

        public override bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
        {
            var diffY = e2.GetY() - e1.GetY();
            var diffX = e2.GetX() - e1.GetX();

            if (Math.Abs(diffX) > Math.Abs(diffY))
            {
                if (Math.Abs(diffX) > SWIPE_THRESHOLD && Math.Abs(velocityX) > SWIPE_VELOCITY_THRESHOLD)
                {
                    if (diffX > 0)
                    {
                        if (OnSwipeRight != null)
                            OnSwipeRight(this, null);
                    }
                    else
                    {
                        if (OnSwipeLeft != null)
                            OnSwipeLeft(this, null);
                    }
                }
            }
            else if (Math.Abs(diffY) > SWIPE_THRESHOLD && Math.Abs(velocityY) > SWIPE_VELOCITY_THRESHOLD)
            {
                if (diffY > 0)
                {
                    if (OnSwipeDown != null)
                        OnSwipeDown(this, null);
                }
                else
                {
                    if (OnSwipeUp != null)
                        OnSwipeUp(this, null);
                }
            }

            return true;
        }
    }
}