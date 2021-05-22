using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpriteFontPlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Water.Graphics.Controls
{
    public class TextBlock : GameObject
    {

        public TextWrapMode TextWrapping;
        public TextAlignment TextAlignment;
        public const string LineSeparator = "|n";

        private DynamicSpriteFont font;
        private Color color;
        private string text;

        public TextBlock(Rectangle relativePosition, DynamicSpriteFont font, string text, Color color)
        {
            RelativePosition = relativePosition;
            this.color = color;
            this.font = font;
            this.text = text;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            var finalText = TextWrapping switch // TODO: don't calculate this EVERY frame
            {
                TextWrapMode.LetterWrap => LetterWrap(font, text, ActualPosition.Width),
                TextWrapMode.WordWrap => WordWrap(font, text, ActualPosition.Width),
                TextWrapMode.None or _ => text
            };
            var pos = new Vector2(ActualPosition.X, ActualPosition.Y);

            var lines = finalText.Split(LineSeparator);
            foreach (var line in lines)
            {
                if (TextAlignment != TextAlignment.Left)
                {
                    pos.X = ActualPosition.X;
                    var m = font.MeasureString(line.Trim());
                    if (TextAlignment == TextAlignment.Right)
                        pos.X += ActualPosition.Right - m.X;
                    else if (TextAlignment == TextAlignment.Center)
                        pos.X += (ActualPosition.Width - m.X) / 2;
                }
                spriteBatch.DrawString(font, line, pos, color);
                   
                pos.Y += 20;
            }
        }

        public override void Initialize()
        {
       
        }

        public override void Update(GameTime gameTime)
        {
          
        }

        // code taken from https://github.com/redteam-os/thundershock/blob/master/src/Thundershock/Gui/Elements/TextBlock.cs
        private string LetterWrap(DynamicSpriteFont font, string text, float wrapWidth)
        {
            if (wrapWidth <= 0)
                return text;

            var lineWidth = 0f;
            var sb = new StringBuilder();

            foreach (var ch in text)
            {
                var m = font.MeasureString(ch.ToString()).X;
                if (lineWidth + m > wrapWidth)
                {
                    sb.Append(LineSeparator);
                    lineWidth = 0;
                }

                lineWidth += m;
                sb.Append(ch);
            }

            return sb.ToString();
        }

        private string WordWrap(DynamicSpriteFont font, string text, float wrapWidth)
        {
            if (wrapWidth <= 0)
                return text;

            // first step: break words.
            var words = new List<string>();
            var w = "";
            for (var i = 0; i <= text.Length; i++)
            {
                if (i < text.Length)
                {
                    var ch = text[i];
                    w += ch;
                    if (char.IsWhiteSpace(ch))
                    {
                        words.Add(w);
                        w = "";
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(w))
                    {
                        words.Add(w);
                    }
                }
            }

            // step 2: Line-wrap.
            var sb = new StringBuilder();
            var lineWidth = 0f;
            for (var i = 0; i < words.Count; i++)
            {
                var word = words[i];
                var m = font.MeasureString(word).X;
                var m2 = font.MeasureString(word.Trim()).X;

                if (lineWidth + m2 > wrapWidth && lineWidth > 0) // this makes the whole thing a lot less greedy
                {
                    sb.Append(LineSeparator);
                    lineWidth = 0;
                }

                if (m > lineWidth)
                {
                    var letterWrapped = LetterWrap(font, word, wrapWidth);
                    var lines = letterWrapped.Split(LineSeparator);
                    var last = lines.Last();

                    m = font.MeasureString(last).X;
                    word = last;

                    sb.Append(letterWrapped);
                }
                else
                {
                    sb.Append(word);
                }

                if (word.EndsWith(LineSeparator))
                    lineWidth = 0;
                else
                    lineWidth += m;
            }

            return sb.ToString();
        }
    }

    public enum TextWrapMode
    {
        None,
        LetterWrap,
        WordWrap
    }
    public enum TextAlignment
    {
        Left,
        Center,
        Right
    }
}
