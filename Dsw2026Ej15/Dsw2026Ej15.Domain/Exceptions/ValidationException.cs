namespace Dsw2026Ej15.Domain.Exceptions;

internal class ValidarException

{
    public class ValidationException : Exception
    {
        public ValidationException(string message)
            : base(message)
        {
        }
    }


}
