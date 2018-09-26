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
    /// <summary>
    /// Internal helper extension methods for swapping bytes.
    /// </summary>
    internal static class SwapBytesExtensions
    {
        internal static int Swap(this int value)
        {
            return (int)((uint)value).Swap();
        }

        internal static long Swap(this long value)
        {
            return (long)((ulong)value).Swap();
        }

        internal static short Swap(this short value)
        {
            return (short)((ushort)value).Swap();
        }

        internal static uint Swap(this uint value)
        {
            // swap adjacent 16-bit blocks
            uint x = ((value >> 16) & 0x0000FFFFu) | ((value << 16) & 0xFFFF0000u);

            // swap adjacent 8-bit blocks
            return ((x & 0xFF00FF00) >> 8 | (x & 0x00FF00FF) << 8);
        }

        internal static ulong Swap(this ulong value)
        {
            // swap adjacent 32-bit blocks
            ulong x = (value >> 32) | (value << 32);

            // swap adjacent 16-bit blocks
            x = ((x & 0xFFFF0000FFFF0000) >> 16) | ((x & 0x0000FFFF0000FFFF) << 16);

            // swap adjacent 8-bit blocks
            return ((x & 0xFF00FF00FF00FF00) >> 8) | ((x & 0x00FF00FF00FF00FF) << 8);
        }

        internal static ushort Swap(this ushort value)
        {
            return (ushort)((ushort)(value >> 8) | (ushort)(value << 8));
        }
    }
}