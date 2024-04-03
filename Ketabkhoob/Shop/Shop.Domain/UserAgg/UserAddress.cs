using Common.Domain;
using Common.Domain.Exceptions;
using System.Net.Http.Headers;

namespace Shop.Domain.UserAgg
{
    public class UserAddress : BaseEntity
    {
        public UserAddress(long userId, string province, string city, string postalCode, string mailingAddress,
            string phoneNumber, string name, string family, string nationalID)
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
        public string PhoneNumber { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string NationalID { get; private set; }
        public bool IsActive { get; private set; }

        public void Edit(string province, string city, string postalCode, string mailingAddress,
            string phoneNumber, string name, string family, string nationalID)
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
            string phoneNumber, string name, string family, string nationalID)
        {
            NullOrEmptyDomainDataException.CheckString(province,nameof(province));
            NullOrEmptyDomainDataException.CheckString(city, nameof(city));
            NullOrEmptyDomainDataException.CheckString(postalCode, nameof(postalCode));
            NullOrEmptyDomainDataException.CheckString(mailingAddress, nameof(mailingAddress));
            NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));
            NullOrEmptyDomainDataException.CheckString(name, nameof(name));
            NullOrEmptyDomainDataException.CheckString(family, nameof(family));
            NullOrEmptyDomainDataException.CheckString(nationalID, nameof(nationalID));

            if (!nationalID.IsIdValid())
                throw new InvalidDomainDataException(DomainConstants.Exceptions.INVALID_ID);
        }
    }
}
