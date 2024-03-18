using System;
using HelloWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloWebAPI.Controllers
{

	// bir controllerr tanımlayacağımız zaman aşağıdaki yapıyı oluşturmak gerek. 
	[ApiController] // attribute'lerim. api app'içinde tanımlı. ekstra tanımlamama gerek yok. 
	[Route("home")]
	public class HomeController : ControllerBase
	{
		//[HttpGet]
		//public String GetMessage()
		//{
		//	return " Hello ASP.NET Wep Api! ";
		//}

		// yukarıdaki bir yoldu. bir de models içinde bir class oluşturup onu gönderiyorum.

		[HttpGet]
		public ResponseModel GetMessage()
		{
			return new ResponseModel()
			{
				HttpsStatus = 200,
				Message = "Models içinden gönderiyorum. Json olarak hazırlanıyor otomatik."

			};
		}
	}
}

