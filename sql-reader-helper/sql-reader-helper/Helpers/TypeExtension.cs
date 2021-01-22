using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SqlHelperReader.Helpers
{
	internal static class TypeExtension
	{
		internal static string GetPropertyName<T, TProperty>(Expression<Func<T, TProperty>> expression)
		{
			if (expression.Body is MemberExpression member)
			{
				return member.Member.Name;
			}
			return string.Empty;
		}
	}
}
