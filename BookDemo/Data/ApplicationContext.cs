using System;
using BookDemo.Models;

namespace BookDemo.Data
{
	public static class ApplicationContext
	{
		public static List<Book> Books { get; set; }
		static ApplicationContext()
		{
			Books = new List<Book>()
			{
				new Book(){Id=1, title="Karagöz ve Hacivat", Price=75},
				new Book(){Id=2, title="Mesnevi", Price=150},
				new Book(){Id=3, title="Dede Korkut", Price=75}
			};

		}
	}
}

