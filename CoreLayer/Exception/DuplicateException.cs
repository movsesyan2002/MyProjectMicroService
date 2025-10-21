namespace CoreLayer.Exception;

public class DuplicateException : System.Exception
{
    public DuplicateException(string message) : base(message) {}
}