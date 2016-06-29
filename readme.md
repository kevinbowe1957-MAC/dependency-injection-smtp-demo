##SUMMARY
The purpose of this application is to demonstrate Dependency Injection. This is accomplished by creating a hypothetical SMTP, mass mailing application. 

The application creates a custom message body based on a collection of name strings. The custom message body also contains the names of the classes used to generate the message and send the message. Displaying class names, demonstrates .Net reflection and confirms that the correct classes were injected into the application interfaces.

Once the custom message body is generated, the application passes the custom message body to the appropriate email sender. The email sender then send’s the message.

##CONDITIONS
1)	This is a simple C# console application. All of the code is included in a single file. Running the application is as simple as creating a console application in Visual Studio and replacing the Program.cs file with the example code.
2)	The structure of this application is intentionally simple in order to not obfuscate the DI example.
3)	There is no exception handling in this application, such as TRY/CATCH/FINALLY or USE(…){…}. This is intentional because it would obfuscate the DI example.
4)	This application does not send a real Email message. The message is ‘sent’ to the Console. It is reasonably simple to upgrade this app to send a real message. At least two email services would be required, such as Gmail and Hotmail. 
5)	The ‘To’, ‘From’, and ‘Subject’ text is static. DI could easily be used to automate these values.
6)	The EmailSender is arbitrarily selected based on the length of the last name. See ‘Final Thoughts’ for enhancements.

##INTRODUCTION
This example was inspired by a recent job interview question. This was the original question:
```
Write a simple Email app that uses Dependency Injection.*
Use the following struct and interfaces in your solution:*

public struct ParsedName
{
  public string First { get; set; }
   public string Last { get; set; }
}

public interface INameParser
{
   ParsedName ParseName(string input);
}

public interface IEmailSender
{
    *void SendEmail(string to, string from, string subject, string body);
}
```

I provided a simplified answer and moved on. After the interview, I returned to the question and created an application that is more thorough.

Please download **Dependency Injection-Simple SMTP Demo Application_062916.docx** for a indepth description of this code.