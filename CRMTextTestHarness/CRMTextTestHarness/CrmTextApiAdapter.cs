using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CRMTextTestHarness
{
	public class CrmTextApiAdapter
	{
		public async Task OptInCustomer(Customer customerToOptIn)
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("https://restapi.crmtext.com/");
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/text"));

				//ATLANTISDEV123
				const string authString = "pradeep.vattikuti@atlantishealthcare.com:AThealthcare@01D:ATLANTISDEV123";
				 var authBytes = System.Text.Encoding.UTF8.GetBytes(authString);
				var encodedAuthString = Convert.ToBase64String(authBytes);
				//var requestUri = string.Format("smapi/rest?method=optincustomer&firstname={0}&lastname={1}&phone_number={2}",customerToOptIn.FirstName,customerToOptIn.LastName, customerToOptIn.PhoneNumber);
				var requestUri = string.Format("smapi/rest");
				var response = await client.PostAsJsonAsync(new Uri(requestUri), customerToOptIn);
				if (response.IsSuccessStatusCode)
				{
					// Get the URI of the created resource.
					Uri gizmoUrl = response.Headers.Location;
				}
			}
		}
	}

	public class Customer
	{
		public string Method { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
	}
}