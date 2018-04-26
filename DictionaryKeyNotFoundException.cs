using System;

namespace XNALara
{
    public class DictionaryKeyNotFoundException : Exception
    {
        public DictionaryKeyNotFoundException(string message) : base(message) {
        }
    }
}
