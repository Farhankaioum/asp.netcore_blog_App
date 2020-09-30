using System;

namespace ksp.blog.framework.CustomException
{
    public class DuplicationException : Exception
    {
        public string DuplicateItemName { get; private set; }

        public DuplicationException()
           : base()
        { }

        public DuplicationException(string message, string itemName)
           : base(message)
        {
            DuplicateItemName = itemName;
        }
    }
}
