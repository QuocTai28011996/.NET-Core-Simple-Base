﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using DemoAPI.Data.EF.Utils;

namespace DemoAPI.Data.EF.Extensions
{
	public static class QueryableExt
	{
		public static T Find<T>(this IQueryable<T> query, Guid id)
		{
			// TODO: Optimize by caching keys
			var key = ReflectionUtil.GetKeyProperty<T>();
			if (key == null) return default;
			return query.FirstOrDefault(BuildLambda<T>(key, id));
		}

		private static Expression<Func<T, bool>> BuildLambda<T>(PropertyInfo key, Guid id)
		{
			var param = Expression.Parameter(typeof(T), "x");
			var prop = Expression.Property(param, key.Name);
			var value = Expression.Constant(id, typeof(Guid));
			var body = Expression.Equal(prop, value);
			return Expression.Lambda<Func<T, bool>>(body, param);
		}
	}
}