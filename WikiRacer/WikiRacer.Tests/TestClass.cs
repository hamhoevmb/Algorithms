﻿using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using NUnit.Framework;
using Sprache;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using WikiRacer;

namespace WikiRacer.Tests
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void test_file_parsing_without_logic()
        {
            var stream = FileManager.GetFileFromResource("textio/[output]-simple.txt");
            var streamResult = FileManager.GetFileFromResource("textio/_output.txt");
            using (StreamReader streamReader = new StreamReader(stream))
            {
                using (StreamReader streamReaderResult = new StreamReader(streamResult))
                {
                    string input;
                    string inputResult;
                    while ((input = streamReader.ReadLine()) != null)
                    {
                        if ((inputResult = streamReaderResult.ReadLine()) == null)
                            Assert.Fail();
                        if (inputResult != input)
                            Assert.Fail();
                    }
                    Assert.Pass();
                }
            }
        }

        [Test]
        public void test_fruit_strawberry_ladder()
        {
            var firstPageLink = "https://en.wikipedia.org/wiki/Fruit";
            var endPageLink = "https://en.wikipedia.org/wiki/Strawberry";

            var startPage = new WebPage(WebPageManager.GetPageToString(firstPageLink), firstPageLink);
            var endPage = new WebPage(WebPageManager.GetPageToString(endPageLink), endPageLink);

            var expected = new List<WebPage>()
            {
                startPage,
                endPage
            };

            var wikiRacer = new WikiRacer(endPage);
            var result = wikiRacer.GetLadder(startPage);
        }
    }
}
