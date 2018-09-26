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
    internal static class BitConverterEndian
    {
        #region GetBytes

        internal static unsafe byte[] GetBytesBE(short value)
        {
            return GetBytesBE((ushort)value);
        }

        internal static unsafe byte[] GetBytesBE(int value)
        {
            return GetBytesBE((uint)value);
        }

        internal static unsafe byte[] GetBytesBE(long value)
        {
            return GetBytesBE((ulong)value);
        }

        internal static unsafe byte[] GetBytesBE(ushort value)
        {
            byte[] bytes = new byte[2];
            fixed (byte* pbyte = bytes)
            {
                *(pbyte + 0) = (byte)(value >> 8);
                *(pbyte + 1) = (byte)(value >> 0);
            }

            return bytes;
        }

        internal static unsafe byte[] GetBytesBE(uint value)
        {
            byte[] bytes = new byte[4];
            fixed (byte* pbyte = bytes)
            {
                *(pbyte + 0) = (byte)(value >> 24);
                *(pbyte + 1) = (byte)(value >> 16);
                *(pbyte + 2) = (byte)(value >> 8);
                *(pbyte + 3) = (byte)(value >> 0);
            }

            return bytes;
        }

        internal static unsafe byte[] GetBytesBE(ulong value)
        {
            byte[] bytes = new byte[8];
            fixed (byte* pbyte = bytes)
            {
                *(pbyte + 0) = (byte)(value >> 56);
                *(pbyte + 1) = (byte)(value >> 48);
                *(pbyte + 2) = (byte)(value >> 40);
                *(pbyte + 3) = (byte)(value >> 32);
                *(pbyte + 4) = (byte)(value >> 24);
                *(pbyte + 5) = (byte)(value >> 16);
                *(pbyte + 6) = (byte)(value >> 8);
                *(pbyte + 7) = (byte)(value >> 0);
            }

            return bytes;
        }

        public static unsafe byte[] GetBytesLE(short value)
        {
            byte[] bytes = new byte[2];
            fixed (byte* pbyte = bytes)
            {
                *(pbyte + 0) = (byte)(value >> 0);
                *(pbyte + 1) = (byte)(value >> 8);
            }

            return bytes;
        }

        public static unsafe byte[] GetBytesLE(int value)
        {
            byte[] bytes = new byte[4];
            fixed (byte* pbyte = bytes)
            {
                *(pbyte + 0) = (byte)(value >> 0);
                *(pbyte + 1) = (byte)(value >> 8);
                *(pbyte + 2) = (byte)(value >> 16);
                *(pbyte + 3) = (byte)(value >> 24);
            }

            return bytes;
        }

        public static unsafe byte[] GetBytesLE(long value)
        {
            byte[] bytes = new byte[8];
            fixed (byte* pbyte = bytes)
            {
                *(pbyte + 0) = (byte)(value >> 0);
                *(pbyte + 1) = (byte)(value >> 8);
                *(pbyte + 2) = (byte)(value >> 16);
                *(pbyte + 3) = (byte)(value >> 24);
                *(pbyte + 4) = (byte)(value >> 32);
                *(pbyte + 5) = (byte)(value >> 40);
                *(pbyte + 6) = (byte)(value >> 48);
                *(pbyte + 7) = (byte)(value >> 56);
            }

            return bytes;
        }

        public static unsafe byte[] GetBytesLE(ushort value)
        {
            byte[] bytes = new byte[2];
            fixed (byte* pbyte = bytes)
            {
                *(pbyte + 0) = (byte)(value >> 0);
                *(pbyte + 1) = (byte)(value >> 8);
            }

            return bytes;
        }

        public static unsafe byte[] GetBytesLE(uint value)
        {
            byte[] bytes = new byte[4];
            fixed (byte* pbyte = bytes)
            {
                *(pbyte + 0) = (byte)(value >> 0);
                *(pbyte + 1) = (byte)(value >> 8);
                *(pbyte + 2) = (byte)(value >> 16);
                *(pbyte + 3) = (byte)(value >> 24);
            }

            return bytes;
        }

        public static unsafe byte[] GetBytesLE(ulong value)
        {
            byte[] bytes = new byte[8];
            fixed (byte* pbyte = bytes)
            {
                *(pbyte + 0) = (byte)(value >> 0);
                *(pbyte + 1) = (byte)(value >> 8);
                *(pbyte + 2) = (byte)(value >> 16);
                *(pbyte + 3) = (byte)(value >> 24);
                *(pbyte + 4) = (byte)(value >> 32);
                *(pbyte + 5) = (byte)(value >> 40);
                *(pbyte + 6) = (byte)(value >> 48);
                *(pbyte + 7) = (byte)(value >> 56);
            }

            return bytes;
        }

        #endregion GetBytes

        #region SetBytes

        public static unsafe void SetBytesBE(short value, byte[] array, int startIndex)
        {
            SetBytesBE((ushort)value, array, startIndex);
        }

        public static unsafe void SetBytesBE(int value, byte[] array, int startIndex)
        {
            SetBytesBE((uint)value, array, startIndex);
        }

        public static unsafe void SetBytesBE(long value, byte[] array, int startIndex)
        {
            SetBytesBE((ulong)value, array, startIndex);
        }

        public static unsafe void SetBytesBE(ushort value, byte[] array, int startIndex)
        {
            fixed (byte* pbyte = &array[startIndex])
            {
                *(pbyte + 0) = (byte)(value >> 8);
                *(pbyte + 1) = (byte)(value >> 0);
            }
        }

        public static unsafe void SetBytesBE(uint value, byte[] array, int startIndex)
        {
            fixed (byte* pbyte = &array[startIndex])
            {
                *(pbyte + 0) = (byte)(value >> 24);
                *(pbyte + 1) = (byte)(value >> 16);
                *(pbyte + 2) = (byte)(value >> 08);
                *(pbyte + 3) = (byte)(value >> 00);
            }
        }

        public static unsafe void SetBytesBE(ulong value, byte[] array, int startIndex)
        {
            fixed (byte* pbyte = &array[startIndex])
            {
                *(pbyte + 0) = (byte)(value >> 56);
                *(pbyte + 1) = (byte)(value >> 48);
                *(pbyte + 2) = (byte)(value >> 40);
                *(pbyte + 3) = (byte)(value >> 32);
                *(pbyte + 4) = (byte)(value >> 24);
                *(pbyte + 5) = (byte)(value >> 16);
                *(pbyte + 6) = (byte)(value >> 08);
                *(pbyte + 7) = (byte)(value >> 00);
            }
        }

        public static unsafe void SetBytesLE(short value, byte[] array, int startIndex)
        {
            SetBytesLE((ushort)value, array, startIndex);
        }

        public static unsafe void SetBytesLE(int value, byte[] array, int startIndex)
        {
            SetBytesLE((uint)value, array, startIndex);
        }

        public static unsafe void SetBytesLE(long value, byte[] array, int startIndex)
        {
            SetBytesLE((ulong)value, array, startIndex);
        }

        public static unsafe void SetBytesLE(ushort value, byte[] array, int startIndex)
        {
            fixed (byte* pbyte = &array[startIndex])
            {
                *(pbyte + 0) = (byte)(value >> 0);
                *(pbyte + 1) = (byte)(value >> 8);
            }
        }

        public static unsafe void SetBytesLE(uint value, byte[] array, int startIndex)
        {
            fixed (byte* pbyte = &array[startIndex])
            {
                *(pbyte + 0) = (byte)(value >> 0);
                *(pbyte + 1) = (byte)(value >> 8);
                *(pbyte + 2) = (byte)(value >> 16);
                *(pbyte + 3) = (byte)(value >> 24);
            }
        }

        public static unsafe void SetBytesLE(ulong value, byte[] array, int startIndex)
        {
            fixed (byte* pbyte = &array[startIndex])
            {
                *(pbyte + 0) = (byte)(value >> 0);
                *(pbyte + 1) = (byte)(value >> 8);
                *(pbyte + 2) = (byte)(value >> 16);
                *(pbyte + 3) = (byte)(value >> 24);
                *(pbyte + 4) = (byte)(value >> 32);
                *(pbyte + 5) = (byte)(value >> 40);
                *(pbyte + 6) = (byte)(value >> 48);
                *(pbyte + 7) = (byte)(value >> 56);
            }
        }

        #endregion SetBytes

        #region To Number

        public static unsafe short ToInt16BE(byte[] value, int startIndex)
        {
            return (short)ToUInt16BE(value, startIndex);
        }

        public static unsafe int ToInt32BE(byte[] value, int startIndex)
        {
            return (int)ToUInt32BE(value, startIndex);
        }

        public static unsafe long ToInt64BE(byte[] value, int startIndex)
        {
            return (long)ToUInt64BE(value, startIndex);
        }

        public static unsafe ushort ToUInt16BE(byte[] value, int startIndex)
        {
            fixed (byte* pbyte = &value[startIndex])
            {
                return (ushort)
                    (
                    (*(pbyte + 0) << 8) |
                    (*(pbyte + 1) << 0)
                    );
            }
        }

        public static unsafe uint ToUInt32BE(byte[] value, int startIndex)
        {
            fixed (byte* pbyte = &value[startIndex])
            {
                return (uint)
                    (
                    (*(pbyte + 0) << 24) |
                    (*(pbyte + 1) << 16) |
                    (*(pbyte + 2) << 08) |
                    (*(pbyte + 3) << 00)
                    );
            }
        }

        public static unsafe ulong ToUInt64BE(byte[] value, int startIndex)
        {
            fixed (byte* pbyte = &value[startIndex])
            {
                int one =
                    (*(pbyte + 0) << 24) |
                    (*(pbyte + 1) << 16) |
                    (*(pbyte + 2) << 08) |
                    (*(pbyte + 3) << 00);
                int two =
                    (*(pbyte + 4) << 24) |
                    (*(pbyte + 5) << 16) |
                    (*(pbyte + 6) << 08) |
                    (*(pbyte + 7) << 00);

                return (uint)two | ((ulong)one << 32);
            }
        }

        public static unsafe short ToInt16LE(byte[] value, int startIndex)
        {
            return (short)ToUInt16LE(value, startIndex);
        }

        public static unsafe int ToInt32LE(byte[] value, int startIndex)
        {
            return (int)ToUInt32LE(value, startIndex);
        }

        public static unsafe long ToInt64LE(byte[] value, int startIndex)
        {
            return (long)ToUInt64LE(value, startIndex);
        }

        public static unsafe ushort ToUInt16LE(byte[] value, int startIndex)
        {
            fixed (byte* pbyte = &value[startIndex])
            {
                return (ushort)
                    (
                    (*(pbyte + 0) << 0) |
                    (*(pbyte + 1) << 8)
                    );
            }
        }

        public static unsafe uint ToUInt32LE(byte[] value, int startIndex)
        {
            fixed (byte* pbyte = &value[startIndex])
            {
                return (uint)
                    (
                    (*(pbyte + 0) << 00) |
                    (*(pbyte + 1) << 08) |
                    (*(pbyte + 2) << 16) |
                    (*(pbyte + 3) << 24)
                    );
            }
        }

        public static unsafe ulong ToUInt64LE(byte[] value, int startIndex)
        {
            fixed (byte* pbyte = &value[startIndex])
            {
                int one =
                    (*(pbyte + 0) << 00) |
                    (*(pbyte + 1) << 08) |
                    (*(pbyte + 2) << 16) |
                    (*(pbyte + 3) << 24);
                int two =
                    (*(pbyte + 4) << 00) |
                    (*(pbyte + 5) << 08) |
                    (*(pbyte + 6) << 16) |
                    (*(pbyte + 7) << 24);

                return (uint)one | ((ulong)two << 32);
            }
        }

        #endregion To Number
    }
}
