using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servicem8.API.Models;
using System.Threading.Tasks;
using System;

namespace Servicem8.API.Tests
{
    [TestClass]
    public class CompanyTests : IntegrationTestsAbstract
    {
        [TestMethod]
        public async Task CanFetchCompanies()
        {

            var servicem8Client = new Servicem8Client(_apiUsername,
                                                     _apiPassword);

            var companies = await servicem8Client.Companies.List();

            Assert.IsTrue(companies.Count > 0);
        }

        [TestMethod]
        public void CanCreateCompany()
        {

            var servicem8Client = new Servicem8Client(_apiUsername,
                                                     _apiPassword);

            var newId = Guid.NewGuid();

            var company = new Company()
            {
                active = 1,
                name = string.Format("name{0}", newId.ToString()),
                address = "test street",
                uuid = newId
            };

            var result = servicem8Client.Companies.Save(company);
            result.Wait();

            Assert.IsNull(result.Exception);
           
        }

        [TestMethod]
        public async Task CanFetchById() 
        {
            var servicem8Client = new Servicem8Client(_apiUsername, _apiPassword);

            var companyUUID = Guid.Parse("a8528af7-6a1e-49f2-9026-afc20aab7916");

            var company = await servicem8Client.Companies.ById(companyUUID);

            Assert.IsNotNull(company);
        }
    }


}
