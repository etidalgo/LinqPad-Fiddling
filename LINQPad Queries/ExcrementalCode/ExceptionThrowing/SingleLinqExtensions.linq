<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Namespace>System.Globalization</Namespace>
</Query>

	
	public static class SingleLinqExtensions
    {
        static TSource SingleHandler<TSource>(Func<TSource> single, string elementType)
        {
            try
            {
                return single();
            }
            catch (InvalidOperationException exception)
            {
                switch (exception.Message)
                {
                    case "Sequence contains no elements":
                    case "Sequence contains no matching element":
                        throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "The collection was empty (item = {0})", elementType), exception);
                    case "Sequence contains more than one element":
                    case "Sequence contains more than one matching element":
                        throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "The collection contained more than one matching item (item = {0})", elementType), exception);
                    default:
                        throw;
                }
            }
        }

        public static TSource Single<TSource>(this IEnumerable<TSource> source, string elementType)
        {
            return SingleHandler(source.Single, elementType);
        }

        public static TSource Single<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, string elementType)
        {
            return SingleHandler(() => source.Single(predicate), elementType);
        }

        public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source, string elementType)
        {
            return SingleHandler(source.SingleOrDefault, elementType);
        }

        public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, string elementType)
        {
            return SingleHandler(() => source.SingleOrDefault(predicate), elementType);
        }
    }
	
var itsAllGreek = new List<string> {"alpha", "beta", "alpha"};
itsAllGreek.Single(gr => gr == "alpha", "barbaric");