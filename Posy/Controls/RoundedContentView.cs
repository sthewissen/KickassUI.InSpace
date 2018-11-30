using System;
using Xamarin.Forms;

namespace Posy.Controls
{
    public class RoundedContentView : ContentView
    {
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(float), typeof(RoundedContentView), default(float));
        public static readonly BindableProperty BorderThicknessProperty = BindableProperty.Create(nameof(BorderThickness), typeof(int), typeof(RoundedContentView), default(int));
        public static readonly BindableProperty BorderIsDashedProperty = BindableProperty.Create(nameof(BorderIsDashed), typeof(bool), typeof(RoundedContentView), default(bool));
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(RoundedContentView), default(Color));
        public static readonly BindableProperty HasBackgroundGradientProperty = BindableProperty.Create(nameof(HasBackgroundGradient), typeof(bool), typeof(RoundedContentView), defaultValue: default(bool));
        public static readonly BindableProperty GradientStartColorProperty = BindableProperty.Create(nameof(GradientStartColor), typeof(Color), typeof(RoundedContentView), defaultValue: default(Color));
        public static readonly BindableProperty GradientEndColorProperty = BindableProperty.Create(nameof(GradientEndColor), typeof(Color), typeof(RoundedContentView), defaultValue: default(Color));

        public bool HasBackgroundGradient
        {
            get { return (bool)GetValue(HasBackgroundGradientProperty); }
            set { SetValue(HasBackgroundGradientProperty, value); }
        }

        public Color GradientStartColor
        {
            get { return (Color)GetValue(GradientStartColorProperty); }
            set { SetValue(GradientStartColorProperty, value); }
        }

        public Color GradientEndColor
        {
            get { return (Color)GetValue(GradientEndColorProperty); }
            set { SetValue(GradientEndColorProperty, value); }
        }

        public float CornerRadius
        {
            get { return (float)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public int BorderThickness
        {
            get { return (int)GetValue(BorderThicknessProperty); }
            set { SetValue(BorderThicknessProperty, value); }
        }

        public bool BorderIsDashed
        {
            get { return (bool)GetValue(BorderIsDashedProperty); }
            set { SetValue(BorderIsDashedProperty, value); }
        }

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }
    }
}
