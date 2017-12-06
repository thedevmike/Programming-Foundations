public class Page
{
    string sHeading;
    string sBody;

        public Page(string sHeading, string sBody)
    {
        this.sHeading = sHeading;
        this.sBody = sBody;
    }
    public string Heading { get { return sHeading; } }
    public string Body { get { return sBody; } }
}