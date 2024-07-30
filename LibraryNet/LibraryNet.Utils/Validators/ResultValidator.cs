namespace LibraryNet.Utils.Validators
{
    public class ResultValidator
    {
        public List<ErrorValidation> Errors { get; set; }
        public bool IsValid => Errors == null || Errors.Count == 0;
        public ValidatedElement this[string property]
        {
            get
            {
                var e = Errors?.FirstOrDefault(er => er.PropertyName == property);
                return e == null ? new ValidatedElement(false, string.Empty) : new ValidatedElement(true, e.Message);
            }
        }

        public void RemoveValidation(string property)
        {
            if (Errors == null || Errors.Count == 0)
                return;
            var index = Errors.FindIndex(er => er.PropertyName == property);
            if (index == -1)
                return;
            Errors.RemoveAt(index);
        }

        public void AddError(string property, string message)
        {
            var erro = new ErrorValidation()
            {
                PropertyName = property,
                Message = message
            };

            Errors ??= new List<ErrorValidation>();
            Errors.Add(erro);
        }

        public ResultValidator AddErrorAndGetValidationResult(string property, string message)
        {
            AddError(property, message);
            return this;
        }

        public void ClearValidation()
        {
            if (Errors == null || Errors.Count == 0)
                return;
            Errors.Clear();
        }
    }
}