namespace CoreLayer.Exception;

public class BusinessRuleViolationException : System.Exception
{
    public BusinessRuleViolationException(string message) : base(message) {}
}