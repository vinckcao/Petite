﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;

namespace Petite.Data
{
    public interface IPetiteDbContext
    {
        #region fields

        #endregion

        #region utility

        #endregion

        #region methods

        /// <summary>
        /// 对数据库执行给定的 DDL/DML 命令。 
        /// 与接受 SQL 的任何 API 一样，对任何用户输入进行参数化以便避免 SQL 注入攻击是十分重要的。 您可以在 SQL 查询字符串中包含参数占位符，然后将参数值作为附加参数提供。 
        /// 您提供的任何参数值都将自动转换为 DbParameter。 unitOfWork.ExecuteSqlCommand("UPDATE dbo.Posts SET Rating = 5 WHERE Author = @p0", userSuppliedAuthor); 
        /// 或者，您还可以构造一个 DbParameter 并将它提供给 SqlQuery。 这允许您在 SQL 查询字符串中使用命名参数。 unitOfWork.ExecuteSqlCommand("UPDATE dbo.Posts SET Rating = 5 WHERE Author = @author", new SqlParameter("@author", userSuppliedAuthor));
        /// </summary>
        /// <param name="transactionalBehavior">对于此命令控制事务的创建。</param>
        /// <param name="sql">命令字符串。</param>
        /// <param name="parameters">要应用于命令字符串的参数。</param>
        /// <returns>执行命令后由数据库返回的结果。</returns>
        int ExecuteSqlCommand(TransactionalBehavior transactionalBehavior, string sql, params object[] parameters);

        /// <summary>
        /// 创建一个原始 SQL 查询，该查询将返回给定泛型类型的元素。 类型可以是包含与从查询返回的列名匹配的属性的任何类型，也可以是简单的基元类型。 该类型不必是实体类型。
        ///  即使返回对象的类型是实体类型，上下文也决不会跟踪此查询的结果。 使用 SqlQuery(String, Object[]) 方法可返回上下文跟踪的实体。 
        /// 与接受 SQL 的任何 API 一样，对任何用户输入进行参数化以便避免 SQL 注入攻击是十分重要的。 您可以在 SQL 查询字符串中包含参数占位符，然后将参数值作为附加参数提供。 
        /// 您提供的任何参数值都将自动转换为 DbParameter。 unitOfWork.SqlQuery&lt;Post&gt;("SELECT * FROM dbo.Posts WHERE Author = @p0", userSuppliedAuthor); 
        /// 或者，您还可以构造一个 DbParameter 并将它提供给 SqlQuery。 这允许您在 SQL 查询字符串中使用命名参数。 unitOfWork.SqlQuery&lt;Post&gt;("SELECT * FROM dbo.Posts WHERE Author = @author", new SqlParameter("@author", userSuppliedAuthor));
        /// </summary>
        /// <typeparam name="TElement">查询所返回对象的类型。</typeparam>
        /// <param name="sql">SQL 查询字符串。</param>
        /// <param name="parameters">要应用于 SQL 查询字符串的参数。 如果使用输出参数，则它们的值在完全读取结果之前不可用。 这是由于 DbDataReader 的基础行为而导致的，有关详细信息，请参见 http://go.microsoft.com/fwlink/?LinkID=398589。</param>
        /// <returns></returns>
        IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters);

        /// <summary>
        /// 创建一个原始 SQL 查询，该查询将返回给定类型的元素。 类型可以是包含与从查询返回的列名匹配的属性的任何类型，也可以是简单的基元类型。 该类型不必是实体类型。
        ///  即使返回对象的类型是实体类型，上下文也决不会跟踪此查询的结果。 使用 SqlQuery(String, Object[]) 方法可返回上下文跟踪的实体。 与接受 SQL 的任何 API 一样，
        /// 对任何用户输入进行参数化以便避免 SQL 注入攻击是十分重要的。 您可以在 SQL 查询字符串中包含参数占位符，然后将参数值作为附加参数提供。
        ///  您提供的任何参数值都将自动转换为 DbParameter。 context.Database.SqlQuery(typeof(Post), "SELECT * FROM dbo.Posts WHERE Author = @p0", userSuppliedAuthor);
        ///  或者，您还可以构造一个 DbParameter 并将它提供给 SqlQuery。 这允许您在 SQL 查询字符串中使用命名参数。 context.Database.SqlQuery(typeof(Post), 
        /// "SELECT * FROM dbo.Posts WHERE Author = @author", new SqlParameter("@author", userSuppliedAuthor));
        /// </summary>
        /// <param name="elementType">查询所返回对象的类型。</param>
        /// <param name="sql">SQL 查询字符串。</param>
        /// <param name="parameters">要应用于 SQL 查询字符串的参数。 如果使用输出参数，则它们的值在完全读取结果之前不可用。 这是由于 DbDataReader 的基础行为而导致的，有关详细信息，请参见 http://go.microsoft.com/fwlink/?LinkID=398589。</param>
        /// <returns></returns>
        IEnumerable SqlQuery(Type elementType, string sql, params Object[] parameters);

        /// <summary>
        /// Execute stores procedure and load a list of entities at the end
        /// </summary>
        /// <param name="commandText">存储过程名称</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>Entities</returns>
        IEnumerable ExecuteStoredProcedureList(string commandText, params object[] parameters);

        #endregion
    }
}
