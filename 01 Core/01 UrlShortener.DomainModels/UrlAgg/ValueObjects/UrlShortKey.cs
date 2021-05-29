using Framework.Domain.BaseModels;
using Framework.Domain.Exceptions;

namespace UrlShortener.DomainModels.UrlAgg.ValueObjects
{
    public class UrlShortKey : BaseValueObject<UrlShortKey>
    {
        public string Value { get; set; }

        public UrlShortKey(string value)
        {
            if (string.IsNullOrEmpty(value?.Trim()))
                throw new DomainException("Url short key in empty.");

            Value = value.ToLower().Trim();
        }

        public static implicit operator string(UrlShortKey obj) => obj.Value;

        public override bool ObjectIsEqual(UrlShortKey otherObject)
            => otherObject.Value == Value;

        public override int ObjectGetHashCode()
            => Value.GetHashCode();
    }
}