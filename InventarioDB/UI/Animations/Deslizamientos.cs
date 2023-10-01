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
            // Crear una animación para cambiar la opacidad (fade) del elemento
            DoubleAnimation fadeAnimation = new DoubleAnimation();
            fadeAnimation.From = 0;  // Valor inicial de la opacidad (completamente transparente)
            fadeAnimation.To = 1;    // Valor final de la opacidad (completamente visible)
            fadeAnimation.Duration = TimeSpan.FromMilliseconds(600); // Duración de la animación
            fadeAnimation.BeginTime = TimeSpan.FromMilliseconds(0);  // Retraso antes de iniciar la animación

            // Crear una animación para cambiar la posición horizontal (move) del elemento
            DoubleAnimation moveAnimation = new DoubleAnimation();
            moveAnimation.From = -400;  // Valor inicial de la posición horizontal
            moveAnimation.To = 0;       // Valor final de la posición horizontal
            moveAnimation.Duration = TimeSpan.FromMilliseconds(600); // Duración de la animación
            moveAnimation.BeginTime = TimeSpan.FromMilliseconds(0);  // Retraso antes de iniciar la animación

            // Crear una transformación de traducción para cambiar la posición horizontal del elemento
            TranslateTransform moveTransform = new TranslateTransform();
            targetElement.RenderTransform = moveTransform; // Aplicar la transformación al elemento de destino

            // Crear un storyboard para agrupar ambas animaciones
            Storyboard sb = new Storyboard();
            sb.Children.Add(fadeAnimation);   // Agregar la animación de opacidad al storyboard
            sb.Children.Add(moveAnimation);   // Agregar la animación de posición al storyboard

            // Configurar los objetivos y propiedades de las animaciones
            Storyboard.SetTarget(fadeAnimation, targetElement);  // Establecer el elemento de destino para la animación de opacidad
            Storyboard.SetTarget(moveAnimation, targetElement);  // Establecer el elemento de destino para la animación de posición
            Storyboard.SetTargetProperty(fadeAnimation, new PropertyPath("(UIElement.Opacity)"));  // Propiedad objetivo: Opacidad
            Storyboard.SetTargetProperty(moveAnimation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)")); // Propiedad objetivo: Posición horizontal

            // Devolver el storyboard creado
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
