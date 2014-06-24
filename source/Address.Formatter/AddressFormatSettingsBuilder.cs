using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Address.Formatter
{
    public class AddressFormatSettingsBuilder
    {
        readonly IList<Func<AddressFormat>> _builders
            = new List<Func<AddressFormat>>();

        public AddressFormatSettingsBuilder Add(
            string identifier, Action<LineBuilder> action)
        {
            _builders.Add(
                () =>
                    {
                        var lineBuilder = new LineBuilder();
                        action(lineBuilder);

                        return new AddressFormat
                            {
                                Identifier = identifier,
                                Lines = lineBuilder.Build().ToArray()
                            };
                    });

            return this;
        }

        public IEnumerable<AddressFormat> Build()
        {
            return _builders.Select(b => b());
        }

        public class LineBuilder
        {
            readonly IList<Func<AddressFormatLine>> _builders
                = new List<Func<AddressFormatLine>>();

            public LineBuilder Line(Action<ElementBuilder> action)
            {
                _builders.Add(
                    () =>
                        {
                            var elementBuilder = new ElementBuilder();
                            action(elementBuilder);

                            return new AddressFormatLine
                                {
                                    Elements = elementBuilder.Build().ToArray()
                                };
                        });
                return this;
            }

            public IEnumerable<AddressFormatLine> Build()
            {
                return _builders.Select(b => b());
            }
        }

        public class ElementBuilder
        {
            readonly IList<Func<AddressFormatElement>> _builders
                = new List<Func<AddressFormatElement>>();

            public ElementBuilder Element(
                string prefix, Expression<Func<IAddress, string>> property, string suffix,
                bool toUppercase)
            {
                _builders.Add(
                    () => new AddressFormatElement
                        {
                            Name = ((MemberExpression) property.Body).Member.Name,
                            Prefix = prefix,
                            Suffix = suffix,
                            ToUppercase = toUppercase
                        });

                return this;
            }

            public ElementBuilder Element(
                Expression<Func<IAddress, string>> property, string suffix = null,
                bool toUppercase = false)
            {
                return Element(null, property, suffix, toUppercase);
            }

            public IEnumerable<AddressFormatElement> Build()
            {
                return _builders.Select(b => b());
            }
        }
    }
}