using System;
using System.Collections.Generic;
using System.Text;

namespace _053506_Snetko_Lab5.Entities
{
    public class NoItemsException : Exception
    {
        public NoItemsException(string item) : base(item) { }

        public override string ToString() => $"Item: {Message} doesn't exist";
    }
}
