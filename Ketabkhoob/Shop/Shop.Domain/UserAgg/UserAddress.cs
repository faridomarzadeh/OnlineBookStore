using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;
using System.Net.Http.Headers;

namespace Shop.Domain.UserAgg
{
    public class UserAddress : BaseEntity
    {
        private UserAddress() { }
        public UserAddress(long userId, string province, string city, string postalCode, string mailingAddress,
            PhoneNumber phoneNumber, string name, string family, string nationalID)
        {
            Validate(province, city, postalCode, mailingAddress, phoneNumber, name, family, nationalID);
            UserId = userId;
            Province = province;
            City = city;
            PostalCode = postalCode;
            MailingAddress = mailingAddress;
            PhoneNumber = phoneNumber;
            Name = name;
            Family = family;
            NationalID = nationalID;
        }

        public long UserId { get; internal set; }
        public string Province { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string MailingAddress { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string NationalID { get; private set; }
        public bool IsActive { get; private set; }

        public void Edit(string province, string city, string postalCode, string mailingAddress,
            PhoneNumber phoneNumber, string name, string family, string nationalID)
        {
            Validate(province, city, postalCode, mailingAddress, phoneNumber, name, family, nationalID);
            Province = province;
            City = city;
            PostalCode = postalCode;
            MailingAddress = mailingAddress;
            PhoneNumber = phoneNumber;
            Name = name;
            Family = family;
            NationalID = nationalID;
            IsActive = false;
        }
        public void SetActive()
        {
            IsActive=true;
        }
        public void Validate(string province, string city, string postalCode, string mailingAddress,
            PhoneNumber phoneNumber, string name, string family, string nationalID)
        {
            if (phoneNumber == null)
                throw new NullOrEmptyDomainDataException("Phone Number is null or empty");

            NullOrEmptyDomainDataException.CheckString(province,nameof(province));
            NullOrEmptyDomainDataException.CheckString(city, nameof(city));
            NullOrEmptyDomainDataException.CheckString(postalCode, nameof(postalCode));
            NullOrEmptyDomainDataException.CheckString(mailingAddress, nameof(mailingAddress));
            NullOrEmptyDomainDataException.CheckString(name, nameof(name));
            NullOrEmptyDomainDataException.CheckString(family, nameof(family));
            NullOrEmptyDomainDataException.CheckString(nationalID, nameof(nationalID));

            if (!nationalID.IsIdValid())
                throw new InvalidDomainDataException(DomainConstants.Exceptions.INVALID_ID);
        }
    }
}
