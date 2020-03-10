<Query Kind="Program" />

void Main()
{
	var uri = (Uri)null;
	
	uri.EnsureEndsWithTrailingSlash();
}

public static class Extensions {

    public static string EnsureEndsWithTrailingSlash(this string url)
    {
        url = url?.Trim();
        return url?.EndsWith("/") == false ? $"{url}/" : url;
    }
	
    public static Uri EnsureEndsWithTrailingSlash(this Uri uri)
    {
        var uriAsString = uri?.ToString();
        var ensuredAsString = uriAsString.EnsureEndsWithTrailingSlash();
        var ensured =
            ensuredAsString == uriAsString ? uri :
            ensuredAsString == null ? null :
            new Uri(ensuredAsString, uri.IsAbsoluteUri ? UriKind.Absolute : UriKind.Relative);
        return ensured;
    }
}