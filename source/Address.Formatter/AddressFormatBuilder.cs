using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Address.Formatter
{
    public class AddressFormatBuilder
    {
        readonly IList<Func<AddressFormat.Settings>> _builders
            = new List<Func<AddressFormat.Settings>>();

        public AddressFormatBuilder Address(
            Action<LineBuilder> action,
            string identifier, params string[] identifiers)
        {
            _builders.Add(
                () =>
                    {
                        var lineBuilder = new LineBuilder();
                        action(lineBuilder);

                        return
                            new AddressFormat.Settings
                                {
                                    Identifiers = new[] {identifier}.Concat(identifiers),
                                    Lines = lineBuilder.BuildSettings()
                                };
                    });

            return this;
        }

        public IEnumerable<AddressFormat.Settings> BuildSettings()
        {
            return _builders.Select(b => b());
        }

        public IEnumerable<AddressFormat> Build()
        {
            return _builders.Select(b => new AddressFormat(b()));
        }

        public class LineBuilder
        {
            readonly IList<Func<AddressFormatLine.Settings>> _builders
                = new List<Func<AddressFormatLine.Settings>>();

            public LineBuilder Line(Action<ElementBuilder> action,
                                    string elementSeparator = " ",
                                    string prefix = null, string suffix = null,
                                    bool trim = true)
            {
                _builders.Add(
                    () =>
                        {
                            var elementBuilder = new ElementBuilder();
                            action(elementBuilder);

                            return new AddressFormatLine.Settings
                                {
                                    Elements = elementBuilder.BuildSettings(),
                                    ElementSeparator = elementSeparator,
                                    Prefix = prefix,
                                    Suffix = suffix,
                                    Trim = trim
                                };
                        });
                return this;
            }

            public IEnumerable<AddressFormatLine.Settings> BuildSettings()
            {
                return _builders.Select(b => b());
            }

            public IEnumerable<AddressFormatLine> Build()
            {
                return _builders.Select(b => new AddressFormatLine(b()));
            }
        }

        public class ElementBuilder
        {
            readonly IList<Func<AddressFormatElement.Settings>> _builders
                = new List<Func<AddressFormatElement.Settings>>();

            public ElementBuilder Element(
                Expression<Func<IAddress, string>> property,
                string prefix = null, string suffix = null,
                bool trim = true, bool toUppercase = false)
            {
                _builders.Add(
                    () => new AddressFormatElement.Settings
                        {
                            Name = ((MemberExpression) property.Body).Member.Name,
                            Prefix = prefix,
                            Suffix = suffix,
                            Trim = trim,
                            ToUppercase = toUppercase
                        }
                    );

                return this;
            }

            public IEnumerable<AddressFormatElement.Settings> BuildSettings()
            {
                return _builders.Select(b => b());
            }

            public IEnumerable<AddressFormatElement> Build()
            {
                return _builders.Select(b => new AddressFormatElement(b()));
            }
        }
    }
}