using System;
using System.Diagnostics;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CRMTextTestHarness.Tests
{
	/// <summary>
	///     Summary description for CrmTextApiAdapterTests
	/// </summary>
	[TestClass]
	public class CrmTextApiAdapterTests
	{
		private CrmTextApiAdapter _crmTextApiAdapter;

		[TestInitialize]
		public void Setup()
		{
			_crmTextApiAdapter = new CrmTextApiAdapter();
		}

		[TestMethod]
		public void OptInCustomer_When_NewOptIn_Return_X()
		{
			//var customer = new Customer
			//{
			//	Method = "optincustomer",
			//	FirstName = "Mina",
			//	LastName = "Test",
			//	PhoneNumber = "9736415077"
			//};
			var customer = new Customer
			{
				Method = "optincustomer",
				FirstName = "Shari",
				LastName = "Test",
				PhoneNumber = "9084774388"
			};

			var result = _crmTextApiAdapter.OptInCustomer(customer);

			result.Should().NotBeNull();
		}

		[TestMethod]
		public void OptInCustomer_When_AlreadyOptedIn_Return_X()
		{
			var customer = new Customer
			{
				Method = "optincustomer",
				FirstName = "Mina",
				LastName = "Test",
				PhoneNumber = "9736415077"
			};

			var result = _crmTextApiAdapter.OptInCustomer(customer);
		}

		[TestMethod]
		public void SendMessage_When_OptedInCustomer_Return_X()
		{
			var customer = new Customer
			{
				Method = "sendsmsmsg",
				PhoneNumber = "9084774388",
				Message = "This is a test message from AtlantisHealthCare demo"
			};

			var result = _crmTextApiAdapter.SendMessage(customer);
			result.Should().NotBeNull();
			Console.WriteLine(result);
		}

		[TestMethod]
		public void GetCustomerInfo_When_RegisterdCustomer_Return_X()
		{
			var customer = new Customer
			{
				Method = "getcustomerinfo",
				PhoneNumber = "9736415077",
			};

			var result = _crmTextApiAdapter.GetCustomerInfo(customer);
			result.Should().NotBeNull();
			Console.WriteLine(result);
		}
	}
}