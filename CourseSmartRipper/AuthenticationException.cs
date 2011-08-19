using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace CourseSmartRipper
{
	public class AuthenticationException : ApplicationException
	{
		public WebHeaderCollection mHeaders { get; set; }
		public String mPage { get; set; }
	}
}
