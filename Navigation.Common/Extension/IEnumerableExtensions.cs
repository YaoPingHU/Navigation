using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;



namespace Hubert.Utility.Lite.Extension
{
    public static class IEnumerableExtensions
    {

        #region Distinct

        /// <summary>
        /// data3.Distinct(p => p.Name, StringComparer.CurrentCultureIgnoreCase).ToArray();
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="V"></typeparam>
        public class CommonEqualityComparer<T, V> : IEqualityComparer<T>
        {
            private readonly Func<T, V> _keySelector;
            private readonly IEqualityComparer<V> _comparer;

            public CommonEqualityComparer(Func<T, V> keySelector, IEqualityComparer<V> comparer)
            {
                this._keySelector = keySelector;
                this._comparer = comparer;
            }

            public CommonEqualityComparer(Func<T, V> keySelector)
                : this(keySelector, EqualityComparer<V>.Default)
            { }

            public bool Equals(T x, T y)
            {
                return _comparer.Equals(_keySelector(x), _keySelector(y));
            }

            public int GetHashCode(T obj)
            {
                return _comparer.GetHashCode(_keySelector(obj));
            }
        }

        #endregion

        #region Replace


        /// <summary>
        /// Replaces the specified sequence.
        /// int[] values = new int[] { 1, 2, 3, 4, 5, 4, 3, 2, 1 };
        /// int[] replaced = values.Replace(3, 0).ToArray();
        /// 
        /// string[] strings = new string[] { "A", "B", "C", "D", "a", "b", "c", "d" };
        /// string[] replacedCI = strings.Replace("b", "-", StringComparer.InvariantCultureIgnoreCase).ToArray();
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence">The sequence.</param>
        /// <param name="find">The find.</param>
        /// <param name="replaceWith">The replace with.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns>Collection of type T</returns>
        public static IEnumerable<T> Replace<T>(this IEnumerable<T> sequence, T find, T replaceWith, IEqualityComparer<T> comparer)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");
            if (comparer == null) throw new ArgumentNullException("comparer");

            return ReplaceImpl(sequence, find, replaceWith, comparer);
        }

        /// <summary>
        /// Replaces the specified sequence.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence">The sequence.</param>
        /// <param name="find">The find.</param>
        /// <param name="replaceWith">The replace with.</param>
        /// <returns>Collection of type T</returns>
        public static IEnumerable<T> Replace<T>(this IEnumerable<T> sequence, T find, T replaceWith)
        {
            return Replace(sequence, find, replaceWith, EqualityComparer<T>.Default);
        }

        /// <summary>
        /// Replaces the impl.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence">The sequence.</param>
        /// <param name="find">The find.</param>
        /// <param name="replaceWith">The replace with parameter</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns>Collection of type T</returns>
        private static IEnumerable<T> ReplaceImpl<T>(IEnumerable<T> sequence, T find, T replaceWith, IEqualityComparer<T> comparer)
        {
            foreach (T item in sequence)
            {
                bool match = comparer.Equals(find, item);
                T x = match ? replaceWith : item;
                yield return x;
            }
        }


        #endregion

        #region IEnumerableExtension

        /// <summary>
        /// IEnumerableExtension
        /// http://www.cnblogs.com/wintersun/archive/2009/11/06/1597542.html
        /// </summary>

        #region IsEmpty

