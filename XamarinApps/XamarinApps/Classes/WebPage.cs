using System;
namespace XamarinApps.Classes
{
	public class WebPage
	{
        public string name { get; set; }
        public string url { get; set; }

        public WebPage(string Name, string Url)
        {
            url = Url;
            name = Name;
        }
    }
}

