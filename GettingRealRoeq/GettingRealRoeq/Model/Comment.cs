using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealRoeq.Model
{
    public class Comment 
    {
       public string CommentBox {  get; set; } // Saves the information from the commentbox in bookingwindow.

       public Comment(string commentBox)
       {
            CommentBox = commentBox;
       }
       public Comment()
        {

        }
	}
}
