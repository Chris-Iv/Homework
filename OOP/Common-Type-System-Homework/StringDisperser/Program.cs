using System;
using System.Collections;

namespace StringDisperser
{
    public class StringDisperser : ICloneable, IComparable<StringDisperser>, IEnumerable


    {
        public string[] Text { get; set; }

        public StringDisperser(params string[] text)
        {
            this.Text = text;
        }

        public override bool Equals(object obj)
        {
            StringDisperser stringDisperser = obj as StringDisperser;
            if (this.Text.Equals(stringDisperser))
            {
                return true;
            }

            return false;
        }

        public static bool operator ==(StringDisperser firstString, StringDisperser secondString)
        {
            bool result = Equals(firstString, secondString);
            return result;
        }

        public static bool operator !=(StringDisperser firstString, StringDisperser secondString)
        {
            bool result = !Equals(firstString, secondString);
            return result;
        }

        public override int GetHashCode()
        {
            int result = this.Text.GetHashCode();
            return result;
        }

        public override string ToString()
        {
            string result = String.Join(", ", this.Text);
            return result;
        }

        public object Clone()
        {
            var clone = new StringDisperser((string[])this.Text.Clone());
            return clone;
        }

        public int CompareTo(StringDisperser other)
        {
            return this.ToString().CompareTo(other.ToString());
        }

        public IEnumerator GetEnumerator()
        {
            var str = this.ToString();
            var length = str.Length;
            for (var i = 0; i < length; i++)
            {
                yield return str[i];
            }
        }
    }
}
