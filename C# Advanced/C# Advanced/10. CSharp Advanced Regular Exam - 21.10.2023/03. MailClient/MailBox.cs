using System.Text;

namespace MailClient
{
    public class MailBox
    {
        private int capacity;
        private List<Mail> inbox;
        private List<Mail> archive;

        public MailBox(int capacity)
        {
            this.capacity = capacity;
            this.inbox = new();
            this.archive = new();
        }

        public int Capacity { get { return capacity; } set { capacity = value; } }

        public List<Mail> Inbox { get { return inbox; } set { inbox = value; } }

        public List<Mail> Archive { get { return archive; } set { archive = value; } }

        public void IncomingMail(Mail mail)
        {
            if (this.Capacity > this.Inbox.Count)
            {
                this.Inbox.Add(mail);
            }
        }

        public bool DeleteMail(string sender) => this.Inbox.Remove(this.Inbox.FirstOrDefault(x => x.Sender == sender));

        public int ArchiveInboxMessages()
        {
            int messagesCount = this.Inbox.Count;

            foreach (Mail mail in this.Inbox)
            {
                this.Archive.Add(mail);
            }

            this.Inbox.Clear();

            return messagesCount;
        }

        public string GetLongestMessage()
        {
            Mail mailWithLongestMessage = this.Inbox.OrderByDescending(x => x.Body).First();

            return mailWithLongestMessage.ToString();
        }

        public string InboxView()
        {
            StringBuilder output = new();
            output.AppendLine("Inbox:");

            foreach (Mail mail in this.Inbox)
            {
                output.AppendLine(mail.ToString());
            }

            return output.ToString().TrimEnd();
        }
    }
}
