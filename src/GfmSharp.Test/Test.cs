using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GfmSharp.Test
{
    [TestFixture]
    public class Test
    {
        [Test]
        public async void GetMarkdown()
        {
            var GfmSharp = new GfmSharp();
            string content = await GfmSharp.GetHtml( File.ReadAllText( "TestFiles/source.md" ) );

            Console.WriteLine( content );

            Assert.That( content, Is.StringContaining( "GitHub Flavored Markdown" ) );
        }

        [Test]
        public async void GetGithubFlavoredMarkdown()
        {
            var GfmSharp = new GfmSharp();
            string content = await GfmSharp.GetHtml( new GfmSharpMessage { Text = File.ReadAllText( "TestFiles/source.md" ), Mode = GfmSharpMessage.Modes.Gfm } );

            Console.WriteLine( content );

            Assert.That( content, Is.StringContaining( "GitHub Flavored Markdown" ) );
        }
    }
}
