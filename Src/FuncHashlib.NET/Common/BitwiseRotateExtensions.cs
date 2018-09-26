#region Copyright

/*
 * Copyright (C) 2018 Larry Lopez
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to
 * deal in the Software without restriction, including without limitation the
 * rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
 * sell copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
 * IN THE SOFTWARE.
 */

#endregion Copyright

namespace FuncHashlib.NET.Common
{
    internal static class BitwiseRotateExtensions
    {
        #region Rotate Left

        internal static byte Rol(this byte value, int count)
        {
            return (byte)((byte)(value << count) | (byte)(value >> (8 - count)));
        }

        internal static ushort Rol(this ushort value, int count)
        {
            return (ushort)((ushort)(value << count) | (ushort)(value >> (16 - count)));
        }

        internal static uint Rol(this uint value, int count)
        {
            return (value << count) | (value >> (32 - count));
        }

        internal static ulong Rol(this ulong value, int count)
        {
            return (value << count) | (value >> (64 - count));
        }

        #endregion Rotate Left

        #region Rotate Right

        internal static byte Ror(this byte value, int count)
        {
            return (byte)((byte)(value >> count) | (byte)(value << (8 - count)));
        }

        internal static ushort Ror(this ushort value, int count)
        {
            return (ushort)((ushort)(value >> count) | (ushort)(value << (16 - count)));
        }

        internal static uint Ror(this uint value, int count)
        {
            return (value >> count) | (value << (32 - count));
        }

        internal static ulong Ror(this ulong value, int count)
        {
            return (value >> count) | (value << (64 - count));
        }

        #endregion Rotate Right
    }
}
