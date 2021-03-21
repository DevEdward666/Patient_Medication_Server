using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static WEB_API.Interface.ITableFilter;

namespace WEB_API.Hooks
{
    public static class useFilter
    {

        public static string generateSortQuery(mdlSort col, string defaultSort)
        {

            List<string> sorts = new List<string>();

            if (!String.IsNullOrWhiteSpace(defaultSort))
            {
                sorts.Add(defaultSort);
            }

            if (!String.IsNullOrWhiteSpace(col.key))
            {
                sorts.Add($" {col.key} {col.direction} ");
            }


            var sortQuery = String.Join(", ", sorts.ToArray());


            if (String.IsNullOrEmpty(sortQuery))
            {
                return "";
            }
            else
            {
                return " ORDER BY " + sortQuery;
            }

        }

        public static string generateLimitQuery(int page, int limit)
        {
            return limit == 0 ? "" : $"limit { page * limit  } , { limit + 1} ";
        }

        public static DynamicParameters generateFilterParams(mdlFilter filter)
        {
            var parameters = new Dictionary<string, object>();

            foreach (var item in filter.search)
            {
                if (item.field != null)
                {
                    parameters.Add(item.key, item.value.ToString().Trim());
                }
            }

            DynamicParameters dbParams = new DynamicParameters();
            dbParams.AddDynamicParams(parameters);

            return dbParams;
        }

        public static string generateSearchParams(string col, string searchKey)
        {
            String[] words = searchKey.Trim().Split(' ');
            string whereQuery = "";

            if (words.Length > 0)
            {
                whereQuery = " where ";
            }
            else
            {
                return "";
            }

            for (int i = 0; i < words.Length; i++)
            {

                whereQuery = whereQuery + $" {col} LIKE '%{words[i]}%' ";

                if ((i + 1) < words.Length)
                {
                    whereQuery = whereQuery + " and ";
                }
            }

            return whereQuery;

        }

        public static string generateSearchEqualOrDefault(string col, string keyword)
        {
            if (col.Trim().Equals("") || keyword.Trim().Equals(""))
            {
                return "";
            }

            return $"{col} = if({keyword} = '',{col},{keyword})";
        }

        public static string generateSearchLikeOrDefault(string col, string keyword, string value)
        {
            if (col.Trim().Equals("") || keyword.Trim().Equals(""))
            {
                return "";
            }

            if(value.Equals(""))
            {
                return $"{col} = {col}";
            }
            else
            {
                return $"{col} LIKE CONCAT('%',{keyword},'%')";
            }

        }

    }
}