        public static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || !source.Any();
        }

        #endregion

        #region IsNotEmpty

        public static bool IsNotEmpty<T>(this IEnumerable<T> source)
        {
            return source != null &&  source.Any();
        }

        #endregion

        #region Switch

        /// <summary>
        /// string englishName = "apple";
        ///    string chineseName = englishName.Switch(
        ///        new string[] { "apple", "orange", "banana", "pear" },
        ///        new string[] { "苹果", "桔子", "香蕉", "梨" },
        ///        "未知"
        ///     );
        ///     Console.WriteLine(chineseName);
        /// </summary>
        /// <typeparam name="TOutput"></typeparam>
        /// <typeparam name="TInput"></typeparam>
        /// <param name="input"></param>
        /// <param name="inputSource"></param>
        /// <param name="outputSource"></param>
        /// <param name="defaultOutput"></param>
        /// <returns></returns>
        public static TOutput Switch<TOutput, TInput>(this TInput input, IEnumerable<TInput> inputSource, IEnumerable<TOutput> outputSource, TOutput defaultOutput)
        {
            IEnumerator<TInput> inputIterator = inputSource.GetEnumerator();
            IEnumerator<TOutput> outputIterator = outputSource.GetEnumerator();

            TOutput result = defaultOutput;
            while (inputIterator.MoveNext())
            {
                if (outputIterator.MoveNext())
                {
                    if (input.Equals(inputIterator.Current))
                    {
                        result = outputIterator.Current;
                        break;
                    }
                }
                else break;
            }
            return result;
        }

        #endregion

        #region Alternate 交替 间隔

        /// <summary>
        ///  Alternates the specified first.
        ///  string sentence = "the quick brown fox jumps over the lazy dog";
        ///  string[] words = sentence.Split(' ');
        ///  string reversed = words.Aggregate((workingSentence, next) => next + " " + workingSentence);
        ///  Assert.AreEqual("dog lazy the over jumps fox brown quick the",reversed);
        ///  
        ///  int[] aa = new int[] { 1, 3, 5};
        ///  int[] bb = new int[] { 2, 4, 6 };
        ///  var cc = aa.Alternate(bb);
        ///  new[] { 1, 2, 3, 4, 5, 6}
        ///  
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns></returns>
        public static IEnumerable<TSource> Alternate<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            using (IEnumerator<TSource> e1 = first.GetEnumerator())
            using (IEnumerator<TSource> e2 = second.GetEnumerator())
                while (e1.MoveNext() && e2.MoveNext())
                {
                    yield return e1.Current;
                    yield return e2.Current;
                }
        }

        #endregion

        #region Append

        /// <summary>
        /// Appends the specified source.
        ///  var ints = new[] { 1, 2, 3 };
        ///  var oneToFour = ints.Append(4);
        ///  new[] { 1, 2, 3, 4 }
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="element">The element.</param>
        /// <returns>IEnumerable<TSource></returns>
        public static IEnumerable<TSource> Append<TSource>(this IEnumerable<TSource> source, TSource element)
        {
            using (IEnumerator<TSource> e1 = source.GetEnumerator())
                while (e1.MoveNext())
                    yield return e1.Current;

            yield return element;
        }

        #endregion

        #region Prepend

        /// <summary>
        /// Prepends the specified source.
        /// var ints = new[] { 1, 2, 3 };
        /// var zeroToThree = ints.Prepend(0);
        /// new[] { 0, 1, 2, 3 }
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="element">The element.</param>
        /// <returns>IEnumerable<TSource></returns>
        public static IEnumerable<TSource> Prepend<TSource>(this IEnumerable<TSource> source, TSource element)
        {
            yield return element;

            using (IEnumerator<TSource> e1 = source.GetEnumerator())
                while (e1.MoveNext())
                    yield return e1.Current;
        }

        #endregion

        #region Contains

        /// <summary>
        /// Determines whether [contains] [the specified source].
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="value">The value.</param>
        /// <param name="selector">The selector.</param>
        /// <returns>
        ///     <c>true</c> if [contains] [the specified source]; otherwise, <c>false</c>.
        /// </returns>
        public static bool Contains<TSource, TResult>(this IEnumerable<TSource> source, TResult value, Func<TSource, TResult> selector)
        {
            foreach (TSource sourceItem in source)
            {
                TResult sourceValue = selector(sourceItem);
                if (sourceValue.Equals(value))
                    return true;
            }
            return false;
        }

        #endregion

        #region Distinct

        /// <summary>
        /// Distincts the specified source.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns>IEnumerable<TSource></returns>
        public static IEnumerable<TSource> Distinct<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> comparer)
        {
            return source.Distinct(new DynamicComparer<TSource, TResult>(comparer));
        }

        #endregion

        #region DynamicComparer

        /// <summary>
        /// DynamicComparer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        public class DynamicComparer<T, TResult> : IEqualityComparer<T>
        {
            #region Fields (1)

            private readonly Func<T, TResult> _selector;

            #endregion Fields

            #region Constructors (1)

            /// <summary>
            /// Initializes a new instance of the <see cref="DynamicComparer&lt;T, TResult&gt;"/> class.
            /// </summary>
            /// <param name="selector">The selector.</param>
            public DynamicComparer(Func<T, TResult> selector)
            {
                _selector = selector;
            }

            #endregion Constructors

            #region Methods (2)

            // Public Methods (2) 

            /// <summary>
            /// Determines whether the specified objects are equal.
            /// </summary>
            /// <param name="x">The first object of type <paramref name="T"/> to compare.</param>
            /// <param name="y">The second object of type <paramref name="T"/> to compare.</param>
            /// <returns>
            /// true if the specified objects are equal; otherwise, false.
            /// </returns>
            public bool Equals(T x, T y)
            {
                TResult result1 = _selector(x);
                TResult result2 = _selector(y);
                return result1.Equals(result2);
            }

            /// <summary>
            /// Returns a hash code for the specified object.
            /// </summary>
            /// <param name="obj">The <see cref="T:System.Object"/> for which a hash code is to be returned.</param>
            /// <returns>A hash code for the specified object.</returns>
            /// <exception cref="T:System.ArgumentNullException">
            /// The type of <paramref name="obj"/> is a reference type and <paramref name="obj"/> is null.
            /// </exception>
            public int GetHashCode(T obj)
            {
                TResult result = _selector(obj);
                return result.GetHashCode();
            }

            #endregion Methods
        }

        #endregion

        #region 查询方法的扩展
        /// <summary>      
        /// Select方法的补充      
        /// rpy.SelectEx(item =>new TNew(){})等同rpy.Select(item => new TNew(){f1 = item.f1, f2 = item.f2 ,...})    
        /// rpy.SelectEx(item =>new TNew(){f1 = "something"})等同rpy.Select(item => new TNew(){ f1 ="something", f2 = item.f2 ,...})
        /// 其它选择方法和原始Select方法一致
        /// </summary>        
        /// <typeparam name="T">源实体类型</typeparam>
        /// <typeparam name="TNew">新的实体类型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="selector">新对象实例</param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns></returns>
        public static IQueryable<TNew> SelectEx<T, TNew>(this IQueryable<T> source, Expression<Func<T, TNew>> selector) where T : class
        {
            if (selector == null)
            {
                throw new ArgumentNullException();
            }

            var body = selector.Body as MemberInitExpression;
            if (body != null)
            {
                var targetType = typeof(TNew);
                var targetProperties = targetType.GetProperties().ToList();
                var sourceProperties = typeof(T).GetProperties();

                var parameter = selector.Parameters[0];
                var bindedMembers = body.Bindings.Select(b => b.Member).ToList();
                var needBindProroties = targetProperties.Where(p => bindedMembers.Exists(m => m.Name.Equals(p.Name)) == false);

                var allBindings = body.Bindings.ToList();
                foreach (var property in needBindProroties)
                {
                    var sourceProperty = sourceProperties.FirstOrDefault(item => item.Name.Equals(property.Name));
                    if (sourceProperty != null)
                    {
                        var memberExp = Expression.MakeMemberAccess(parameter, sourceProperty);
                        var binding = Expression.Bind(property, memberExp);
                        allBindings.Add(binding);
                    }
                }

                var targetNew = Expression.New(targetType);
                var bodyNew = Expression.MemberInit(targetNew, allBindings);
                selector = (Expression<Func<T, TNew>>)Expression.Lambda(bodyNew, parameter);
            }

            return source.Select(selector);
        }
        #endregion

        #region JoinString

        public static string JoinString(this IEnumerable<string> values)
        {
            return JoinString(values, ",");
        }

        public static string JoinString(this IEnumerable<string> values, string split)
        {
            var result = values.Aggregate(string.Empty, (current, value) => current + (split + value));
            result = result.TrimStart(split.ToCharArray());
            return result;
        }

        public static string IntJoinString(this IEnumerable<int> values)
        {
            return IntJoinString(values, ",");
        }

        public static string IntJoinString(this IEnumerable<int> values, string split)
        {
            var result = values.Aggregate(string.Empty, (current, value) => current + (split + value));
            result = result.TrimStart(split.ToCharArray());
            return result;
        }

        public static string LongJoinString(this IEnumerable<long> values, string split)
        {
            var result = values.Aggregate(string.Empty, (current, value) => current + (split + value));
            result = result.TrimStart(split.ToCharArray());
            return result;
        }

        #endregion

        #endregion

    }
}
