using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Candidate.Core.Extensions;

namespace Candidate.Infrustructure.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString CurrentAction(this HtmlHelper helper)
        {
            var action = helper.ViewContext.RouteData.GetRequiredString("action");
            return new MvcHtmlString(action.FirstCharIsUpperCase());
        }

        public static MvcHtmlString CurrentController(this HtmlHelper helper)
        {
            var controller = helper.ViewContext.RouteData.GetRequiredString("controller");
            return new MvcHtmlString(controller.FirstCharIsUpperCase());
        }

        public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes)
        {
            return LabelFor(html, expression, new RouteValueDictionary(htmlAttributes));
        }

        public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            if (String.IsNullOrEmpty(labelText))
            {
                return MvcHtmlString.Empty;
            }

            TagBuilder tag = new TagBuilder("label");
            tag.MergeAttributes(htmlAttributes);
            tag.Attributes.Add("for", html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));
            tag.SetInnerText(labelText);
            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }
    }
}