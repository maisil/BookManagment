using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookManagment.Models
{
    public class BookIssue
    {
       
            [Key, Column(Order = 0)]
            public string MemberId { get; set; }
            [Key, Column(Order = 1)]
            public string BookId { get; set; }
            [DataType(DataType.Date)]
            public DateTime IssueDate { get; set; }
            [DataType(DataType.Date)]
            public DateTime DueDate { get; set; }
            public virtual Member Member { get; set; }
            public virtual Book Book { get; set; }

        public BookIssue(string memberId,string bookId,DateTime issueDate,DateTime dueDate)
        {
            MemberId = memberId;
            BookId = bookId;
            IssueDate = issueDate; 
            DueDate = dueDate;

        }
    }
}
