using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorFramework
{
    public static class RectExtension
    {
        public enum AnchorType
        {
            UpperLeft=0,
            UpperCenter=1,
            UpperRight=2,
            MiddleLeft = 3,
            MiddleCenter = 4,
            MiddleRight =5,
            LowerLeft = 6,
            LowerCenter = 7,
            LowerRight = 8,
        }

        public enum SplitType
        {
            Vertical,
            Horizontal,
        }

        public static Rect Zoom(this Rect rect, AnchorType anchorType, float pixelOffset)
        {
            var tempW = rect.width + pixelOffset;
            var tempH = rect.height + pixelOffset;

            switch (anchorType)
            {
                case AnchorType.UpperLeft:
                    break;
                case AnchorType.UpperCenter:
                    rect.x -= (tempW - rect.width) / 2;
                    break;
                case AnchorType.UpperRight:
                    rect.x -= tempW - rect.width;
                    break;
                case AnchorType.MiddleLeft:
                    rect.x -= (tempH - rect.height) / 2;
                    break;
                case AnchorType.MiddleCenter:
                    rect.x -= (tempW - rect.width)/2;
                    rect.y -= (tempH - rect.height) / 2;
                    break;
                case AnchorType.MiddleRight:
                    rect.x -= (tempW - rect.width) / 2;
                    rect.y -= tempH - rect.height;
                    break;
                case AnchorType.LowerLeft:
                    rect.y -= tempH - rect.height;
                    break;
                case AnchorType.LowerCenter:
                    rect.x -= (tempW - rect.width) / 2;
                    rect.y -= tempH - rect.height;
                    break;
                case AnchorType.LowerRight:
                    rect.x -= tempW - rect.width;
                    rect.y -= tempH - rect.height;
                    break;
            }
            rect.width = tempW;
            rect.height = tempH;
            return rect;
        }

        public static Rect[] Split(this Rect self,SplitType splitType, float size, float padding = 0, bool justMid = true)
        {
            if(splitType == SplitType.Vertical)
            {
                return self.VerticalSplit(size, padding, justMid);
            }
            else
            {
                return self.HorizontalSplit(size, padding, justMid);
            }
        }

        public static Rect[] VerticalSplit(this Rect self, float width, float padding =0,bool justMid =true)
        {
            if (justMid)
            {
                return new Rect[2]
                {
                    self.CutRight(self.width-width).CutRight(padding).CutRight(-Mathf.CeilToInt(padding/2)),
                    self.CutLeft(width).CutLeft(padding).CutLeft(-Mathf.CeilToInt(padding/2)),
                };
            }
            return new Rect[2]
            {
                new Rect(0,0,0,0),
                new Rect(0,0,0,0),
            };
        }

        public static Rect[] HorizontalSplit(this Rect self, float height, float padding = 0, bool justMid = true)
        {
            if (justMid)
            {
                return new Rect[2]
                {
                    self.CutBottom(self.height-height).CutBottom(padding).CutBottom(-Mathf.CeilToInt(padding/2)),
                    self.CutTop(height).CutTop(padding).CutTop(-Mathf.CeilToInt(padding/2)),
                };
            }
            return new Rect[2]
            {
                new Rect(0,0,0,0),
                new Rect(0,0,0,0),
            };
        }

        public static Rect SplitRect(this Rect self,SplitType splitType, float size, float padding = 0)
        {
            if(splitType == SplitType.Vertical)
            {
                return self.VerticalSplitRect(size, padding);
            }
            else
            {
                return self.HorizontalSplitRect(size, padding);
            }
        }

        public static Rect VerticalSplitRect(this Rect self, float width,float padding = 0)
        {
           var rect = self.CutRight(self.width - width).CutRight(padding).CutRight(-Mathf.CeilToInt(padding / 2));
            rect.x += rect.width                ;
            rect.width = padding;
            return rect;
        }

        public static Rect HorizontalSplitRect(this Rect self, float height, float padding = 0)
        {
            var rect = self.CutBottom(self.height - height).CutBottom(padding).CutBottom(-Mathf.CeilToInt(padding / 2));
            rect.y += rect.height;
            rect.height = padding;
            return rect;
        }

        public static Rect CutRight(this Rect self,float pixels)
        {
            self.xMax -= pixels;
            return self;
        }
        public static Rect CutLeft(this Rect self, float pixels)
        {
            self.xMin += pixels;
            return self;
        }
        public static Rect CutTop(this Rect self, float pixels)
        {
            self.yMin += pixels;
            return self;
        }
        public static Rect CutBottom(this Rect self, float pixels)
        {
            self.yMax -= pixels;
            return self;
        }

        public static Rect Set(this Rect self, Vector2 position,Vector2 size)
        {
            self.Set(position, size);
            return self;
        }
    }
}