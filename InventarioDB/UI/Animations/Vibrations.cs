using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace InventarioDB.UI.Animations
{
    public class Vibrations
    {
        public static void StartVibrationAnimation(UIElement element)
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = -5; // Valor inicial de la vibración (izquierda)
            animation.To = 5;    // Valor final de la vibración (derecha)
            animation.Duration = TimeSpan.FromMilliseconds(50); // Duración de la vibración
            animation.AutoReverse = true; // La animación se revierte automáticamente
            animation.RepeatBehavior = new RepeatBehavior(3); // Número de repeticiones de la vibración

            TranslateTransform transform = new TranslateTransform();
            element.RenderTransform = transform;

            // Crear el storyboard para la animación
            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation);
            Storyboard.SetTarget(animation, element);
            Storyboard.SetTargetProperty(animation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)"));

            storyboard.Begin();
        }

    }
}
