using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Na.TextConfig.Tests
{
    public class ParserTests
    {
        ITestOutputHelper _output;

        public ParserTests(ITestOutputHelper output)
        {
            this._output = output;
        }

        [Fact]
        public void Parser_returns_null_passing_null()
        {
            Assert.Null(Parser<Config>.Parse(null));
        }

        [Fact]
        public void Parser_returns_null_passing_empthy_list()
        {
            Assert.Null(Parser<Config>.Parse(new List<string> (0)));
        }

        [Fact]
        public void Parser_returns_null_passing_list_with_empthy_strings()
        {
            Assert.Null(Parser<Config>.Parse(new List<string> { "" }));
        }

        [Fact]
        public void Parser_should_parse()
        {
            // Arrange
            var lines = new List<string> { "SettingA | 10", "SettingB | string value" };

            // Act
            var configObj = Parser<Config>.Parse(lines);

            // Asserts
            Assert.Equal(10, configObj.SettingA);
            Assert.Equal("string value", configObj.SettingB);
        }

        [Fact]
        public void Parser_should_parse_multiline()
        {
            // Arrange
            var lines = new List<string> {
                "SettingA | 10",
                $"SettingB | line1{Environment.NewLine}line2" };

            // Act
            var configObj = Parser<Config>.Parse(lines);

            // Asserts
            Assert.Equal(10, configObj.SettingA);
            //_output.WriteLine(configObj.SettingB);
            Assert.Equal($"line1{Environment.NewLine}line2", configObj.SettingB);
        }


        [Fact]
        public void Parser_should_parse_with_property_missing()
        {
            // Arrange
            var lines = new List<string> {
                "SettingA | ",
                $"" };

            // Act
            var configObj = Parser<Config>.Parse(lines);

            // Asserts
            Assert.Equal(0, configObj.SettingA);            
            Assert.Null(configObj.SettingB);
        }
    }

    internal class Config
    {
        public int SettingA { get; set; }
        public string SettingB { get; set; }
    }
}
