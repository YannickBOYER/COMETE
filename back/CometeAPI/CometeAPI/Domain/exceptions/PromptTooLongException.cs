namespace CometeAPI.Domain.exception;

public class PromptTooLongException : Exception
{
    public PromptTooLongException(string message = "Veuillez entrer une chaine moins longue") : base(message) { }
}