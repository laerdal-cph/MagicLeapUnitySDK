// %BANNER_BEGIN%
// ---------------------------------------------------------------------
// %COPYRIGHT_BEGIN%
// <copyright file="MLMediaTTML.cs" company="Magic Leap, Inc">
//
// Copyright (c) 2018-present, Magic Leap, Inc. All Rights Reserved.
//
// </copyright>
// %COPYRIGHT_END%
// ---------------------------------------------------------------------
// %BANNER_END%

using System.Runtime.InteropServices;

#if UNITY_MAGICLEAP || UNITY_ANDROID

namespace UnityEngine.XR.MagicLeap
{
    using System;
    using UnityEngine.XR.MagicLeap.Native;

    /// <summary>
    /// MLMediaTTML Summary placeholder.
    /// </summary>
    public partial class MLMediaTTML 
    {
        private MLMediaTTML.MLTTMLData TTMLDataToPublic(NativeBindings.MLTTMLData internalData)
        {
            return new MLMediaTTML.MLTTMLData()
            {
                StartTimeMs = internalData.StartTimeMs,
                EndTimeMs = internalData.EndTimeMs,
                Text = internalData.Text,
                TextAlignment = internalData.TextAlignment,
                Bitmap = TTMLImageToPublic(internalData.Bitmap),
                Line = internalData.Line,
                LineType = internalData.LineType,
                LineAnchor = internalData.LineAnchor,
                Position = internalData.Position,
                PositionAnchor = internalData.PositionAnchor,
                Size = internalData.Size,
                BitmapHeight = internalData.BitmapHeight,
                WindowColorSet = internalData.WindowColorSet,
                WindowColor = internalData.WindowColor,
                TextSizeType = internalData.TextSizeType,
                TextSize = internalData.TextSize,
            };
        }
        
        private MLMediaTTML.MLTTMLImage TTMLImageToPublic(NativeBindings.MLTTMLImage internalImage)
        {
            byte[] outBuffer = new byte[internalImage.Size];
            Marshal.Copy(internalImage.Data, outBuffer, 0, (int)internalImage.Size);
            
            return MLMediaTTML.MLTTMLImage.Create(outBuffer, (uint)internalImage.Size);
        }
        
        private NativeBindings.MLTTMLImage TTMLImageToNative(MLMediaTTML.MLTTMLImage internalImage)
        {
            var buffer = internalImage.Data;
            IntPtr unmanagedPointer = Marshal.AllocHGlobal(buffer.Length);
            Marshal.Copy(buffer, 0, unmanagedPointer, buffer.Length);
            
            return NativeBindings.MLTTMLImage.Create(unmanagedPointer, (uint)buffer.Length);
        }
    }
}

#endif