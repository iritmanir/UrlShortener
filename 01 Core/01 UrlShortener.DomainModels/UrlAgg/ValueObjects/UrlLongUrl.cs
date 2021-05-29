using System;
using Framework.Domain.BaseModels;
using Framework.Domain.Exceptions;

namespace UrlShortener.DomainModels.UrlAgg.ValueObjects
{
    public class UrlLongUrl : BaseValueObject<UrlLongUrl>
    {
        public string Value { get; set; }

        public UrlLongUrl(string value)
        {
            if (string.IsNullOrEmpty(value?.Trim()))
                throw new DomainException("Long url is empty.");

            var isValid = Uri.TryCreate(value.Trim(), UriKind.Absolute, out var uriResult)
                         && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            if (!isValid)
                throw new DomainException("Url is not valid.");

            Value = value.ToLower().Trim();
        }

        public static implicit operator string(UrlLongUrl obj) => obj.Value;

        public override bool ObjectIsEqual(UrlLongUrl otherObject)
            => otherObject.Value == Value;

        public override int ObjectGetHashCode()
            => Value.GetHashCode();
    }
}