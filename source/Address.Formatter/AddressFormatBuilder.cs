using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Address.Formatter
{
    public class AddressFormatBuilder
    {
        readonly IList<Func<AddressFormat>> _builders
            = new List<Func<AddressFormat>>();

        public AddressFormatBuilder Address(
            Action<LineBuilder> action, 
            string identifier, params string[] identifiers)
        {
            _builders.Add(
                () =>
                    {
                        var lineBuilder = new LineBuilder();
                        action(lineBuilder);

                        return new AddressFormat
                            (
                            new[] {identifier}.Concat(identifiers).ToArray(),
                            lineBuilder.Build().ToArray()
                            );
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

                            return new AddressFormatLine(
                                elementBuilder.Build().ToArray(),
                                elementSeparator,
                                prefix,
                                suffix,
                                trim
                                );
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
                Expression<Func<IAddress, string>> property,
                string prefix = null, string suffix = null,
                bool trim = true, bool toUppercase = false)
            {
                _builders.Add(
                    () => new AddressFormatElement(
                              ((MemberExpression) property.Body).Member.Name,
                              prefix,
                              suffix,
                              trim,
                              toUppercase
                              )
                    );

                return this;
            }

            public IEnumerable<AddressFormatElement> Build()
            {
                return _builders.Select(b => b());
            }
        }
    }
}