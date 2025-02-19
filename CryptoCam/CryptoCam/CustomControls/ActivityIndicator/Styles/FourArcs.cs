﻿using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace CryptoCam.CustomControls.ActivityIndicator
{
    class FourArcs : ArcsBase
    {
     
        public FourArcs() : base()
        {

            ovalStartAngle = 90; //outer arc start angle
            secondOvalStartAngle = 270; //outer arc start angle
            ovalSweepAngle = 80; //outer arcg sweep angle from the start angle position
           

            innerOvalStartAngle = 90; //inner arc start angle
            innerSecondOvalStartAngle = 270; //inner arc start angle
            innerOvalSweepAngle = 80; //inner arcg sweep angle from the start angle position

            /// outer arc paint style
            /// defined the style as stroke
            /// color of the stroke using hsl format * you can change the color code here*
            /// width of the outer arc
            firstArcPaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,

                Color = SKColor.FromHsl(40, 100, 50),
                StrokeWidth = 25,
                IsAntialias = true,
                StrokeCap = SKStrokeCap.Round

            };

            /// inner arc paint style
            /// defined the style as stroke
            /// color of the stroke using hsl format * you can change the color code here*
            /// width of the inner arc
            secondArcPaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,

                Color = SKColor.FromHsl(21, 100, 50),
                StrokeWidth = 25,
                IsAntialias = true,
                StrokeCap = SKStrokeCap.Round

            };


            canvas = new SKCanvasView();
            canvas.BackgroundColor = Color.Black;
            canvas.PaintSurface += OnCanvasViewPaintSurface;
            Content = canvas;
            Device.StartTimer(TimeSpan.FromMilliseconds(30), OnTimerClik);
        }

        public override bool OnTimerClik()
        {
            ovalStartAngle += 2;
            secondOvalStartAngle += 2;
            innerOvalStartAngle += 8;
            innerSecondOvalStartAngle += 8;
            canvas.InvalidateSurface();
            return true;
        }


        public override void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            /*
             * 500 is the diameter of the outer arc
             * each inner arc from the outer arc will get reduced by 50
             *you can change the value according to make the arc smaller or bigger
             * */

            float left, right;
            float top, bottom;
            right = left = (info.Width - 500) / 2; //get the left and right postions to support all the devices
            top = bottom = (info.Height - 500) / 2;//get the top and bottom postions to support all the devices

            //first Arc
            SKRect rect = new SKRect(left, top, info.Width - right, info.Height - bottom);
            SKRect InnerRect = new SKRect(left + 100, top + 100, (info.Width - right) - 100, (info.Height - bottom) - 100);
            //canvas.DrawCircle(info.Width / 2, info.Height / 2, 250, firstArcPaint);
            using (SKPath path = new SKPath())
            {
                path.AddArc(rect, ovalStartAngle, ovalSweepAngle);
                canvas.DrawPath(path, firstArcPaint);
            }

            using (SKPath path = new SKPath())
            {
                path.AddArc(rect, secondOvalStartAngle, ovalSweepAngle);
                canvas.DrawPath(path, firstArcPaint);
            }

            using (SKPath path = new SKPath())
            {
                path.AddArc(InnerRect, innerOvalStartAngle, innerOvalSweepAngle);
                canvas.DrawPath(path, secondArcPaint);
            }

            using (SKPath path = new SKPath())
            {
                path.AddArc(InnerRect, innerSecondOvalStartAngle, innerOvalSweepAngle);
                canvas.DrawPath(path, secondArcPaint);
            }
            
            base.OnCanvasViewPaintSurface(sender,args);
        }
    }
}
