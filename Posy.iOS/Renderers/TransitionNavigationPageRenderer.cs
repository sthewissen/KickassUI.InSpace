//using System;
//using System.ComponentModel;
//using CoreAnimation;
//using CoreGraphics;
//using Posy.iOS.Renderers;
//using UIKit;
//using Xamarin.Forms;
//using Xamarin.Forms.Platform.iOS;

//[assembly: ExportRenderer(typeof(NavigationPage), typeof(TransitionNavigationPageRenderer))]
//namespace Posy.iOS.Renderers
//{
//    public class TransitionNavigationPageRenderer : NavigationRenderer
//    {
//        public override void PushViewController(UIViewController viewController, bool animated)
//        {
//            var transition = CATransition.CreateAnimation();
//            transition.Duration = 0.5f;
//            transition.Type = CAAnimation.TransitionPush;

//            transition.Subtype = CAAnimation.TransitionFromBottom;
//            View.Layer.AddAnimation(transition, null);

//            base.PushViewController(viewController, false);
//        }

//        public override UIViewController PopViewController(bool animated)
//        {
//            var transition = CATransition.CreateAnimation();
//            transition.Duration = 0.5f;
//            transition.Type = CAAnimation.TransitionPush;

//            transition.Subtype = CAAnimation.TransitionFromTop;
//            View.Layer.AddAnimation(transition, null);

//            return base.PopViewController(false);
//        }
//    }
//}
