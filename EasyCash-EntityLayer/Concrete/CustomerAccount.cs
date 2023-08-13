﻿using System;
using System.ComponentModel.DataAnnotations;

namespace EasyCash_EntityLayer.Concrete
{
	public class CustomerAccount
	{
		[Key]
		public int CustomerAccountID { get; set; }

		public string CustomerAccountNumber { get; set; }

		public string CustomerAccountCurrency { get; set; }

		public decimal CustomerAccountBalance { get; set; }

		public string BankBranch { get; set; }

	    public int AppUserID { get; set; }

		public AppUser AppUser { get; set; }
	}
}

