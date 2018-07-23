using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servicem8.API.Models;
using System.Threading.Tasks;
using System;

namespace Servicem8.API.Tests
{
    [TestClass]
    public class MaterialTests : IntegrationTestsAbstract
    {
        [TestMethod]
        public async Task CanFetchMaterials()
        {

            var servicem8Client = new Servicem8Client(_apiUsername,
                                                     _apiPassword);

            var materials = await servicem8Client.MaterialResource.List();

            Assert.IsTrue(materials.Count > 0);
        }

        [TestMethod]
        public async Task CanCreateNewMaterial()
        {

            var servicem8Client = new Servicem8Client(_apiUsername,
                                                     _apiPassword);


            var newMaterialId = Guid.NewGuid();

            var newMaterial = new Material()
            {
                uuid = newMaterialId,
                active = 1,
                barcode = "1234",
                cost = "10.23",
                item_description = newMaterialId.ToString(),
                item_is_inventoried = 0,
                item_number = "1234",
                name = string.Format("material {0}", newMaterialId.ToString()),
                price = "22.22",
                quantity_in_stock = 100               
            };

            var result = servicem8Client.MaterialResource.Create(newMaterial);
            result.Wait();

            Assert.IsNull(result.Exception);

            var verifyMaterial = await servicem8Client.MaterialResource.ById(newMaterialId);

            Assert.AreEqual<Guid>(newMaterialId, verifyMaterial.uuid);
            Assert.AreEqual<string>(newMaterial.barcode, verifyMaterial.barcode);
            Assert.AreEqual<string>(newMaterial.name, verifyMaterial.name);
            Assert.AreEqual<string>(newMaterial.item_number, verifyMaterial.item_number);
            Assert.AreEqual<int>(newMaterial.quantity_in_stock, verifyMaterial.quantity_in_stock);

        }

    }
}
