using System.Collections.Generic;

namespace SoulBound
{
    public class Traits
    {
        public Dictionary<string, object> traitsDict;

        public Traits()
        {
            traitsDict = new Dictionary<string, object>();
        }

        Traits(string anonymousId)
        {
            traitsDict = new Dictionary<string, object>();
            traitsDict.Add("anonymousId", anonymousId);
        }

        public Traits(
            Address address,
            string age,
            string birthday,
            Company company,
            string createdAt,
            string description,
            string email,
            string firstname,
            string gender,
            string userId,
            string lastname,
            string name,
            string phone,
            string title,
            string username,
            string walletaddress,
            string pseudonym
        )
        {
            traitsDict = new Dictionary<string, object>();
            this.traitsDict.Add("address", address.addressDict);
            this.traitsDict.Add("age", age);
            this.traitsDict.Add("birthday", birthday);
            this.traitsDict.Add("company", company.companyDict);
            this.traitsDict.Add("createdAt", createdAt);
            this.traitsDict.Add("description", description);
            this.traitsDict.Add("email", email);
            this.traitsDict.Add("firstname", firstname);
            this.traitsDict.Add("gender", gender);
            this.traitsDict.Add("userId", userId);
            this.traitsDict.Add("lastname", lastname);
            this.traitsDict.Add("name", name);
            this.traitsDict.Add("phone", phone);
            this.traitsDict.Add("title", title);
            this.traitsDict.Add("username", username);
            this.traitsDict.Add("walletaddress", walletaddress);
            this.traitsDict.Add("pseudonym", pseudonym);
        }

        public string getId()
        {
            if (traitsDict.ContainsKey("userId"))
            {
                return traitsDict["userId"] as string;
            }
            return null;
        }

        public Dictionary<string, object> getTraits()
        {
            return traitsDict;
        }

        public Traits PutAddress(Address address)
        {
            this.traitsDict.Add("address", address.addressDict);
            return this;
        }

        public Traits PutAge(string age)
        {
            this.traitsDict.Add("age", age);
            return this;
        }

        public Traits PutBirthday(string birthday)
        {
            this.traitsDict.Add("birthday", birthday);
            return this;
        }
        public Traits PutWalletAddress(string walletaddress)
        {
            this.traitsDict.Add("walletaddress", walletaddress);
            return this;
        }
        public Traits PutPseudonym(string pseudonym)
        {
            this.traitsDict.Add("pseudonym", pseudonym);
            return this;
        }
        public Traits PutCompany(Company company)
        {
            this.traitsDict.Add("company", company);
            return this;
        }

        public Traits PutCreatedAt(string createdAt)
        {
            this.traitsDict.Add("createdAt", createdAt);
            return this;
        }

        public Traits PutDescription(string description)
        {
            this.traitsDict.Add("description", description);
            return this;
        }

        public Traits PutEmail(string email)
        {
            this.traitsDict.Add("email", email);
            return this;
        }

        public Traits PutFirstName(string firstname)
        {
            this.traitsDict.Add("firstname", firstname);
            return this;
        }

        public Traits PutGender(string gender)
        {
            this.traitsDict.Add("gender", gender);
            return this;
        }

        public Traits PutId(string userId)
        {
            this.traitsDict.Add("userId", userId);
            return this;
        }

        public Traits PutLastName(string lastname)
        {
            this.traitsDict.Add("lastname", lastname);
            return this;
        }

        public Traits PutName(string name)
        {
            this.traitsDict.Add("name", name);
            return this;
        }

        public Traits PutPhone(string phone)
        {
            this.traitsDict.Add("phone", phone);
            return this;
        }

        public Traits PutTitle(string title)
        {
            this.traitsDict.Add("title", title);
            return this;
        }

        public Traits PutUserName(string username)
        {
            this.traitsDict.Add("username", username);
            return this;
        }

        public Traits Put(string key, object value)
        {
            this.traitsDict.Add(key, value);
            return this;
        }
    }

    public class Address
    {
        public Dictionary<string, object> addressDict;

        public Address()
        {
            this.addressDict = new Dictionary<string, object>();
        }

        public Address PutCity(string city)
        {
            this.addressDict.Add("city", city);
            return this;
        }

        public Address PutCountry(string country)
        {
            this.addressDict.Add("country", country);
            return this;
        }

        public Address PutPostalCode(string postalcode)
        {
            this.addressDict.Add("postalcode", postalcode);
            return this;
        }

        public Address PutState(string state)
        {
            this.addressDict.Add("state", state);
            return this;
        }

        public Address PutStreet(string street)
        {
            this.addressDict.Add("street", street);
            return this;
        }

        public Address(string city, string country, string postalcode, string state, string street)
        {
            this.addressDict = new Dictionary<string, object>();
            this.addressDict.Add("city", city);
            this.addressDict.Add("country", country);
            this.addressDict.Add("postalcode", postalcode);
            this.addressDict.Add("state", state);
            this.addressDict.Add("street", street);
        }
    }

    public class Company
    {
        public Dictionary<string, object> companyDict;
        public Company()
        {
            this.companyDict = new Dictionary<string, object>();
        }

        Company(string name, string id, string industry)
        {
            this.companyDict = new Dictionary<string, object>();
            this.companyDict.Add("name", name);
            this.companyDict.Add("id", id);
            this.companyDict.Add("industry", industry);
        }

        public Company PutName(string name)
        {
            this.companyDict.Add("name", name);
            return this;
        }

        public Company PutId(string id)
        {
            this.companyDict.Add("id", id);
            return this;
        }

        public Company PutIndustry(string industry)
        {
            this.companyDict.Add("industry", industry);
            return this;
        }
    }
}