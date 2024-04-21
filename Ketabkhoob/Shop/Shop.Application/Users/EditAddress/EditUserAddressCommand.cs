using Common.Application;
using Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Users.EditAddress
{
    public class EditUserAddressCommand:IBaseCommand
    {
        public EditUserAddressCommand(long addressId, long userId,
            string province, string city, string postalCode,
            string mailingAddress, PhoneNumber phoneNumber, string name, string family)
        {
            AddressId = addressId;
            UserId = userId;
            Province = province;
            City = city;
            PostalCode = postalCode;
            MailingAddress = mailingAddress;
            PhoneNumber = phoneNumber;
            Name = name;
            Family = family;
        }

        public long AddressId { get; private set; }
        public long UserId { get; private set; }
        public string Province { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string MailingAddress { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string NationalID { get; private set; }
    }
}
