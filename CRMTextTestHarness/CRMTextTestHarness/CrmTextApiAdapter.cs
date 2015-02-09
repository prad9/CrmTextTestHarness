using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CRMTextTestHarness
{
	public class CrmTextApiAdapter
	{
		public string OptInCustomer(Customer customer)
		{
			try
			{
				using (var client = new HttpClient())
				{
					//client.BaseAddress = new Uri("https://restapi.crmtext.com/");
					client.DefaultRequestHeaders.Accept.Clear();
					//client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/text"));

					//client.Timeout = TimeSpan.FromSeconds(30);

					//ATLANTISDEV123
					const string authString = "pradeep.vattikuti@atlantishealthcare.com:AThealthcare@01D:ATLANTISDEV123";
					var authBytes = System.Text.Encoding.UTF8.GetBytes(authString);
					var encodedAuthString = Convert.ToBase64String(authBytes);
					client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedAuthString);

					var values = new Dictionary<string, string>
					{
						{"method", customer.Method},
						{"firstname", customer.FirstName},
						{"lastname", customer.LastName},
						{"phone_number", customer.PhoneNumber}
					};
					var urlEncodedContent = new FormUrlEncodedContent(values);

					//var queryString = new StringContent("method=optincustomer&firstname=Mina&lastname=Test&phone_number=9736415077");
					//var requestUri = string.Format("smapi/rest");
					var response = client.PostAsync("https://restapi.crmtext.com/smapi/rest", urlEncodedContent).Result;
					if (response.IsSuccessStatusCode)
					{
						return response.Content.ReadAsStringAsync().Result;
					}
				}
				return string.Empty;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public string SendMessage(Customer customer)
		{
			try
			{
				using (var client = new HttpClient())
				{
					//client.BaseAddress = new Uri("https://restapi.crmtext.com/");
					client.DefaultRequestHeaders.Accept.Clear();

					//ATLANTISDEV123
					const string authString = "pradeep.vattikuti@atlantishealthcare.com:AThealthcare@01D:ATLANTISDEV123";
					var authBytes = System.Text.Encoding.UTF8.GetBytes(authString);
					var encodedAuthString = Convert.ToBase64String(authBytes);
					client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedAuthString);

					var values = new Dictionary<string, string>
					{
						{"method", customer.Method},
						{"phone_number", customer.PhoneNumber},
						{"message",customer.Message}
					};
					var urlEncodedContent = new FormUrlEncodedContent(values);

					var response = client.PostAsync("https://restapi.crmtext.com/smapi/rest", urlEncodedContent).Result;
					if (response.IsSuccessStatusCode)
					{
						return response.Content.ReadAsStringAsync().Result;
					}
				}
				return string.Empty;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public string GetCustomerInfo(Customer customer)
		{
			try
			{
				using (var client = new HttpClient())
				{
					client.DefaultRequestHeaders.Accept.Clear();

					const string authString = "pradeep.vattikuti@atlantishealthcare.com:AThealthcare@01D:ATLANTISDEV123";
					var authBytes = System.Text.Encoding.UTF8.GetBytes(authString);
					var encodedAuthString = Convert.ToBase64String(authBytes);
					client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedAuthString);

					var values = new Dictionary<string, string>
					{
						{"method", customer.Method},
						{"phone_number", customer.PhoneNumber},
					};
					var urlEncodedContent = new FormUrlEncodedContent(values);

					var response = client.PostAsync("https://restapi.crmtext.com/smapi/rest", urlEncodedContent).Result;
					if (response.IsSuccessStatusCode)
					{
						return response.Content.ReadAsStringAsync().Result;
					}
				}
				return string.Empty;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

	public class Customer
	{
		public string Method { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
		public string Message { get; set; }
	}
}