using Common.Domain;

namespace Shop.Domain.OrderAgg
{
    public class OrderAddress:BaseEntity
    {
        public OrderAddress(string province, string city, string postalCode, string mailingAddress,
            string phoneNumber, string name, string family, string nationalID)
        {
            Province = province;
            City = city;
            PostalCode = postalCode;
            MailingAddress = mailingAddress;
            PhoneNumber = phoneNumber;
            Name = name;
            Family = family;
            NationalID = nationalID;
        }

        public long OrderId {  get; internal set; }
        public string Province { get; private set; }
        public string City { get; private set; }

        public string PostalCode { get; private set; }
        public string MailingAddress { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string NationalID { get; private set; }
        public Order Order { get;set; }
    }
}
