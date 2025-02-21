using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace InventarioDB.UI.Animations
{
    public class DeslizamientoIzquierdaDerecha
    {
        public static Storyboard CreateFadeAndMoveAnimation(UIElement targetElement)
        {
            DoubleAnimation fadeAnimation = new DoubleAnimation();
            fadeAnimation.From = 0;
            fadeAnimation.To = 1;
            fadeAnimation.Duration = TimeSpan.FromMilliseconds(600);
            fadeAnimation.BeginTime = TimeSpan.FromMilliseconds(0);

            DoubleAnimation moveAnimation = new DoubleAnimation();
            moveAnimation.From = -400;
            moveAnimation.To = 0;
            moveAnimation.Duration = TimeSpan.FromMilliseconds(600);
            moveAnimation.BeginTime = TimeSpan.FromMilliseconds(0);

            TranslateTransform moveTransform = new TranslateTransform();
            targetElement.RenderTransform = moveTransform;

            Storyboard sb = new Storyboard();
            sb.Children.Add(fadeAnimation);
            sb.Children.Add(moveAnimation);

            Storyboard.SetTarget(fadeAnimation, targetElement);
            Storyboard.SetTarget(moveAnimation, targetElement);
            Storyboard.SetTargetProperty(fadeAnimation, new PropertyPath("(UIElement.Opacity)"));
            Storyboard.SetTargetProperty(moveAnimation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)"));

            return sb;
        }

    }

    public class DeslizamientoDerechaIzquierda
    {
        public static Storyboard CreateFadeAndMoveAnimation(UIElement targetElement)
        {
            DoubleAnimation fadeAnimation = new DoubleAnimation();
            fadeAnimation.From = 0;
            fadeAnimation.To = 1;
            fadeAnimation.Duration = TimeSpan.FromMilliseconds(600);
            fadeAnimation.BeginTime = TimeSpan.FromMilliseconds(0);

            DoubleAnimation moveAnimation = new DoubleAnimation();
            moveAnimation.From = 400;
            moveAnimation.To = 0;
            moveAnimation.Duration = TimeSpan.FromMilliseconds(600);
            moveAnimation.BeginTime = TimeSpan.FromMilliseconds(0);

            TranslateTransform moveTransform = new TranslateTransform();
            targetElement.RenderTransform = moveTransform;

            Storyboard sb = new Storyboard();
            sb.Children.Add(fadeAnimation);
            sb.Children.Add(moveAnimation);
            Storyboard.SetTarget(fadeAnimation, targetElement);
            Storyboard.SetTarget(moveAnimation, targetElement);
            Storyboard.SetTargetProperty(fadeAnimation, new PropertyPath("(UIElement.Opacity)"));
            Storyboard.SetTargetProperty(moveAnimation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)"));

            return sb;
        }
    }

    public class Deslizamientoabajo
    {
        public static Storyboard CreateFadeAndMoveAnimation(UIElement targetElement)
        {
            DoubleAnimation fadeAnimation = new DoubleAnimation();
            fadeAnimation.From = 0;
            fadeAnimation.To = 1;
            fadeAnimation.Duration = TimeSpan.FromMilliseconds(600);
            fadeAnimation.BeginTime = TimeSpan.FromMilliseconds(0);

            DoubleAnimation moveAnimation = new DoubleAnimation();
            moveAnimation.From = 400;
            moveAnimation.To = 0;
            moveAnimation.Duration = TimeSpan.FromMilliseconds(600);
            moveAnimation.BeginTime = TimeSpan.FromMilliseconds(0);

            TranslateTransform moveTransform = new TranslateTransform();
            targetElement.RenderTransform = moveTransform;

            Storyboard sb = new Storyboard();
            sb.Children.Add(fadeAnimation);
            sb.Children.Add(moveAnimation);
            Storyboard.SetTarget(fadeAnimation, targetElement);
            Storyboard.SetTarget(moveAnimation, targetElement);
            Storyboard.SetTargetProperty(fadeAnimation, new PropertyPath("(UIElement.Opacity)"));
            Storyboard.SetTargetProperty(moveAnimation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.Y)"));

            return sb;
        }
    }
}
