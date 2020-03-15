using System;
using System.Globalization;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.WebSockets;
using System.Security.Cryptography;
using WholeKitAndCaboodle;
using Xunit;
using RandomNumberGenerator = WholeKitAndCaboodle.RandomNumberGenerator;
using Newtonsoft.Json;
using Shouldly;

namespace WholeKitAndCaboodleTest
{
    public class TestingHashKeysHarness
    {
        [Fact]
        public void ShouldCreateUniqueHasValues()
        {
            var repo = new LeadRepo(10);
            var newLead = new Lead("foo", "bar", "1231231234");
            repo.AddLead(newLead).ShouldBeTrue();
            repo.AddLead(newLead).ShouldBeFalse();
            
            var newLead2 = new Lead("foo", "bar", "1231231234");
            repo.AddLead(newLead2).ShouldBeFalse();
            repo._data.Keys.Count.ShouldBe(11);
        }
        
    }

    public class LeadRepo
    {
        public System.Collections.Generic.Dictionary<string, Lead> _data = new Dictionary<string, Lead>();

        public LeadRepo(int numberToCreate)
        {
            var randomeIzor = new RandomNumberGenerator();
            var dataManager = new DataManager();
            var nameService = new FirstLastNameService(dataManager, randomeIzor);
            var phoneService = new PhoneNumberService(dataManager,randomeIzor);
                //var sha = SHA1.Create();
            for (var i = 0; i < numberToCreate; i++)
            {
                var lead = new Lead(nameService.GetFirstName(), nameService.GetLastName(), phoneService.GetUSPhoneNumber() );
                _data.Add(lead.hash,lead);
                
            }
        }

        public Lead GetHashCode(string hascode)
        {
            return _data[hascode];
        }

        public bool AddLead(Lead  lead)
        {
            if (!_data.ContainsKey(lead.hash))
            {
                _data.Add(lead.hash, lead);
                return true;
            }
            return false;

        }
    }
    public class Lead
    {
        public Lead(string firstname, string lastname, string phoneNumber)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            phonenumber = phoneNumber;
            this.hash = GetHash($"{firstname}{lastname}{phoneNumber}");
        }

        private string GetHash(string key)
        {
            using var sha = new System.Security.Cryptography.SHA256Managed();
            byte[] textData = System.Text.Encoding.UTF8.GetBytes(key);
            byte[] hash = sha.ComputeHash(textData);
            return BitConverter.ToString(hash).Replace("-", string.Empty);
        }
        public string firstname;
        public string lastname;
        public string phonenumber;
        public string hash;
    }
}