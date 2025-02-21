using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace InventarioDB.UI.Animations
{
    public class Vibracion
    {
        public static void StartVibrationAnimation(UIElement element)
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = -5;
            animation.To = 5;
            animation.Duration = TimeSpan.FromMilliseconds(50);
            animation.AutoReverse = true; 
            animation.RepeatBehavior = new RepeatBehavior(3);

            TranslateTransform transform = new TranslateTransform();
            element.RenderTransform = transform;

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation);
            Storyboard.SetTarget(animation, element);
            Storyboard.SetTargetProperty(animation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)"));

            storyboard.Begin();
        }

    }
}
