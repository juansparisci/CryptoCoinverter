﻿using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCam.CustomControls.ActivityIndicator
{
    public  class LoadingText
    {
        private string text;
        private ILoadingTextPosition ltPosition;
        SKPaint textPaint;

        public string Text { get => text; set => text = value; }
        public ILoadingTextPosition LtPosition { get => ltPosition; set => ltPosition = value; }
        public SKPaint TextPaint { get => textPaint; set => textPaint = value; }

        public LoadingText(string text, ILoadingTextPosition position, SKColor color, int textSize)
        {
            //Set text style
            this.textPaint = new SKPaint { Color = color, TextSize = textSize };

            //Set text
            this.text = text;

            //Set position
            this.ltPosition = position;

        }
    }
}
