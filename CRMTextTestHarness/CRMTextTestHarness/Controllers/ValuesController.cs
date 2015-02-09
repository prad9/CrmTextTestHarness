using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRMTextTestHarness.Controllers
{
	public class ValuesController : ApiController
	{
		// GET api/values
		public IEnumerable<string> Get()
		{
			var crmTextApiAdapter = new CrmTextApiAdapter();
			var customer = new Customer()
			{
				Method = "optincustomer",
				FirstName = "Mina",
				LastName = "Test",
				PhoneNumber = "9736415077"
			};
			crmTextApiAdapter.OptInCustomer(customer);

			return new string[] { "value1", "value2" };
		}

		// GET api/values/5
		public string Get(int id)
		{
			return "value";
		}

		// POST api/values
		public void Post([FromBody]string value)
		{
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/values/5
		public void Delete(int id)
		{
		}
	}
}
