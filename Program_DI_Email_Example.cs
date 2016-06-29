using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionFour
{
	class Program
	{
		public struct ParsedName
		{
			public string First { get; set; }
			public string Last { get; set; }
		}
		
		//---------------------------------------
		public interface INameParser
		{
			ParsedName ParseName(string input);
		}

		public class FirstLastParser : INameParser
		{
			public ParsedName ParseName(string input)
			{
				string[] sa = input.Split();
				return new ParsedName()
				{
					First = sa[0].Trim(),
					Last = sa[1].Trim()
				};

			} // END_ParseName

		} // END_FirstLastParser_Class

		public class LastFirstParser : INameParser
		{
			public ParsedName ParseName(string input)
			{
				string[] sa = input.Split(',');
				return new ParsedName()
				{
					First = sa[1].Trim(),
					Last = sa[0].Trim()
				};
			} // END_ParseName

		} // END_LastFirstParser_Class

		//---------------------------------------
		public interface IEmailSender
		{
			void SendEmail(string to, string from, string subject, string body);
		}

		public class MyEmailSender : IEmailSender
		{
			public void SendEmail(string to, string from, string subject, string body)
			{
				//string message = "This is the Message from -- MyEmailSender";

				string message = string.Format(
					"eMail Sent\n" +
					"----------\n" +
					"To: {0} From: {1} Subject: {2}\n" +
					"{3}",
					to, from, subject, body
				);

				Console.WriteLine(message);
			}

		} // END_MyEmailSender_Class

		public class YourEmailSender : IEmailSender
		{
			public void SendEmail(string to, string from, string subject, string body)
			{
				//string messageX = "This is the Message from -- YourEmailSender";

				string message = string.Format(
					"eMail Sent\n" +
					"----------\n" +
					"To: {0} From: {1} Subject: {2}\n" +
					"{3}",
					to, from, subject, body
				);

				Console.WriteLine(message);
			}
		} // END_YourEmailSender_Class

		//---------------------------------------
		/// <summary>
		/// This returns the proper form of the name
		/// </summary>
		/// <param name="name">Pre-parsed name</param>
		/// <example>Kevin Bowe will return "FirstLast". Bowe, Kevin will return "LastFirst"</example>
		/// <returns>String</returns>
		static string GetNameForm(string name)
		{
			if (name.IndexOf(',') == -1)
			{
				// Comma not found
				return "FirstLast";
			}
			return "LastFirst";
		}

		/// <summary>
		/// Construct the email message body
		/// </summary>
		/// <param name="name">Pre-parsed name</param>
		/// <param name="parsedName">Parsed name struct: First: Last:</param>
		/// <param name="nameParser">NameParser object</param>
		/// <param name="emailSender">EmailSender object</param>
		/// <returns>String</returns>
		private static string BuildMessage(string name, ParsedName parsedName, INameParser nameParser, IEmailSender emailSender)
		{
			string parserName = nameParser.GetType().ToString().Split('+')[1];
			string emailSenderName = emailSender.GetType().ToString().Split('+')[1]; ;

			string message = string.Format(
				"Message Body\n" +
				"------------\n" +
				"Original Input Name: {0} \n" +
				"First: {1} \n" +
				"Last: {2} \n" +
				"Name Parsed With: {3} \n" +
				"Message Sent With: {4} \n\n\n",
				name,
				parsedName.First,
				parsedName.Last,
				parserName,
				emailSenderName
				);
			return message;
		} // END_BuildMessage
		
		static void Main(string[] args)
		{
			List<string> nameList = new List<string>()
			{
				"kevin bowe",
				"bowe, kevin",
				"Johnney Cash",
				"Miles Davis",
				"Plant, Robert",
				"Lady Gaga",
				"Lin-Manual Miranda"
			};

			foreach (string name in nameList)
			{
				// choose nameParser
				INameParser nameParser;
				switch (GetNameForm(name))
				{
					case "FirstLast": nameParser = new FirstLastParser();
						break;
					case "LastFirst": nameParser = new LastFirstParser();
						break;
					default: nameParser = new FirstLastParser();
						break;
				}
				ParsedName parsedName = nameParser.ParseName(name);

				// choose EmailSender
				IEmailSender emailSender;
				if (parsedName.Last.Length == 4)
					 emailSender = new MyEmailSender();
				else emailSender = new YourEmailSender();

				string message = BuildMessage(name, parsedName, nameParser, emailSender);
				emailSender.SendEmail("joe@gmail.com", "me@hotmail.com", "SUBJECT: Hello", message);

			} // END_FOREACH

		} // END_Main
	} 
}
