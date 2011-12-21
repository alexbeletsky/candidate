using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Candidate.Infrustructure.Extensions
{

    // http://www.iwantmymvc.com/populate-drop-down-list-mvc-3

    public static class DropDownListForExtensions
    {
        public static MvcHtmlString DropDownListFor<TModel, TSelectedProperty>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TSelectedProperty>> expression,
            IDictionary<int, string> dictionary)
        {

            var selectListItems = new SelectList(dictionary, "Key", "Value");
            return helper.DropDownListFor(expression, selectListItems);
        }

    }
}