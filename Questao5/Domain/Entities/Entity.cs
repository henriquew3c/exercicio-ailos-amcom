using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Results;

namespace Questao5.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        public bool IsValid { get; private set; }

        public bool IsInvalid => !IsValid;

        public ValidationResult ValidationResult { get; set; }

        public virtual bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ValidationResult = validator.Validate(model);
            return IsValid = ValidationResult.IsValid;
        }

        public virtual bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator, Action<ValidationStrategy<TModel>> options)
        {
            ValidationResult = validator.Validate(model, options);
            return IsValid = ValidationResult.IsValid;
        }

        #region BaseBehaviours

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo is null)
                return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() ^ 93) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }

        #endregion
    }
}
