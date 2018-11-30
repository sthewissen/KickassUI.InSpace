using System;
using System.ComponentModel;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Util;
using Android.Views;
using Posy.Controls;
using Posy.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(RoundedContentView), typeof(RoundedContentViewRenderer))]
namespace Posy.Droid.Renderers
{
	public class RoundedContentViewRenderer : VisualElementRenderer<ContentView>
	{
		private float _cornerRadius;
		private int _borderThickness;
		private Xamarin.Forms.Color _borderColor;
		private Xamarin.Forms.Color _backgroundColor;
		private bool _borderIsDashed;

		private bool _hasBackgroundGradient;
		private Xamarin.Forms.Color _startColor;
		private Xamarin.Forms.Color _endColor;

		public RoundedContentViewRenderer(Android.Content.Context context) : base(context) { }

		protected override void OnElementChanged(ElementChangedEventArgs<ContentView> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null)
				return;

			var element = (RoundedContentView)Element;


			_borderThickness = element.BorderThickness * 4;
			_borderColor = element.BorderColor;
			_backgroundColor = element.BackgroundColor;
			_borderIsDashed = element.BorderIsDashed;

			_startColor = element.GradientStartColor;
			_endColor = element.GradientEndColor;
			_hasBackgroundGradient = element.HasBackgroundGradient;

			_cornerRadius = TypedValue.ApplyDimension(ComplexUnitType.Dip, element.CornerRadius, Context.Resources.DisplayMetrics);
			this.OutlineProvider = new RoundedCornerOutlineProvider(_cornerRadius, _borderThickness);
			this.ClipToOutline = true;
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			var element = (RoundedContentView)Element;

			if (e.PropertyName == RoundedContentView.BorderColorProperty.PropertyName || e.PropertyName == RoundedContentView.BorderIsDashedProperty.PropertyName)
			{
				_borderColor = (this.Element as RoundedContentView).BorderColor;
				_borderIsDashed = (this.Element as RoundedContentView).BorderIsDashed;
				this.Invalidate();
			}
		}

		public override void Draw(Canvas canvas)
		{
			RectF bounds = new RectF(0, 0, Width, Height);

			if(_hasBackgroundGradient)
			{
				var fillPaint = new Paint(PaintFlags.AntiAlias);
				var shader = new LinearGradient(0, this.Height, this.Width, 0, _startColor.ToAndroid(), _endColor.ToAndroid(), Shader.TileMode.Clamp);
				fillPaint.SetShader(shader);
				canvas.DrawRect(bounds, fillPaint);
			}

			base.Draw(canvas);

			if (_borderThickness > 0)
			{
				var strokePaint = new Paint(PaintFlags.AntiAlias);
				strokePaint.SetStyle(Paint.Style.Stroke);
				strokePaint.StrokeWidth = _borderThickness;
				strokePaint.StrokeCap = Paint.Cap.Round;
				strokePaint.Color = _borderColor.ToAndroid();

				if(_borderIsDashed)
					strokePaint.SetPathEffect(new DashPathEffect(new float[] {10,20 }, 0));

				if (_cornerRadius > 0)
				{
					canvas.DrawRoundRect(bounds, _cornerRadius, _cornerRadius, strokePaint);
				}
				else
				{
					canvas.DrawRect(bounds, strokePaint);
				}
			}
		}
	}

	public class RoundedCornerOutlineProvider : ViewOutlineProvider
	{
		private readonly float roundCorner;
		private readonly int _border;

		public RoundedCornerOutlineProvider(float round, int border)
		{
			roundCorner = round;
			_border = border;
		}

		public override void GetOutline(Android.Views.View view, Outline outline)
		{
			outline.SetRoundRect(-1 * _border, -1 * _border, view.Width + _border, view.Height + _border, roundCorner + (_border * 2));
		}
	}
}
