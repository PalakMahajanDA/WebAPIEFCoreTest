using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using LearningAPI.Models;



public static class MvcHtmlHelpers
{
    public static MvcHtmlString DescriptionFor<TModel, TValue>(this HtmlHelper<TModel> self, Expression<Func<TModel, TValue>> expression)
    {
        var metadata = ModelMetadata.FromLambdaExpression(expression, self.ViewData);
        var description = metadata.Description;
        System.Web.Mvc.MvcHtmlString.Create("jsacnjkddsjcbdsjk");
        return MvcHtmlString.Create(Convert.ToString(description));
        return MvcHtmlString.Create("hjhjjfhsdv");

    }
}