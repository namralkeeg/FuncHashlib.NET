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

using System;
using System.Collections;
using System.Collections.Generic;

namespace FuncHashlib.NET.Common
{
    /// <summary>
    /// Delimits a section of a one-dimensional array.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array slice.</typeparam>
    [Serializable]
    public struct ArraySlice<T> : IList<T>, IReadOnlyList<T>, IEquatable<ArraySlice<T>>
    {
        private const string _ArgumentNonZeroMessage = "Agrument is out of range. It must not be negative.";
        private const string _ArrayIsNullMessage = "The array is null.";
        private T[] _array;
        private int _offset;
        private int _count;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArraySlice{T}"/> structure that delimits all
        /// the elements in the specified array.
        /// </summary>
        /// <param name="array">The array to wrap.</param>
        /// <exception cref="ArgumentNullException">The array is null.</exception>
        public ArraySlice(T[] array) : this(array, 0, array.Length)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArraySlice{T}"/> structure that delimits all
        /// the elements in the specified array.
        /// </summary>
        /// <param name="array">The array containing the range of elements to delimit.</param>
        /// <param name="offset">The zero-based index of the first element in the range.</param>
        /// <param name="count">The number of elements in the range.</param>
        /// <exception cref="ArgumentException">The offset or count is less than 0.</exception>
        /// <exception cref="ArgumentNullException">The <see cref="Array"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The offset and count do not specify a valid range in array.</exception>
        public ArraySlice(T[] array, int offset, int count)
        {
            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(offset), _ArgumentNonZeroMessage);
            }
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), _ArgumentNonZeroMessage);
            }
            if (array.Length - offset < count)
            {
                throw new ArgumentException("");
            }

            _array = array ?? throw new ArgumentNullException(nameof(array));
            _offset = offset;
            _count = count;
        }

        /// <summary>
        /// Gets the original array containing the range of elements that the array segment delimits.
        /// </summary>
        /// <value>
        /// The original array that was passed to the constructor, and that contains the range
        /// delimited by the <see cref="ArraySlice{T}"/>.
        /// </value>
        public T[] Array => _array;

        /// <summary>
        /// Gets the number of elements in the range delimited by the array slice.
        /// </summary>
        /// <value>
        /// The number of elements in the range delimited by the <see cref="ArraySlice{T}"/>.
        /// </value>
        public int Count => _count;

        /// <summary>
        /// Gets the position of the first element in the range delimited by the array slice,
        /// relative to the start of the original array.
        /// </summary>
        /// <value>
        /// The position of the first element in the range delimited by the <see cref="ArraySlice{T}"/>,
        /// relative to the start of the original array.
        /// </value>
        public int Offset => _offset;

        /// <summary>
        /// Gets a value that indicates whether the array segment is read-only.
        /// </summary>
        /// <remarks>
        /// The indexer setter does not throw an exception although IsReadOnly is true.
        /// This is to match the behavior of arrays.
        /// </remarks>
        public bool IsReadOnly => true;

        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                if (_array == null)
                {
                    throw new InvalidOperationException(_ArrayIsNullMessage);
                }

                if ((uint)index >= _count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                return _array[_offset + index];
            }

            set
            {
                if (_array == null)
                {
                    throw new InvalidOperationException(_ArrayIsNullMessage);
                }

                if ((uint)index >= _count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                _array[_offset + index] = value;
            }
        }

        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        T IReadOnlyList<T>.this[int index]
        {
            get
            {
                if (_array == null)
                {
                    throw new InvalidOperationException(_ArrayIsNullMessage);
                }

                if ((uint)index >= _count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                return _array[_offset + index];
            }
        }

        #region IEquatable<T>

        public override bool Equals(object obj)
        {
            if (obj is ArraySlice<T>)
            {
                return Equals((ArraySlice<T>)obj);
            }
            else
            {
                return false;
            }
        }

        public bool Equals(ArraySlice<T> other)
        {
            return
                other._array == _array &&
                other._offset == _offset &&
                other._count == _count;
        }

        public static bool operator ==(ArraySlice<T> a, ArraySlice<T> b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(ArraySlice<T> a, ArraySlice<T> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (_array == null) ?
                0 :
                _array.GetHashCode() ^ _offset ^ _count;
        }

        #endregion IEquatable<T>

        #region IEnumerable<T>

        public IEnumerator<T> GetEnumerator()
        {
            if (_array == null)
            {
                throw new InvalidOperationException(_ArrayIsNullMessage);
            }

            return new ArraySliceEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion IEnumerable<T>

        #region IList<T>

        T IList<T>.this[int index]
        {
            get
            {
                if (_array == null)
                {
                    throw new InvalidOperationException(_ArrayIsNullMessage);
                }

                if ((uint)index >= _count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                return _array[_offset + index];
            }

            set
            {
                if (_array == null)
                {
                    throw new InvalidOperationException(_ArrayIsNullMessage);
                }

                if ((uint)index >= _count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                _array[_offset + index] = value;
            }
        }

        public int IndexOf(T item)
        {
            int index = System.Array.IndexOf(_array, item, _offset, _count);
            index -= _offset;

            return (index >= 0) ? index : -1;
        }

        public void Insert(int index, T item)
        {
            throw new NotSupportedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        public void Add(T item)
        {
            throw new NotSupportedException();
        }

        public void Clear()
        {
            if (_array == null)
            {
                throw new InvalidOperationException(_ArrayIsNullMessage);
            }

            System.Array.Clear(_array, _offset, _count);
        }

        public bool Contains(T item)
        {
            return IndexOf(item) >= 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            System.Array.Copy(_array, _offset, array, arrayIndex, _count);
        }

        public bool Remove(T item)
        {
            throw new NotSupportedException();
        }

        #endregion IList<T>

        [Serializable]
        internal sealed class ArraySliceEnumerator : IEnumerator<T>
        {
            private readonly T[] _array;
            private readonly int _start;
            private readonly int _end;
            private int _current;

            internal ArraySliceEnumerator(ArraySlice<T> arraySlice)
            {
                _array = arraySlice._array;
                _start = arraySlice._offset;
                _end = _start + arraySlice._count;
                _current = _start - 1;
            }

            public T Current
            {
                get
                {
                    if (_current < _start)
                    {
                        throw new InvalidOperationException("Enumerator has not started.");
                    }

                    if (_current >= _end)
                    {
                        throw new InvalidOperationException("Enumerator has finished.");
                    }

                    return _array[_current];
                }
            }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (_current < _end)
                {
                    _current++;
                    return (_current < _end);
                }

                return false;
            }

            public void Reset()
            {
                _current = _start - 1;
            }
        }
    }
}