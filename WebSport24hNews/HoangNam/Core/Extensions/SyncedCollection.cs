using System.Collections;

namespace WebSport24hNews.HoangNam.Core.Extensions
{
        public sealed class SyncedCollection<T> : ICollection<T>, IEnumerable<T>, IEnumerable
        {
            private readonly ICollection<T> _col;

            public object SyncRoot { get; }

            public bool ReadLockFree { get; set; }

            public T this[int index]
            {
                get
                {
                    if (ReadLockFree)
                    {
                        return _col.ElementAt(index);
                    }

                    lock (SyncRoot)
                    {
                        return _col.ElementAt(index);
                    }
                }
            }

            public int Count
            {
                get
                {
                    if (ReadLockFree)
                    {
                        return _col.Count();
                    }

                    lock (SyncRoot)
                    {
                        return _col.Count();
                    }
                }
            }

            public bool IsReadOnly => _col.IsReadOnly;

            public SyncedCollection(ICollection<T> wrappedCollection)
                 : this(wrappedCollection, new object())
            {
            }

            public SyncedCollection(ICollection<T> wrappedCollection, object syncRoot)
            {
                _col = wrappedCollection;
                SyncRoot = syncRoot;
            }

            public void AddRange(IEnumerable<T> collection)
            {
                lock (SyncRoot)
                {
                    _col.AddRange(collection);
                }
            }

            public void Insert(int index, T item)
            {
                if (_col is List<T> list)
                {
                    lock (SyncRoot)
                    {
                        list.Insert(index, item);
                    }
                }

                throw new NotSupportedException();
            }

            public void InsertRange(int index, IEnumerable<T> values)
            {
                if (_col is List<T> list)
                {
                    lock (SyncRoot)
                    {
                        list.InsertRange(index, values);
                    }
                }

                throw new NotSupportedException();
            }

            public int RemoveRange(IEnumerable<T> values)
            {
                int num = 0;
                lock (SyncRoot)
                {
                    foreach (T value in values)
                    {
                        if (_col.Remove(value))
                        {
                            num++;
                        }
                    }
                }

                return num;
            }

            public void RemoveRange(int index, int count)
            {
                if (_col is List<T> list)
                {
                    lock (SyncRoot)
                    {
                        list.RemoveRange(index, count);
                    }
                }

                throw new NotSupportedException();
            }

            public void RemoveAt(int index)
            {
                lock (SyncRoot)
                {
                    if (_col is List<T> list)
                    {
                        list.RemoveAt(index);
                        return;
                    }

                    T val = _col.ElementAtOrDefault(index);
                    if (val != null)
                    {
                        _col.Remove(val);
                    }
                }
            }

            public void Add(T item)
            {
                lock (SyncRoot)
                {
                    _col.Add(item);
                }
            }

            public void Clear()
            {
                lock (SyncRoot)
                {
                    _col.Clear();
                }
            }

            public bool Contains(T item)
            {
                if (ReadLockFree)
                {
                    return _col.Contains(item);
                }

                lock (SyncRoot)
                {
                    return _col.Contains(item);
                }
            }

            public void CopyTo(T[] array, int arrayIndex)
            {
                lock (SyncRoot)
                {
                    _col.CopyTo(array, arrayIndex);
                }
            }

            public bool Remove(T item)
            {
                lock (SyncRoot)
                {
                    return _col.Remove(item);
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public IEnumerator<T> GetEnumerator()
            {
                if (ReadLockFree)
                {
                    return _col.GetEnumerator();
                }

                lock (SyncRoot)
                {
                    return _col.GetEnumerator();
                }
            }
        }
    } 

