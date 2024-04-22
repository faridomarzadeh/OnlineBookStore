using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;
using Shop.Domain.UserAgg.Enums;
using Shop.Domain.UserAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.UserAgg
{
    public class User:AggregateRoot
    {
        public User(string name, string family, string phoneNumber, string email,
            string password, Gender gender,IUserDomainService userDomainService)
        {
            Validate(phoneNumber,email,userDomainService);
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            Gender = gender;
            AvatarName = UserConstants.DefaultAvatarImage;
        }

        public string Name { get; private set; }
        public string Family { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string AvatarName {  get; private set; }
        public Gender Gender { get; private set; }
        public List<UserRole> Roles { get; private set; }
        public List<Wallet> Wallets { get; private set; }
        public List<UserAddress> Addresses { get; private set; }

        public void Edit(string name, string family, string phoneNumber,
            string email, Gender gender, IUserDomainService userDomainService)
        {
            Validate(phoneNumber, email,userDomainService);
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            Gender = gender;
        }

        public void AddAddress(UserAddress address)
        {
            address.UserId = Id;
            Addresses.Add(address);
        }

        public void DeleteAddress(long addressId)
        {
            var address = Addresses.FirstOrDefault(x => x.Id == addressId);
            if (address == null)
                throw new NullOrEmptyDomainDataException(DomainConstants.Exceptions.ADDRESS_NOT_FOUND);

            Addresses.Remove(address);
        }

        public void EditAddress(long userId, string province, string city, string postalCode, string mailingAddress,
            PhoneNumber phoneNumber, string name, string family, string nationalID)
        {
            var oldAddress = Addresses.FirstOrDefault(f=>f.Id==userId);
            if (oldAddress == null)
                throw new NullOrEmptyDomainDataException(DomainConstants.Exceptions.ADDRESS_NOT_FOUND);

            oldAddress.Edit(province, city, postalCode, mailingAddress,phoneNumber, name, family, nationalID);
        }

        public void ChargeWallet(Wallet wallet)
        {
            Wallets.Add(wallet);
        }

        public void SetRoles(List<UserRole> roles)
        {
            roles.ForEach(role => role.UserId =Id);
            Roles.Clear();
            Roles.AddRange(roles);
        }

        public void SetAvatar(string imageName)
        {
            if (string.IsNullOrWhiteSpace(imageName))
                imageName = UserConstants.DefaultAvatarImage;

            AvatarName = imageName;
        }

        public static User Register(string phoneNumber, string password, IUserDomainService userDomainService)
        {
            return new User(string.Empty,string.Empty,phoneNumber,null,password,Gender.None,userDomainService);
        }

        public void Validate(string phoneNumber, string email, IUserDomainService userDomainService)
        {
            NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));
            NullOrEmptyDomainDataException.CheckString(email, nameof(email));
            if (phoneNumber.Length != 11)
                throw new InvalidDomainDataException(DomainConstants.Exceptions.INVALID_PHONE_NUMBER);
            if (email.IsValidEmail() == false)
                throw new InvalidDomainDataException(DomainConstants.Exceptions.INVALID_EMAIL);

            if (phoneNumber != PhoneNumber && userDomainService.PhoneNumberExists(phoneNumber))
                throw new InvalidDomainDataException(DomainConstants.Exceptions.NUMBER_IN_USE);
            if (email != Email && userDomainService.EmailExists(email))
                throw new InvalidDomainDataException(DomainConstants.Exceptions.EMAIL_IN_USE);
        }
    }
}
