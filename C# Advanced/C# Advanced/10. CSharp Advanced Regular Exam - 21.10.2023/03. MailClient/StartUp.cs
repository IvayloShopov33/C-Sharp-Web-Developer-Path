namespace MailClient
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            MailBox mailbox = new(5);

            Mail mail1 = new("John", "Alice", "Hello Alice, How are you?");
            Mail mail2 = new("Alice", "Bob", "Hi Bob, Here's the document you requested.");
            Mail mail3 = new("Bob", "Charlie", "Hey Charlie, Let's meet for lunch.");
            Mail mail4 = new("Charlie", "David", "Hi David, Can you help me with the project?");
            Mail mail5 = new("David", "Eva", "Hello Eva, Don't forget our meeting tomorrow.");
            Mail mail6 = new("Eva", "Frank", "Hi Frank, I found an interesting article for you.");
            Mail mail7 = new("Frank", "Grace", "Hey Grace, How's your day going?");
            Mail mail8 = new("Grace", "Henry", "Hi Henry, Please review the proposal.");
            Mail mail9 = new("Henry", "Isabella", "Hello Isabella, Let's schedule a call.");
            Mail mail10 = new("Isabella", "John", "Hi John, I received your message. Thanks!");

            mailbox.IncomingMail(mail1);
            mailbox.IncomingMail(mail2);
            mailbox.IncomingMail(mail3);
            mailbox.IncomingMail(mail4);
            mailbox.IncomingMail(mail5);
            mailbox.IncomingMail(mail6);

            Console.WriteLine(mailbox.DeleteMail("David"));
            Console.WriteLine(mailbox.DeleteMail("Eva"));

            mailbox.IncomingMail(mail6);

            Console.WriteLine(mailbox.DeleteMail("Eva"));
            Console.WriteLine(mailbox.ArchiveInboxMessages());

            mailbox.IncomingMail(mail7);
            mailbox.IncomingMail(mail8);
            mailbox.IncomingMail(mail9);
            mailbox.IncomingMail(mail10);

            Console.WriteLine(mailbox.GetLongestMessage());
            Console.WriteLine(mailbox.InboxView());
        }
    }
}