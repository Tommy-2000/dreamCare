using FluentValidation.Results;


namespace dreamCare.ApiService.Exceptions
{
    // Create a custom exception for validation errors

    public class ValidationException : Exception
    {

        // Give a default string message upon instantiation
        public ValidationException() : base("Validation exceptions have occurred. Please try again later.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> validFailures) : this()
        {
            // Group the failures of a certain type and group them into the dictionary
            Errors = validFailures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

        public IDictionary<string, string[]> Errors { get; }

    }

}