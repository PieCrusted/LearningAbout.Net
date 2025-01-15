using System.Text.RegularExpressions;

namespace Assignment2;

public class URLParser {
    public static void ParseUrl(string url) {
        if (string.IsNullOrWhiteSpace(url)) {
            Console.WriteLine("Invalid URL: Input URL cannot be null or empty");
            return;
        }

        string protocol = null;
        string server = null;
        string resource = null;

        // Regex for matching the URL parts.
        Match match = Regex.Match(url, @"^(?:(?<protocol>[^:]+)://)?(?<server>[^/]+)(?:/(?<resource>.+))?$");


        if (match.Success) {
            protocol = match.Groups["protocol"].Value;
            server = match.Groups["server"].Value;
            resource = match.Groups["resource"].Value;
            Console.WriteLine("[URL] = " + url);
            Console.WriteLine("[protocol] = " + protocol);
            Console.WriteLine("[server] = " + server);
            Console.WriteLine("[resource] = " + resource);
        }
        else {
            Console.WriteLine("Invalid URL: Could not parse the provided URL.");
        }
    }
}