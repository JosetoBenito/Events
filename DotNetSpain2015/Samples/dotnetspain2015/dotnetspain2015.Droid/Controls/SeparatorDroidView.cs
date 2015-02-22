using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
using dotnetspain2015.CustomControls;

namespace dotnetspain2015.Droid.Controls
{
    public class SeparatorDroidView : View
    {
        /// <summary>
        ///     The _orientation
        /// </summary>
        private SeparatorOrientation _orientation;

        //Density measure
        /// <summary>
        ///     The dm
        /// </summary>
        private float _dm;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SeparatorDroidView" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public SeparatorDroidView(Context context)
            : base(context)
        {
            Initialize();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SeparatorDroidView" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="attrs">The attrs.</param>
        public SeparatorDroidView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            Initialize();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SeparatorDroidView" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="attrs">The attrs.</param>
        /// <param name="defStyle">The definition style.</param>
        public SeparatorDroidView(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
            Initialize();
        }

        /// <summary>
        ///     Gets or sets the thickness.
        /// </summary>
        /// <value>The thickness.</value>
        public double Thickness { set; get; }

        /// <summary>
        ///     Gets or sets the color of the stroke.
        /// </summary>
        /// <value>The color of the stroke.</value>
        public Color StrokeColor { set; get; }

        /// <summary>
        ///     Gets or sets the type of the stroke.
        /// </summary>
        /// <value>The type of the stroke.</value>
        public StrokeType StrokeType { set; get; }

        /// <summary>
        ///     Gets or sets the orientation.
        /// </summary>
        /// <value>The orientation.</value>
        public SeparatorOrientation Orientation
        {
            set
            {
                _orientation = value;
                Invalidate();
            }
            get
            {
                return _orientation;
            }
        }

        /// <summary>
        ///     Implement this to do your drawing.
        /// </summary>
        /// <param name="canvas">the canvas on which the background will be drawn</param>
        /// <since version="Added in API level 1" />
        /// <remarks>
        ///     <para tool="javadoc-to-mdoc">Implement this to do your drawing.</para>
        ///     <para tool="javadoc-to-mdoc">
        ///         <format type="text/html">
        ///             <a href="http://developer.android.com/reference/android/view/View.html#onDraw(android.graphics.Canvas)"
        ///                 target="_blank">
        ///                 [Android Documentation]
        ///             </a>
        ///         </format>
        ///     </para>
        /// </remarks>
        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);

            var r = new Rect(0, 0, canvas.Width, canvas.Height);
            var dAdjustedThicnkess = (float)Thickness * _dm;

            var paint = new Paint { Color = StrokeColor, StrokeWidth = dAdjustedThicnkess, AntiAlias = true };
            paint.SetStyle(Paint.Style.Stroke);
            switch (StrokeType)
            {
                case StrokeType.Dashed:
                    paint.SetPathEffect(new DashPathEffect(new[] { 6 * _dm, 2 * _dm }, 0));
                    break;
                case StrokeType.Dotted:
                    paint.SetPathEffect(new DashPathEffect(new[] { dAdjustedThicnkess, dAdjustedThicnkess }, 0));
                    break;
            }

            var thicknessOffset = (dAdjustedThicnkess) / 2.0f;

            var p = new Path();
            if (Orientation == SeparatorOrientation.Horizontal)
            {
                p.MoveTo(0, thicknessOffset);
                p.LineTo(r.Width(), thicknessOffset);
            }
            else
            {
                p.MoveTo(thicknessOffset, 0);
                p.LineTo(thicknessOffset, r.Height());
            }
            canvas.DrawPath(p, paint);
        }

        /// <summary>
        ///     Initializes this instance.
        /// </summary>
        private void Initialize()
        {
            _dm = Application.Context.Resources.DisplayMetrics.Density;
        }
    }
}