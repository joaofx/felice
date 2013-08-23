namespace Felice.Core.Mvc
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class DateIsValid : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dt;
            return DateTime.TryParse((string)value, out dt);
        }
    }
}
