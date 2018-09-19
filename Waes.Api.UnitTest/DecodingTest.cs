using System;
using System.Text;
using Xunit;
using Waes.Api.Helpers;

namespace Waes.Api.UnitTest
{
    public class DecodingTest
    {

        [Fact]
        public void DecodesBase64String() {
            var text = "string for decode";
            var toEncode = Encoding.Default.GetBytes(text);
            var encoded = Convert.ToBase64String(toEncode);
            var decoded = Helpers.Decoder.Decode(encoded);
            Assert.Equal(text, decoded);
        }

        [Fact]
        public void DecodesBase64EscapedJsonString()
        {
            var text = @"Organized and developed ATP 2015 World Tennis Tournament Accreditation System in Istanbul. Pressing 2000 unique accreditation card (QR Code) with 30 different staff and participant roles. Holders of accreditation are granted access to specified stadiums and zones, including any restricted zones. (C# 5.0, Asp.Net MVC, MS SQL 2014, Android 5.0,Microsoft Azure Cloud Systems)";
            var encoded = @"T3JnYW5pemVkIGFuZCBkZXZlbG9wZWQgQVRQIDIwMTUgV29ybGQgVGVubmlzIFRvdXJuYW1lbnQgQWNjcmVkaXRhdGlvbiBTeXN0ZW0gaW4gSXN0YW5idWwuIFByZXNzaW5nIDIwMDAgdW5pcXVlIGFjY3JlZGl0YXRpb24gY2FyZCAoUVIgQ29kZSkgd2l0aCAzMCBkaWZmZXJlbnQgc3RhZmYgYW5kIHBhcnRpY2lwYW50IHJvbGVzLiBIb2xkZXJzIG9mIGFjY3JlZGl0YXRpb24gYXJlIGdyYW50ZWQgYWNjZXNzIHRvIHNwZWNpZmllZCBzdGFkaXVtcyBhbmQgem9uZXMsIGluY2x1ZGluZyBhbnkgcmVzdHJpY3RlZCB6b25lcy4gKEMjIDUuMCwgQXNwLk5ldCBNVkMsIE1TIFNRTCAyMDE0LCBBbmRyb2lkIDUuMCxNaWNyb3NvZnQgQXp1cmUgQ2xvdWQgU3lzdGVtcyk=";

            var decoded = Helpers.Decoder.Decode(encoded);
            Assert.Equal(text, decoded);
        }

        [Fact]
        public void BreakIfInputIsOfInvalidFormat()
        {
            Assert.Throws<FormatException>(() => { Helpers.Decoder.Decode("123"); });
        }

        [Fact]
        public void BreakIfInputIsEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => { Helpers.Decoder.Decode(""); });
        }

        [Fact]
        public void BreakIfInputIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => { Helpers.Decoder.Decode(null); });
        }

        [Fact]
        public void BreakIfInputIsOnlyWhiteSpaces()
        {
            Assert.Throws<ArgumentNullException>(() => { Helpers.Decoder.Decode("   "); });
        }
    }
}
